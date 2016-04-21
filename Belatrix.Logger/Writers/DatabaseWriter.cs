using System.Configuration;
using System.Data.SqlClient;

namespace Belatrix.Logger.Writers
{
    public class DatabaseWriter : ILogWriter
    {
        public void Write(string message, MessageType messageType)
        {
            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            using (var command = new SqlCommand("Insert into Log (Message, MessageType) Values(@Message, @MessageType)", connection))
            {
                command.Parameters.AddWithValue("@Message", message);
                command.Parameters.AddWithValue("@MessageType", (int)messageType);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();    
            }
        }
    }
}
