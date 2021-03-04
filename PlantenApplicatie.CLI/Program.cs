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

            // PrintPlanten(_plantenDao.GetPlanten());

            //PrintPlanten(_plantenDao.GetPlantenByName("hakonechloa"));

            PrintPlanten(_plantenDao.GetPlantenByName("baptisia"));

            _plantenDao.GetPlantenByName("baptisia");

            //PrintPlanten(_plantenDao.GetPlantenByFamily("fabaceae"));
        }

        static void PrintPlanten(List<Planten2021> planten)
        {
            foreach (var plant in planten)
            {
                Console.WriteLine($"{plant.Plantnaam}:");
                Console.WriteLine($"\tFamilie: {plant.Familie}");
                Console.WriteLine($"\tGroep: {plant.Groep}");
                Console.WriteLine($"\tGeslacht: {plant.Geslacht}");
                Console.WriteLine($"\tSoort: {plant.Soort}");
                Console.WriteLine($"\tVariant: {plant.Variant}\n");
            }
        }
    }
}
