using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Logics
{
    public static class BaseMethod
    {
        public static String CheckContext(List<string> words, string ContextLabel, string nameTable, List<string> Parametrs)
        {
            string connectionString = @"Data Source=DESKTOP-GO0Q29L;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string context = "";
            String sqlExpression1 = $"SELECT TOP (1) ";
            for (int i = 0; i < Parametrs.Count - 1; i++)
            {
                sqlExpression1 += $"{Parametrs[i]},";
            }
            sqlExpression1 += Parametrs[Parametrs.Count - 1];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var word in words)
                {
                    var newWord = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();

                    var sqlExpression = sqlExpression1+ $"  from CASE_IN.{ nameTable} WHERE { ContextLabel} = '{newWord}'";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    if (command.ExecuteScalar() != null)
                    {
                        context = command.ExecuteScalar().ToString();
                        break;
                    }
                    words.Remove(context);
                }
            }
            return context;

        }
    }
}