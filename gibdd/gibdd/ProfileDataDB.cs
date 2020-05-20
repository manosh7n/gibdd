using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace gibdd
{
    public class ProfileDataDB
    {
        private readonly SQLiteAsyncConnection database;

        public ProfileDataDB(string path)
        {
            database = new SQLiteAsyncConnection(path);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<ProfileData>();
            Console.WriteLine("Таблица создана!");
        }
        
        public async Task DropTable()
        {
            await database.DropTableAsync<ProfileData>();
            Console.WriteLine("Таблица удалена!");
        }

        public async Task AddProfile(ProfileData data)
        {
            await database.InsertAsync(data);
            Console.WriteLine("Профиль добавлен!");
        }

        public async Task<List<ProfileData>> GetAllProfiles()
        {
            return await database.Table<ProfileData>().ToListAsync();
            
        }
        public async Task<ProfileData> GetProfile(int id)
        {
            return await database.GetAsync<ProfileData>(id);
        }
        
        public async Task DeleteProfile(ProfileData item)
        {
            await database.DeleteAsync(item);
            Console.WriteLine("Профиль удален!");
        }

        public async Task UpdateProfile(ProfileData item)
        {
            await database.UpdateAsync(item);
            Console.WriteLine("Профиль обновлен!");
        }
    }
}