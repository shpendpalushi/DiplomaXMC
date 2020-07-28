using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaXMC.Model
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<XMCUsers>().Wait();
        }

        //public Task<int> SaveItemAsync(XMCUsers user)
        //{
        //    //if (!user.XMCUsers_Id.Equals(""))
        //    //{
        //    //    return db.UpdateAsync(user);
        //    //}
        //    //else
        //    //{
        //    //    return db.InsertAsync(user);
        //    //}
        //}

        //public Task<XMCUsers> GetItemAsync(int userID)
        //{
        //    //return db.Table<XMCUsers>().Where(i => i.XMCUsers_Id == userID).FirstOrDefaultAsync();
        //}

        public Task<List<XMCUsers>> GetItemsAsync()
        {
            return db.Table<XMCUsers>().ToListAsync();
        }
    }
}
