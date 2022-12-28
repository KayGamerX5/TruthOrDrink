using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public Player CreatePlayer(Player player)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                connection.Insert(player);
                return player;
            }
        }

        public Player GetPlayer(int index)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                var player = connection.Table<Player>().Where(x => x.Id == index).FirstOrDefault();
                return player;
            }
        }

        public Question RandomQuestion()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Question>();
                Random rnd = new Random();
                var questions = connection.Table<Question>().ToList();
                int index = rnd.Next(questions.Count);
                var question = questions.ElementAt(index);
                return question;
            }
        }

        public int EndGame()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                int success = connection.DeleteAll<Player>();

                return success;
            }
        }

        public int CountPlayers()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                var players = connection.Table<Player>().ToList();

                int PlayerCount = players.Count;

                return PlayerCount;
            }
        }

        public int TruthPicked(int currentPlayer)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                var players = connection.Table<Player>().Where(x => x.IsActive == true).ToList();
                players[currentPlayer].Name = players[currentPlayer].Name;
                players[currentPlayer].Score = players[currentPlayer].Score + 1;
                players[currentPlayer].TimesDrink = players[currentPlayer].TimesDrink;
                players[currentPlayer].IsActive = players[currentPlayer].IsActive;
                connection.Update(players[currentPlayer]);

                return players[currentPlayer].Score;
            }
        }

        public int DrinkPicked(int currentPlayer)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                var players = connection.Table<Player>().Where(x => x.IsActive == true).ToList();
                players[currentPlayer].Name = players[currentPlayer].Name;
                players[currentPlayer].Score = players[currentPlayer].Score;
                players[currentPlayer].TimesDrink = players[currentPlayer].TimesDrink + 1;
                players[currentPlayer].IsActive = players[currentPlayer].IsActive;
                connection.Update(players[currentPlayer]);

                return players[currentPlayer].Score;
            }
        }

        public List<Question> QuestionsToList()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Question>();
                var questions = connection.Table<Question>().ToList();
                return questions;
            }
        }

        public int CreateQuestion(Question question)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Question>();
                int insertedrows = connection.Insert(question);
                return insertedrows;
            }
        }

        public int UpdateQuestion(Question question)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Question>();
                int updatedrows = connection.Update(question);
                return updatedrows;
            }
        }

        public int DeleteQuestion(Question question)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Question>();
                int deletedrows = connection.Delete(question);
                return deletedrows;
            }
        }

        public List<Player> GetPlayers()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                var players = connection.Table<Player>().Where(x => x.IsActive == true).ToList();
                return players;
            }
        }

        public int SetUserInactive(string Player)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                var player = connection.Table<Player>().Where(x => x.Name == Player).FirstOrDefault(); ;
                player.Name = player.Name;
                player.Score = player.Score;
                player.TimesDrink = player.TimesDrink;
                player.IsActive = false;
                int updatedRows = connection.Update(player);

                return updatedRows;
            }
        }

        public int UpdateUser(User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();
                int updatedRows = connection.Update(user);
                return updatedRows;
            }
        }

    }
}
