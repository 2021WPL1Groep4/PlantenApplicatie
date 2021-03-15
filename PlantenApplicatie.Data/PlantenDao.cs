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

        public List<Plant> SearchByProperties(string name,string type, string family, 
            string genus, string species, string variant)
        {
            var planten = GetPlanten();

            
            planten = SearchPlantenByName(planten, name);
            planten = SearchPlantenByType(planten, type);
            planten = SearchPlantenByFamily(planten, family);
            planten = SearchPlantenByGenus(planten, genus);
            planten = SearchPlantenBySpecies(planten, species);
            planten = SearchPlantenByVariant(planten, variant);

            return planten.OrderBy(p => p.Fgsv).ToList();
        }
        
        public List<Plant> SearchPlantenByName(List<Plant> planten, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return planten;
            }

            return planten.Where(p =>
                    p.Fgsv is not null 
                    && PlantenParser.ParseSearchText(p.Fgsv)
                        .Contains(PlantenParser.ParseSearchText(name)))
                .ToList();
        }
        public List<Plant> SearchPlantenByType(List<Plant> planten , string type)
        {
            if(string.IsNullOrEmpty(type))
            {
                return planten;
            }

            return planten.Where(p => p.Type is not null && PlantenParser.ParseSearchText(p.Type).Contains(PlantenParser.ParseSearchText(type))).ToList();

         
        }
        public List<Plant> SearchPlantenByFamily(List<Plant> planten, string family)
        {
            if (string.IsNullOrEmpty(family))
            {
                return planten;
            }

            return planten.Where(p =>
                    p.Familie is not null 
                    && PlantenParser.ParseSearchText(p.Familie)
                        .Contains(PlantenParser.ParseSearchText(family)))
                .ToList();
        }

        public List<Plant> SearchPlantenByGenus(List<Plant> planten, string genus)
        {
            if (string.IsNullOrEmpty(genus))
            {
                return planten;
            }

            return planten.Where(p =>
                    p.Geslacht is not null 
                    && PlantenParser.ParseSearchText(p.Geslacht)
                        .Contains(PlantenParser.ParseSearchText(genus)))
                .ToList();
        }

        public List<Plant> SearchPlantenBySpecies(List<Plant> planten, string species)
        {
            if (string.IsNullOrEmpty(species))
            {
                return planten;
            }

            return planten.Where(p =>
                    p.Soort is not null 
                    && PlantenParser.ParseSearchText(p.Soort)
                        .Contains(PlantenParser.ParseSearchText(species)))
                .ToList();
        }

        public List<Plant> SearchPlantenByVariant(List<Plant> planten, string variant)
        {
            if (string.IsNullOrEmpty(variant))
            {
                return planten;
            }

            return planten.Where(p =>
                    p.Variant is not null 
                    && PlantenParser.ParseSearchText(p.Variant)
                        .Contains(PlantenParser.ParseSearchText(variant)))
                .ToList();
        }

        public List<string> GetUniqueFamilyNames()
        {
            return _context.TfgsvFamilie.Select(f => f.Familienaam).Distinct().OrderBy(familienaam => familienaam).ToList();
                       
        }

        public List<TfgsvGeslacht> GetUniqueGenusNames()
        {
            return _context.TfgsvGeslacht.OrderBy(g => g.Geslachtnaam).ToList();
        }

        public List<TfgsvSoort> GetUniqueSpeciesNames()
        {
            return _context.TfgsvSoort.OrderBy(s => s.Soortnaam).ToList();
        }

        public List<TfgsvVariant> GetUniqueVariantNames()
        {
            return _context.TfgsvVariant.OrderBy(v => v.Variantnaam).ToList();
        }

        public List<TfgsvType> GetTypes()
        {
            return _context.TfgsvType.OrderBy(o => o.Planttypenaam).ToList();
        }
    }
}