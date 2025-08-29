using System;
using Ead2808.Data;
using Ead2808.Service;

namespace Ead2808
{
    class Program
    {
        static void Main(string[] args)
        {
            string ms = @"Server=DESKTOP-IKNFPRS;Database=EscolaDB;Integrated Security=True;TrustServerCertificate=True;";

            Db.ConnectionString = ms;

            var service = new MatriculaService();
            service.Executar();

            Console.WriteLine("\n✅ Programa finalizado com sucesso!");
            Console.ReadKey();
        }
    }
}
