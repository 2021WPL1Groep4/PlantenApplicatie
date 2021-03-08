using System;
using System.Collections.Generic;
using System.Linq;
using PlantenApplicatie.Domain;

namespace PlantenApplicatie.Data
{
    public class PlantenDao
    {
        public static readonly PlantenDao instance = new PlantenDao();

        public static PlantenDao Instance()
        {
            return instance;
        }

        private PlantenDao()
        {
            this._context = new PlantenContext();
        }

        private PlantenContext _context;

        /*
         * PLANT
         */

        public List<Plant> GetPlanten()
        {
            return _context.Plant.ToList();
        }
        
        public Plant getPlantenByName(string name)
        {
            var plantenbyname = _context.Plant.FirstOrDefault(a => a.Fgsv == name);
            return plantenbyname;
        }

        /*
         * FAMILIE
         */

        public List<TfgsvFamilie> getFamilies()
        {
            return _context.TfgsvFamilie.ToList();
        }

        /* 
         * TYPE
         */

        public List<TfgsvType> getTypes()
        {
            return _context.TfgsvType.ToList();
        }

        /*
         * SOORT
         */

        public List<TfgsvSoort> getSoorten()
        {
            return _context.TfgsvSoort.ToList();
        }

        /*
         * GESLACHT
         */

        public List<TfgsvGeslacht> getGeslachten()
        {
            return _context.TfgsvGeslacht.ToList();
        }

        /*
        private IEnumerable<Plant> SearchPlantenByProperty(Func<Plant, string> property, string propertyValue)
        {
            return GetPlanten().Where(p =>
                    property(p) is not null 
                    && PlantenParser.ParseSearchText(property(p))
                        .Contains(PlantenParser.ParseSearchText(propertyValue)))
                .OrderBy(property);
        }
        
        public IEnumerable<Plant> SearchPlantenByName(string name)
        {
            return SearchPlantenByProperty(p => p.Fgsv, name);
        }

        public IEnumerable<Plant> SearchPlantenByFamily(string family)
        {
            return SearchPlantenByProperty(p => p.Familie, family);
        }

        public IEnumerable<Plant> SearchPlantenByGenus(string genus)
        {
            return SearchPlantenByProperty(p => p.Geslacht, genus);
        }

        public IEnumerable<Plant> SearchPlantenBySpecies(string species)
        {
            return SearchPlantenByProperty(p => p.Soort, species);
        }

        public IEnumerable<Plant> SearchPlantenByVariant(string variant)
        {
            return SearchPlantenByProperty(p => p.Variant, variant);
        }
        */
    }
}