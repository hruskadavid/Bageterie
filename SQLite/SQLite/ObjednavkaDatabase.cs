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
            database.CreateTableAsync<ObjednanyProdukt>().Wait();
        }

        // Query
        public Task<List<Objednavka>> GetItemAsync()
        {
            return database.Table<Objednavka>().ToListAsync();
        }
        public Task<List<Objednavka>> GetItemDetailAsync(int id)
        {
            return database.QueryAsync<Objednavka>("SELECT * FROM [Objednavka] WHERE [ID] = " + id);
        }
        // Query using SQL query string
        public Task<List<Objednavka>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Objednavka>("SELECT * FROM [Objednavka]");
        }
        public Task<int> SaveObjednavkaAsync(Objednavka item)
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



        public Task<List<Produkt>> GetItemsAsync()
        {
            return database.Table<Produkt>().ToListAsync();
        }
        public Task<Produkt> GetItemAsync(int id)
        {
            return database.Table<Produkt>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<List<Produkt>> GetItemToListAsync(int id)
        {
            return database.QueryAsync<Produkt>("SELECT * FROM [Produkt] WHERE [ID] = " + id);
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
        public Task<int> SaveObjednanyProduktAsync(ObjednanyProdukt item)
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
        public int OrderItemPrice(ObjednanyProdukt item)
        {
            int price = GetItemAsync(item.ProduktID).Result.Cena;
            return price * item.Pocet;
        }
        public Task<List<ObjednanyProdukt>> GetOrderItemsfromOrder(int ObjednavkaID)
        {
            return database.QueryAsync<ObjednanyProdukt>("SELECT * FROM [ObjednanyProdukt] WHERE [ObjednavkaID] = " + ObjednavkaID);
        }

    }
}
