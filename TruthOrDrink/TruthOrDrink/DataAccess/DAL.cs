using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TruthOrDrink.Model;

namespace TruthOrDrink.DataAccess
{
    internal class DAL
    {
        public string GetUser(string userName)
        {

            User user = new User();
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().Where(x => x.UserName == userName).FirstOrDefault();
                return user.UserName;
            }
        }
    }
}
