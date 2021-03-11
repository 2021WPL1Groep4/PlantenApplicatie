using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
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

        public List<Plant> SearchPlantenByProperties(string name, string family, 
            string genus, string species, string variant)
        { 
            //planten = GetName(planten, name);
            var familyIds = GetFamilyId(family);
            var genusIds = GetGenusId(genus);
            var speciesIds = GetSpeciesId(species);
            var variantIds = GetVariantId(variant);

            return _context.Plant.ToList()
                .Where(p => true // remove "true" and write your own Where to check properly
                    /* */)
                .OrderBy(p => p.Fgsv)
                .ToList();
        }

        private static long GetName(List<Plant> planten, string name)
        {
            return 0;
        }

        private List<long>? GetFamilyId(string family)
        {
            if (string.IsNullOrEmpty(family))
            {
                return null;
            }
            
            var familyIds = _context.TfgsvFamilie.ToList()
                .Where(f =>
                    PlantenParser.ParseSearchText(f.Familienaam).Contains(
                        PlantenParser.ParseSearchText(family)))
                .Select(f => f.FamileId)
                .ToList();
        }

        private List<long>? GetGenusId(string genus) 
        {
            if (string.IsNullOrEmpty(genus))
            {
                return null;
            }
            
            return _context.TfgsvGeslacht.ToList()
                .Where(g =>
                PlantenParser.ParseSearchText(g.Geslachtnaam).Contains(
                    PlantenParser.ParseSearchText(genus)))
                .Select(g => g.GeslachtId)
                .ToList();
        }

        private List<long>? GetSpeciesId(string species)
        {
            if (string.IsNullOrEmpty(species))
            {
                return null;
            }
            
            return _context.TfgsvSoort.ToList()
                .Where(s =>
                PlantenParser.ParseSearchText(s.Soortnaam).Contains(
                    PlantenParser.ParseSearchText(species)))
                .Select(s => s.Soortid)
                .ToList();
        }

        private List<long>? GetVariantId(string variant)
        {
            if (string.IsNullOrEmpty(variant))
            {
                return null;
            }
            
            return _context.TfgsvVariant.ToList()
                .Where(v =>
                PlantenParser.ParseSearchText(v.Variantnaam).Contains(
                    PlantenParser.ParseSearchText(variant)))
                .Select(v => v.SoortSoortid)
                .ToList();
        }

        public List<string> GetUniqueFamilyNames()
        {
            return _context.TfgsvFamilie.Select(f => f.Familienaam).Distinct().ToList();
        }

        public List<string> GetUniqueGenusNames()
        {
            return _context.TfgsvGeslacht.Select(g => g.Geslachtnaam).Distinct().ToList();
        }

        public List<string> GetUniqueSpeciesNames()
        {
            return _context.TfgsvSoort.Select(s => s.Soortnaam).Distinct().ToList();
        }

        public List<TfgsvType> GetTypes()
        {
            return _context.TfgsvType.ToList();
        }
    }
}