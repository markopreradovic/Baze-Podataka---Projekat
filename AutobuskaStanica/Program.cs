using System;
using MySql.Data.MySqlClient;

namespace AutobuskaStanica
{
    internal static class Program
    {
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Prijava());
                
            

        }
    }
}