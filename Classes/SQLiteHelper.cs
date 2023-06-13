using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokemonCardScraper.Classes
{
    public class SQLiteHelper
    {
        string? exPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string? dbPath = null;
        string fileName = "localDB.db";

        public SQLiteHelper() { }
        static public string GetConnectionString()
        {

            string path = Application.StartupPath + "Database\\localDB.db";
            Debug.WriteLine($"path is {path}");
            return $"Data Source={path};";
            //return $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={path};Integrated Security=True";
        }
        public void RunSQLQuery(string queryString)
        {
            Debug.WriteLine($"SQL query: {queryString}");
            try
            {
                using (SqliteConnection connection = new SqliteConnection(
                        GetConnectionString()))
                {

                    Debug.WriteLine(connection.Database);
                    Debug.WriteLine(queryString);
                    SqliteCommand command = new SqliteCommand(
                    queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class CardSQLiteHelper : SQLiteHelper
    {
        public CardSQLiteHelper() { }
        private string CardInsertQ()
        {
            string query = $"INSERT INTO [CardList] ([Name], [Number], [Set])" +
                $"VALUES (@n, @num, @set)";
            return query;
        }
        private string SetInsertQ()
        {
            string query = $"INSERT INTO [CardSets] ([Name])" +
                $"VALUES (@n)";
            return query;
        }

        public void AddCardSet(string name, int id)
        {
            string queryString = SetInsertQ();
            try
            {
                using (SqliteConnection connection = new SqliteConnection(
                        GetConnectionString()))
                {
                    SqliteCommand command = new SqliteCommand(
                    queryString, connection);
                    command.Parameters.AddWithValue("@n", name);
                    connection.Open();
                    command.ExecuteNonQuery();  
                    connection.Close();
                }
            }
            catch(Exception ex)
            {

            }
        } 
        public void AddCardToList(CardFormat.Card card)
        {
            string queryString = CardInsertQ();
            try
            {
                using (SqliteConnection connection = new SqliteConnection(
                        GetConnectionString()))
                {
                    SqliteCommand command = new SqliteCommand(
                    queryString, connection);
                    command.Parameters.AddWithValue("@n", card.Name);
                    command.Parameters.AddWithValue("@num", card.cardId);
                    command.Parameters.AddWithValue("@set", card.setID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
    
    }

}
