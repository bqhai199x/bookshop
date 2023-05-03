using Dapper;
using Entities;
using Infrastructure.Common;
using Infrastructure.Common.Interfaces;
using Infrastructure.Repositories.Interfaces;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<int> Add(Product product)
        {
            int id = await DbQuery.Query("Product")
                .InsertGetIdAsync<int>(new
                {
                    Name = product.Name,
                    PublisherId = product.PublisherId,
                    Author = product.Author,
                    CategoryId = product.CategoryId,
                    Size = product.Size,
                    NumPage = product.NumPage,
                    Price = product.Price,
                    Description = product.Description,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }, DbTrans);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int result = await DbQuery.Query("Product").Where("Id", id).DeleteAsync();
            return result;
        }

        public async Task<List<Product>> GetAll()
        {
            var productList = await DbQuery.Query("Product").GetAsync<Product>();
            return productList.ToList();
        }

        public async Task<Product?> GetById(int id)
        {
            var query = new Query("Product")
                                .LeftJoin("Category", "Product.CategoryId", "Category.Id")
                                .Where("Product.Id", id);

            MySqlCompiler compiler = new MySqlCompiler();
            SqlResult sqlResult = compiler.Compile(query);

            var result = await DbConn.QueryAsync<Product, Category, Product>(sqlResult.Sql, (pro, cate) =>
            {
                pro.Category = cate;
                return pro;
            }, splitOn: "Id", param: sqlResult.NamedBindings);

            return result.FirstOrDefault();
        }

        public async Task<int> Update(Product product)
        {
            var result = await DbQuery.Query("Product")
                .Where("Id", product.Id)
                .UpdateAsync(new
                {
                    Name = product.Name,
                    PublisherId = product.PublisherId,
                    Author = product.Author,
                    CategoryId = product.Category,
                    Size = product.Size,
                    NumPage = product.NumPage,
                    Price = product.Price,
                    Description = product.Description,
                    UpdatedDate = DateTime.Now
                }, DbTrans);
            return result;
        }
    }
}
