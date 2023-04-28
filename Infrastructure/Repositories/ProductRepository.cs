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

        public Task<int> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var productList = await DbFactory.Query("Product").GetAsync<Product>();
            return productList.ToList();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var query = new Query("Product")
                                .LeftJoin("Category", "Product.CategoryId", "Category.Id")
                                .Where("Product.Id", id)
                                .Limit(1);

            MySqlCompiler compiler = new MySqlCompiler();
            SqlResult sqlResult = compiler.Compile(query);

            var result = await DbConn.QueryAsync<Product, Category, Product>(sqlResult.Sql, (pro, cate) =>
            {
                pro.Category = cate;
                return pro;
            }, splitOn: "Id", param: sqlResult.NamedBindings);

            return result.FirstOrDefault();
        }

        public Task<int> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
