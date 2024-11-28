using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DemoLib.Models
{
    public class MySQLClientsModel : IClientsModel
    {
        string connectionString = "Server=localhost;User ID=root;Password=vertrigo;Database=ClientBase\r\n";

        public event Action UpdatedClients;

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, Name, PhoneNumber, Director, Type, Rating FROM Clients";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                ID = reader.GetInt32("ID"),
                                Name = reader.GetString("Name"),
                                PhoneNumber = reader.GetString("PhoneNumber"),
                                Director = reader.GetString("Director"),
                                Type = reader.GetString("Type"),
                                Rating = reader.GetInt32("Rating"),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return clients;
        }

        public int ClientCount()
        {
            int count = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Clients";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return count;
        }

        public DataTable GetProducts()
        {
            DataTable productsTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID, NameProduct, PriceProduct, Count, SumProduct FROM Products";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.Fill(productsTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return productsTable;
        }
    }
}
