using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1Pau.Model
{
    public class MyDataAccess
    {
        private readonly MySqlConnectionManager connectionManager;

        public MyDataAccess(string server, string database, string username, string password)
        {
            connectionManager = new MySqlConnectionManager(server, database, username, password);
        }

        public List<string> ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            List<string> result = new List<string>();

            using (MySqlConnection connection = connectionManager.GetConnection())
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Puedes ajustar esto según la estructura de tu consulta y base de datos
                                string data = reader[0].ToString();
                                result.Add(data);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                }
            }

            return result;
        }

        public List<string> GetTableData(string tableName, string columnName)
        {
            List<string> result = new List<string>();

            using (MySqlConnection connection = connectionManager.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM " + tableName + ";";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string data = reader[columnName].ToString(); 
                                result.Add(data);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Manejar excepciones según tus necesidades
                    Console.WriteLine($"Error al obtener datos: {ex.Message}");
                }
            }
            return result;
        }
    }
}
