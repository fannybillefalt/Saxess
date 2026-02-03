namespace Övning_Frisörsalong_Saxess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string query = "SELECT * FROM Customers";
            //DbManager.ExecuteQuery(query);

            //DbManager.BookingBetweenDates("2025-01-01", "2026-02-03");

            var date = DateTime.Now.ToString();
            DbManager.AddBoking("3", "3", "2", date);
        }
    }
}
