using DWShop.App.Models;
using SQLite;

namespace DWShop.App.Context
{
    public class DataContext
    {

        SQLiteAsyncConnection db;

        async Task Init()
        {

            if (db is not null)
                return;

            db = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DWShop.db3")
                , SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            try
            {

            await db.CreateTableAsync<Product>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<List<Product>> GetFavorites()
        {
            await Init();
            return await db.Table<Product>().ToListAsync();


        }

        public async Task<bool> SetFavorite(Product product)
        {
            await Init();
            var _product = await GetProductById(product.Id);

            if (_product is not null)
                return false;

            await db.InsertAsync(product);

            return true;
        }

        async Task<Product> GetProductById(int id)
        {
            await Init();
            return await db.Table<Product>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


    }
}
