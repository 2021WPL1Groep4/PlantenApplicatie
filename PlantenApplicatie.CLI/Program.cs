using PlantenApplicatie.Data;
using PlantenApplicatie.Domain;
using System;
using System.Linq;

namespace PlantenApplicatie.CLI
{
    class Program
    {
        private static PlantenDao _plantenDao;

        static void Main(string[] args)
        {
            _plantenDao = PlantenDao.Instance;

            PrintPlanten();
        }

        static void PrintPlanten()
        {
            foreach (var plant in _plantenDao.GetPlanten())
            {
                Console.WriteLine($"The plant name is {plant.Plantnaam}");
            }
        }
    }
}
