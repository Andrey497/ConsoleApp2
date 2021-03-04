using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Logics
{
    public static class BaseMethod
    {
        public static String CheckContext(List<string> words, List<string> ContextLabel, string nameTable, List<string> Parametrs)
        {
            string connectionString = @"Data Source=DESKTOP-GO0Q29L;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string context = "";
            String sqlExpression1 = $"SELECT TOP (1) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var word in words)
                {
                    var newWord = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
                    var sqlExpression = "";
                    if (ContextLabel.Count != 1)
                    {
                         sqlExpression = sqlExpression1 + $"{Parametrs[0]} from CASE_IN.{ nameTable} WHERE { String.Join($"={newWord} OR ", ContextLabel)}";
                    }else
                    {
                         sqlExpression = sqlExpression1 + $"{Parametrs[0]} from CASE_IN.{ nameTable} WHERE {ContextLabel.First()} ={newWord} ";
                    }
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    if (command.ExecuteScalar() != null)
                    {
                        context = command.ExecuteScalar().ToString();
                        for (int i = 1; i < Parametrs.Count ; i++)
                        {
                            sqlExpression = sqlExpression1 + $"{Parametrs[i]} from CASE_IN.{ nameTable} WHERE { ContextLabel} = '{newWord}'";
                            command = new SqlCommand(sqlExpression, connection);
                            context +="," + command.ExecuteScalar().ToString();
                          
                        }
                        break;
                    }

                }
            }
            return context;

        }
    }
}
