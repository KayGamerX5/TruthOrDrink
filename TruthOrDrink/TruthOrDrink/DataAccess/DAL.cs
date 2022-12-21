using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TruthOrDrink.Model;

namespace TruthOrDrink.DataAccess
{
    public class DAL
    {
        public User GetUser(string userName)
        {

            
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();
                var user = connection.Table<User>().Where(x => x.UserName == userName).FirstOrDefault();
                return user;
            }
        }

        public User CreateUser(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();
                int insertedrows = connection.Insert(user);
                return user;
            }
        }
    }
}
