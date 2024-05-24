using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using SQLite;

namespace App2
{
    public class DBUs : ContentPage
    {
        SQLiteConnection database;

        public DBUs(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Diary>();
        }
        // User

        public IEnumerable<User> GetItems()
        {
            return database.Table<User>().ToList();
        }
        public User GetItem(int id)
        {
            return database.Get<User>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<User>(id);
        }
        /*public int DeleteItem(Diary item)
        {
            return database.Delete(item);
        }*/
        public int SaveItem(User item)
        {
            if (item.ID_us != 0)
            {
                return database.Update(item);
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int UpdateItem(User item)
        {
            return database.Update(item);
        }
    }
}