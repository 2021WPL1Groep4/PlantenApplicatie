using PlantenApplicatie.Data;
using PlantenApplicatie.Domain;
using System;
using System.Collections.Generic;

namespace PlantenApplicatie.CLI
{
    class Program
    {
        private static PlantenDao _plantenDao;

        static void Main(string[] args)
        {
            _plantenDao = PlantenDao.Instance;

            PrintPlanten(_plantenDao.SearchPlantenByName("Veronicastrum"));
        }

        private static void PrintPlanten(IEnumerable<Plant> planten)
        {
            foreach (var plant in planten)
            {
                Console.WriteLine($"{plant.Fgsv}");
            }
        }
    }
}
