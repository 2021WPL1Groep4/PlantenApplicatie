using System.Collections.Generic;
using System.Linq;
using PlantenApplicatie.Domain;

namespace PlantenApplicatie.Data
{
    public class PlantenDao
    {
        private static readonly PlantenDao _instance;
        private PlantenContext _context;

        static PlantenDao()
        {
            _instance = new PlantenDao();
        }

        private PlantenDao()
        {
            _context = new PlantenContext();
        }

        public static PlantenDao Instance => _instance;

        public List<Planten2021> GetPlanten()
        {
            return _context.Planten2021.ToList();
        }
    }
}