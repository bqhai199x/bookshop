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
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Task<int> AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categoryList = await DbFactory.Query("Category").GetAsync<Category>();
            return categoryList.ToList();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var query = new Query("Category")
                                .LeftJoin("Product", "Product.CategoryId", "Category.Id")
                                .Where("Category.Id", id);

            MySqlCompiler compiler = new MySqlCompiler();
            SqlResult sqlResult = compiler.Compile(query);

            var result = await DbConn.QueryAsync<Category, Product, Category>(sqlResult.Sql, (cate, pro) =>
            {
                cate.Products.Add(pro);
                return cate;
            }, splitOn: "Id", param: sqlResult.NamedBindings);

            Category? category = null;
            foreach (var item in result.GroupBy(x => x.Id))
            {
                category = item.First();
                category.Products = item.SelectMany(x => x.Products).ToList();
                break;
            }
            return category;
        }

        public Task<int> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
