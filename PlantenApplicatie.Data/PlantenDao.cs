using System;
using System.Collections.Generic;
using System.Linq;
using PlantenApplicatie.Domain;

namespace PlantenApplicatie.Data
{
    public class PlantenDao
    {
        private readonly PlantenContext _context;

        static PlantenDao()
        {
            Instance = new PlantenDao();
        }

        private PlantenDao()
        {
            _context = new PlantenContext();
        }

        public static PlantenDao Instance { get; }

        public List<Plant> GetPlanten()
        {
            return _context.Plant.ToList();
        }
        
        private List<Plant> SearchPlantenByProperty(Func<Plant, string> property, string propertyValue)
        {
            return GetPlanten().Where(p =>
                    property(p) is not null 
                    && PlantenParser.ParseSearchText(property(p))
                        .Contains(PlantenParser.ParseSearchText(propertyValue)))
                .OrderBy(property).ToList();
        }
        
        public List<Plant> SearchPlantenByName(string name)
        {
            return SearchPlantenByProperty(p => p.Fgsv, name);
        }

        public List<Plant> SearchPlantenByFamily(string family)
        {
            return SearchPlantenByProperty(p => p.Familie, family);
        }

        public List<Plant> SearchPlantenByGenus(string genus)
        {
            return SearchPlantenByProperty(p => p.Geslacht, genus);
        }

        public List<Plant> SearchPlantenBySpecies(string species)
        {
            return SearchPlantenByProperty(p => p.Soort, species);
        }

        public List<Plant> SearchPlantenByVariant(string variant)
        {
            return SearchPlantenByProperty(p => p.Variant, variant);
        }
    }
}