using System;
using System.Data.SqlClient;

namespace Danair
{
    class Program
    {
        static void Main(string[] args)
        {
            Kunde.ListKunder();

            Console.WriteLine("Indtast et kundenummer: ");
            int kundenummer = int.Parse(Console.ReadLine());

            Kunde Kunde1 = new Kunde(kundenummer);
            Kunde1.GetAdresse();
        }

        
    }
}
