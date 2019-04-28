using Personal_Accounting_System_WPFApp.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Accounting_System_WPFApp.Repositories
{
    class OtherEntitiesRepository
    {
        public void AddOtherEntities(OtherEntitiesDto otherEntities)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");

                string query = $"INSERT INTO OtherEntities (Id, EntitiesName) VALUES ({otherEntities.OtherEntitiesId},'{otherEntities.OtherEntitiesName}')";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public List<OtherEntitiesDto> GetOtherEntities()
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            var otherEntitiesList = new List<OtherEntitiesDto>();

            try
            {
                string query = "";
                conn.Open();
                query = "SELECT Id, EntitiesName FROM OtherEntities WHERE DisableTime IS NULL;";
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        otherEntitiesList.Add(new OtherEntitiesDto
                        {
                            OtherEntitiesId = int.Parse(reader["Id"]?.ToString()?? "0"),
                            OtherEntitiesName = reader["EntitiesName"]?.ToString()
                        });
                    }
                }
                conn.Close();
                return otherEntitiesList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return otherEntitiesList;
            }
        }

        public int GetOtherEntitiesId(string otherEntitiesName)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                string query = "";
                conn.Open();
                query = $"SELECT Id FROM OtherEntities WHERE EntitiesName = '{otherEntitiesName}' AND DisableTime IS NULL;";
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return int.Parse(reader["Id"]?.ToString() ?? "0");
                    }
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        public void ModifyOtherEntities(OtherEntitiesDto otherEntities)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");
                string query = $"UPDATE OtherEntities SET EntitiesName = '{otherEntities.OtherEntitiesName}' WHERE Id = {otherEntities.OtherEntitiesId}";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisableOtherEntities(OtherEntitiesDto otherEntities)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                conn.Open();
                Console.WriteLine("Database Connected");

                SqlCommand command = new SqlCommand("UPDATE OtherEntities SET DisableTime = @date Where Id = @otherEntitiesId", conn);
                command.Parameters.AddWithValue("@date", otherEntities.DisableTime);
                command.Parameters.AddWithValue("@otherEntitiesId", otherEntities.OtherEntitiesId);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
