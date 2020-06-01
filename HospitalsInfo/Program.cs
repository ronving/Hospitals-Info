using System;
using HospitalsInfo.ConsoleIO;
using HospitalsInfo.ConsoleUI;
using HospitalsInfo.Data;

namespace HospitalsInfo
{
    class Program
    {
        static DataContext dataContext;
        static MainManager mainManager;

        static void Main(string[] args) {
            Console.Title = "HospitalsInfo (Ольховий М.В.)";
            Settings.SetConsoleParam();
            Console.WriteLine("Реалізація класів для предметної області");

            dataContext = new DataContext();
            mainManager = new MainManager(dataContext);
            mainManager.Run();

            //Console.ReadKey(true);
        }
    }
}
