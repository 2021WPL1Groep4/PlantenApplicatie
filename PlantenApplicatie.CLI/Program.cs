using PlantenApplicatie.Data;
using PlantenApplicatie.Domain;
using System;
using System.Linq;

namespace PlantenApplicatie.CLI
{
    class Program
    {
        private static PlantenContext _context;

        static void Main(string[] args)
        {
            _context = new PlantenContext();

            PrintPlanten();
        }

        static void PrintPlanten()
        {
            var planten = _context.Planten2021.ToList();
            
            foreach (var plant in planten)
            {
                Console.WriteLine($"The plant name is {plant.Plantnaam}");
            }
        }
    }
}
