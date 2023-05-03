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

        public async Task<int> Add(Category category)
        {
            int id = await DbQuery.Query("Category")
                .InsertGetIdAsync<int>(new
                {
                    Name = category.Name,
                    Description = category.Description
                }, DbTrans);
            return id;
        }

        public async Task<int> Delete(int id)
        {
            int result = await DbQuery.Query("Category").Where("Id", id).DeleteAsync();
            return result;
        }

        public async Task<List<Category>> GetAll()
        {
            var categoryList = await DbQuery.Query("Category").GetAsync<Category>();
            return categoryList.ToList();
        }

        public async Task<Category?> GetById(int id)
        {
            var query = new Query("Category")
                            .LeftJoin("Product", "Product.CategoryId", "Category.Id")
                            .Where("Category.Id", id);

            MySqlCompiler compiler = new MySqlCompiler();
            SqlResult sqlResult = compiler.Compile(query);

            Category? category = null;
            await DbConn.QueryAsync<Category, Product, Category>(sqlResult.Sql, (cate, pro) =>
            {
                category ??= cate;
                if (pro != null) category.Products.Add(pro);
                return category;
            }, splitOn: "Id", param: sqlResult.NamedBindings);
            return category;
        }

        public async Task<int> Update(Category entity)
        {
            int result = await DbQuery.Query("Category")
                .Where("Id", entity.Id)
                .UpdateAsync(new
                {
                    Name = entity.Name,
                    Description = entity.Description
                });
            return result;
        }
    }
}
