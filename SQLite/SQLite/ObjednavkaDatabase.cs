using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLite.Entity
{
    public class ObjednavkaDatabase
    {
        // SQLite connection
        private SQLiteAsyncConnection database;

        public ObjednavkaDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Objednavka>().Wait();
            database.CreateTableAsync<Produkt>().Wait();
        }

        // Query
        public Task<List<Objednavka>> GetItemAsync()
        {
            return database.Table<Objednavka>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Objednavka>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Objednavka>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

       


        public Task<List<Produkt>> GetItemsAsync()
        {
            return database.Table<Produkt>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Produkt item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> UpdateItemAsync(Objednavka item)
        {
            return database.UpdateAsync(item);

        }

        public Task<int> DeleteItemAsync(Objednavka item)
        {

            return database.DeleteAsync(item);
        }
    }
}
