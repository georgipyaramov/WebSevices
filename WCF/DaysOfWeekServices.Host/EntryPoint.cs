namespace DaysOfWeekServices.Host
{
    using System;
    using System.ServiceModel;

    using DaysOfWeekServices;

    public class EntryPoint
    {
        static void Main()
        {
            var url = "http://127.0.0.1:8888";

            ServiceHost host = new ServiceHost(typeof(DaysOfWeekService), new Uri(url));

            host.Open();

            Console.WriteLine("Service working on {0}", url);

            Console.ReadKey();

            host.Close();
        }
    }
}
