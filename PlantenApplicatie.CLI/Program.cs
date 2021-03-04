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

            PrintPlanten(_plantenDao.GetPlantenByName("hakonechloa"));
        }

        static void PrintPlanten(List<Planten2021> planten)
        {
            foreach (var plant in planten)
            {
                Console.WriteLine($"The plant name is: {plant.Plantnaam}");
            }
        }
    }
}
