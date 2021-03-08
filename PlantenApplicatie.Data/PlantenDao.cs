using System;
using System.Collections.Generic;
using System.Linq;
using PlantenApplicatie.Domain;

namespace PlantenApplicatie.Data
{
    public class PlantenDao
    {
        private static readonly PlantenDao instance = new PlantenDao();

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
        
        public Plant GetPlantenByName(string name)
        {
            var plantenbyname = _context.Plant.FirstOrDefault(a => a.Fgsv == name);
            return plantenbyname;
        }

        /*
         * FAMILIE
         */

        public List<string> GetFamilies()
        {
            // return _context.TfgsvFamilie.ToList();

            var result = _context.TfgsvFamilie.Select(f => f.Familienaam).Distinct().ToList();

            return result;


        }

        /* 
         * TYPE
         */

        public List<TfgsvType> GetTypes()
        {
            return _context.TfgsvType.ToList();
        }

        /*
         * SOORT
         */

        public List<string> GetSoorten()
        {
            // return _context.TfgsvSoort.ToList();
            var result = _context.TfgsvSoort.Select(s => s.Soortnaam).Distinct().ToList();

            return result;
        }

        /*
         * GESLACHT
         */

        public List<string> GetGeslachten()
        {
            //return _context.TfgsvGeslacht.ToList();

            var result = _context.TfgsvGeslacht.Select(g => g.Geslachtnaam).Distinct().ToList();

            return result;
        }

        public List<Plant> ZoekPlantenOpNaam(string name)
        {
            return _context.Plant.Where(p => p.Fgsv == name).ToList();
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