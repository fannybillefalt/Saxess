using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Övning_Frisörsalong_Saxess
{

    internal class DbManager
    {
        private static readonly string _connection = @"Server = localhost; Database = Saxess_DB; Integrated Security = true; Trust Server Certificate = true;";



        public static void AddBoking(int eId, int cId, int tId, DateTime bDate)
        {
            using (var connection = new SqlConnection(_connection))
            {
                string query = "INSERT INTO Bookings(EmployeeId, CustomerId, TreatmentId, BookingDate) " +
                    " VALUES( " +
                    " @EId, @CId, @TId, @BDate)";


                string e = eId.ToString();
                string c = cId.ToString();
                string t = tId.ToString();
                string b = bDate.ToString();



                var dict = new Dictionary<string, string>
                {
                    {"@EId",e },
                    {"CId",c },
                    {"@TId",t },
                    {"@BDate",b }
                };


                Test(query,connection,dict);
                
                //using(var command = new SqlCommand(query, connection))
                //{
                //    try
                //    {
                //    connection.Open();
                //    command.Parameters.AddWithValue("EId", eId);
                //    command.Parameters.AddWithValue( "CId", cId);
                //    command.Parameters.AddWithValue("TId", tId);
                //    command.Parameters.AddWithValue("BDate", bDate);
                //    //command.ExecuteNonQuery();
                //    Console.WriteLine($"Bokning genomförd \nRader påverkade {command.ExecuteNonQuery()}");
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //}
            }
        }
            //DENNA KOD SKRIVER UT QUERY I KONSOLEN
        public static void ExecuteQuery(string query)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                try
                {
                    using(var reader = command.ExecuteReader())
                    {   //SKRIVER UT KOLUMNER
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i),-20}");
                        }

                        Console.WriteLine();

                        while (reader.Read())
                        {   //SKRIVER UT VALUE
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetValue(i), -20}");
                            }

                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                connection.Close();

            }
        }
        public static void BookingBetweenDates(string from, string to )
        {
            using (var connection = new SqlConnection(_connection))
            {
                string query = "EXEC SearchBetweenDates @FromDates, @EndDates";
                var dict = new Dictionary<string, string>
                {
                    {"@FromDates", from},
                    {"@EndDates", to }
                };
                Test(query, connection, dict);

                //using (var command = new SqlCommand(query, connection))
                //{
                //    command.Parameters.AddWithValue("@FromDates", from);
                //    command.Parameters.AddWithValue("@EndDates", to);
                //    try
                //    {
                //        connection.Open();
                //        using (var reader = command.ExecuteReader())
                //        {   //SKRIVER UT KOLUMNER
                //            for (int i = 0; i < reader.FieldCount; i++)
                //            {
                //                Console.Write($"{reader.GetName(i),-20}");
                //            }

                //            Console.WriteLine();

                //            while (reader.Read())
                //            {   //SKRIVER UT VALUE
                //                for (int i = 0; i < reader.FieldCount; i++)
                //                {
                //                    Console.Write($"{reader.GetValue(i),-20}");
                //                }

                //                Console.WriteLine();
                //            }
                //        }

                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //        throw;
                //    }
                //}
                              
            }

        }

        public static void Test(string query, SqlConnection conn, Dictionary<string,string> parameters)
        {
            using (var command = new SqlCommand(query, conn))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
                conn.Open();
                Read(command);
            }
        }

        public static void TestINT(string query, SqlConnection conn, Dictionary<string, int> parameters)
        {
            using (var command = new SqlCommand(query, conn))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
                conn.Open();
                Read(command);
            }
        }

        public static void Read(SqlCommand command)
        {
            using (var reader = command.ExecuteReader())
            {   //SKRIVER UT KOLUMNER
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetName(i),-20}");
                }

                Console.WriteLine();

                while (reader.Read())
                {   //SKRIVER UT VALUE
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader.GetValue(i),-20}");
                    }

                    Console.WriteLine();
                }
            }
        }

        //public static void SeeEmployee
    }
}
