
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Personal_Accounting_System_WPFApp.Dtos;

namespace Personal_Accounting_System_WPFApp.Repositories
{
    class UserRolesRepository
    {
        public void CreateUserRole(UserRoleDto userRole)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                string query = "";
                conn.Open();
                query = $"INSERT INTO UserRoles (UserId, RoleId) VALUES ({userRole.UserId},  {userRole.RoleId})";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetUserRole(int userId)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                string query = $@"SELECT UserRoles.RoleId FROM UserRoles
                                    INNER JOIN Users ON UserRoles.UserId = Users.UserId
                                    WHERE Users.UserId = {userId}";
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return int.Parse(reader["RoleId"]?.ToString() ?? "0");
                    }
                }
                conn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }

            return 0;
        }

        public List<UserRoleDto> GetChild()
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };
            var childList = new List<UserRoleDto>();

            try
            {
                string query = "";
                conn.Open();
                query = @"select Users.Name, UserRoles.RoleId, Users.UserId from UserRoles
                            inner join Users on UserRoles.UserId = Users.UserId
                            where RoleId = 2 AND DisableTime IS NULL;";
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        childList.Add(new UserRoleDto
                        {
                            UserId = int.Parse(reader["UserId"]?.ToString() ?? "0"),
                            ChildName = reader["Name"]?.ToString(),
                            RoleId = int.Parse(reader["RoleId"]?.ToString() ?? "0")
                        });
                    }
                }
                conn.Close();
                return childList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return childList;
            }
        }

        public List<UserRoleDto> GetParents()
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            var parentsList = new List<UserRoleDto>();

            try
            {
                string query = "";
                conn.Open();
                query = @"select Users.Name, UserRoles.RoleId, Users.UserId from UserRoles
                            inner join Users on UserRoles.UserId = Users.UserId
                            where RoleId = 3 AND DisableTime IS NULL;";
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        parentsList.Add(new UserRoleDto
                        {
                            UserId = int.Parse(reader["UserId"]?.ToString() ?? "0"),
                            ParentName = reader["Name"]?.ToString(),
                            RoleId = int.Parse(reader["RoleId"]?.ToString() ?? "0")
                        });
                    }
                }
                conn.Close();
                return parentsList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return parentsList;
            }
        }
    }
}
