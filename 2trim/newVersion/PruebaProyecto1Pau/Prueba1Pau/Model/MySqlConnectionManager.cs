using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1Pau.Model
{
    public class MySqlConnectionManager
    {
        private readonly string connectionString;

        public MySqlConnectionManager(string server, string database, string username, string password)
        {
            // Aquí puedes personalizar la cadena de conexión según tu configuración.
            connectionString = $"Server={server};Database={database};User={username};Password={password};";
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        public bool TestConnection()
        {
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }
    }
}
