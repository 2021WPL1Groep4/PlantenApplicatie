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
        
        public List<Planten2021> GetPlantenByName(string name) {
            return _context.Planten2021.Where(p => 
                    p.Plantnaam.ToLower().Replace("'", "")
                        .Contains(name.Trim().ToLower().Replace("'", "")))
                .OrderBy(p => p.Plantnaam)
                .ToList();
        }

        public List<Planten2021> GetPlantenByFamily(string family)
        {
            return _context.Planten2021.Where(p =>
                    p.Familie.ToLower()
                        .Contains(family.Trim().ToLower()))
                .OrderBy(p => p.Familie)
                .ToList();
        }

        public List<Planten2021> GetPlantenByGeslacht(string name)
        {
            return _context.Planten2021.Where(p => 
                    p.Geslacht.ToLower()
                        .Contains(name.Trim().ToLower().Replace("'","")))
                .OrderBy(p => p.Geslacht)
                .ToList();
        }

        public List<Planten2021> GetPlantenBySoort(string name)
        {
            return _context.Planten2021.Where(p => 
                    p.Soort.ToLower()
                        .Contains(name.Trim().ToLower().Replace("'", "")))
                .OrderBy(p => p.Soort)
                .ToList();
        }

        public List<Planten2021> GetPlantenByVariant(string name)
        {
            return _context.Planten2021.Where(p => 
                    p.Variant.ToLower().Replace("'", "")
                        .Contains(name.Trim().ToLower().Replace("'", "")))
                .OrderBy(p => p.Variant)
                .ToList();
        }

    }
}