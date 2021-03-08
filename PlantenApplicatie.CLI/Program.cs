﻿using PlantenApplicatie.Data;
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
            
            // this is broken because implementation change
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