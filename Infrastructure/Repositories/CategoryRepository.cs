using Entities;
using Infrastructure.Common;
using Infrastructure.Common.Interfaces;
using Infrastructure.Repositories.Interfaces;
using SqlKata.Execution;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<int> Add(Category category)
        {
            int id = await TableQuery
                .InsertGetIdAsync<int>(new
                {
                    Name = category.Name,
                    Description = category.Description
                }, DbTrans);
            return id;
        }

        //public override async Task<Category?> GetById(int id)
        //{
        //    var query = new Query("Category")
        //                    .LeftJoin("Product", "Product.CategoryId", "Category.Id")
        //                    .Where("Category.Id", id);

        //    MySqlCompiler compiler = new MySqlCompiler();
        //    SqlResult sqlResult = compiler.Compile(query);

        //    Category? category = null;
        //    await DbConn.QueryAsync<Category, Product, Category>(sqlResult.Sql, (cate, pro) =>
        //    {
        //        category ??= cate;
        //        if (pro != null) category.Products.Add(pro);
        //        return category;
        //    }, splitOn: "Id", param: sqlResult.NamedBindings);
        //    return category;
        //}

        public async Task<int> Update(Category category)
        {
            int result = await TableQuery
                .Where("Id", category.Id)
                .UpdateAsync(new
                {
                    Name = category.Name,
                    Description = category.Description
                });
            return result;
        }
    }
}
