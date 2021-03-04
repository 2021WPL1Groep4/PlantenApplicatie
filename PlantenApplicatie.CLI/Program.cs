using PlantenApplicatie.Data;
using PlantenApplicatie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantenApplicatie.CLI
{
    class Program
    {
        private static PlantenDao _plantenDao;

        static void Main(string[] args)
        {
            _plantenDao = PlantenDao.Instance;

            PrintPlanten(_plantenDao.GetPlantenByName("vinca minor"));
        }

        private static void PrintPlanten(List<Plant> planten)
        {
            foreach (var plant in planten)
            {
                Console.WriteLine($"{plant.Fgsv}:");
                /*Console.WriteLine($"\tFamilie: {plant.Familie}");
                Console.WriteLine($"\tGeslacht: {plant.Geslacht}");
                Console.WriteLine($"\tSoort: {plant.Soort}");
                Console.WriteLine($"\tVariant: {plant.Variant}\n");*/
            }
        }
    }
}
