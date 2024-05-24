using System;
using System.Collections.Generic;
using System.Text;
using App2.Models;

using SQLite;

namespace App2
{
    public class DB
    {
        SQLiteConnection database;

        public DB(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Diary>();
        }
        public IEnumerable<Diary> GetItems()
        {
            return database.Table<Diary>().ToList();
        }
        public Diary GetItem(int id)
        {
            return database.Get<Diary>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Diary>(id);
        }
        /*public int DeleteItem(Diary item)
        {
            return database.Delete(item);
        }*/
        public int SaveItem(Diary item)
        {
            if (item.ID != 0)
            {
                database.Update(item);
                return item.ID;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int UpdateItem(Diary item)
        {
            return database.Update(item);
        }

    }
}
