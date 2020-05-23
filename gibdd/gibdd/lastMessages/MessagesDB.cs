using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace gibdd
{
    public class MessagesDB
    {
        private readonly SQLiteAsyncConnection database;

        public MessagesDB(string path)
        {
            database = new SQLiteAsyncConnection(path);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Messages>();
        }

        public async Task AddMessage(Messages data)
        {
            var messages = await GetAllMessages();
            var result = messages.Find(item => item.message == data.message);
            if (result == null)
            {
                await database.InsertAsync(data);
            }
        }

        public async Task<List<Messages>> GetAllMessages()
        {
            return await database.Table<Messages>().ToListAsync();
            
        }

    }
}