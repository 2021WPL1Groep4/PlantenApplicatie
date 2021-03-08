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
        
        public List<Plant> SearchPlantenByName(string name)
        {
            return GetPlanten().Where(p =>
                    p.Fgsv is not null 
                    && PlantenParser.ParseSearchText(p.Fgsv)
                        .Contains(PlantenParser.ParseSearchText(name)))
                .OrderBy(p => p.Fgsv).ToList();
        }

        public List<Plant> SearchPlantenByFamily(string family)
        {
            return GetPlanten().Where(p =>
                    p.Familie is not null 
                    && PlantenParser.ParseSearchText(p.Familie)
                        .Contains(PlantenParser.ParseSearchText(family)))
                .OrderBy(p => p.Familie).ToList();
        }

        public List<Plant> SearchPlantenByGenus(string genus)
        {
            return GetPlanten().Where(p =>
                    p.Geslacht is not null 
                    && PlantenParser.ParseSearchText(p.Geslacht)
                        .Contains(PlantenParser.ParseSearchText(genus)))
                .OrderBy(p => p.Geslacht).ToList();
        }

        public List<Plant> SearchPlantenBySpecies(string species)
        {
            return GetPlanten().Where(p =>
                    p.Soort is not null 
                    && PlantenParser.ParseSearchText(p.Soort)
                        .Contains(PlantenParser.ParseSearchText(species)))
                .OrderBy(p => p.Soort).ToList();
        }

        public List<Plant> SearchPlantenByVariant(string variant)
        {
            return GetPlanten().Where(p =>
                    p.Variant is not null 
                    && PlantenParser.ParseSearchText(p.Variant)
                        .Contains(PlantenParser.ParseSearchText(variant)))
                .OrderBy(p => p.Variant).ToList();
        }
    }
}