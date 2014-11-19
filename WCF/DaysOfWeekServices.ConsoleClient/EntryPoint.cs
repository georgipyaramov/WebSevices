namespace DaysOfWeekServices.ConsoleClient
{
    using DaysOfWeekServicesReference;
    using System;
    public class EntryPoint
    {
        static void Main()
        {
            //This class comes from the Service Reference
            var client = new DaysOfWeekServiceClient();

            var testDate = DateTime.Now.AddDays(-1);
            Console.WriteLine("Test date: " + testDate.ToString());
            Console.WriteLine("You can change the test date in the code.");

            Console.WriteLine("Press any key to get the day of week.");
            Console.ReadKey();

            var day = client.GetDayOfWeek(testDate);

            Console.WriteLine(day);

            client.Close();
        }
    }
}
