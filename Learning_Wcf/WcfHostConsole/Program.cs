using System;
using System.ServiceModel;
using MyWcfServiceLibrary.Basic;

namespace WcfHostConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof (BasicService));

            host.Open();

            Console.WriteLine("Hosting...");
            Console.ReadLine();

            host.Close();
        }
    }
}