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
            
            PrintPlanten(_plantenDao.SearchPlantenByProperties("abc", "FABACEAE", "Baptisia", 
                "australis", "'Twilight Prairieblues'"));
            //PrintPlanten(_plantenDao.GetPlanten());
            //PrintPlanten(_plantenDao.SearchPlantenByName("   vero"));
        }

        private static void PrintPlanten(List<Plant> planten)
        {
            foreach (var plant in planten)
            {
                Console.WriteLine($"{plant.Fgsv}");
            }
        }
    }
}