using System.Collections.Generic;
using System.Linq;
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
            return _context.Plant
                .ToList();
        }

        public List<Plant> SearchPlantenByProperties(string name, string type, string family, string genus, 
            string species, string variant)
        {
            return SearchPlantsWithTgsvAndName(
                SearchFullTfgsvVariants(type, family, genus, species, variant), name);
        }

        private List<TfgsvVariant> SearchFullTfgsvVariants(string type, string family, string genus,
            string species, string variant)
        {
            return _context.TfgsvVariant
                .Include(v => v.SoortSoort.GeslachtGeslacht.FamilieFamile.TypeType)
                .ToList()
                .Where(v =>
                    PlantenParser.ParseSearchText(v.Variantnaam)
                        .Contains(PlantenParser.ParseSearchText(variant)) 
                    && PlantenParser.ParseSearchText(v.SoortSoort.Soortnaam)
                        .Contains(PlantenParser.ParseSearchText(species))
                    && PlantenParser.ParseSearchText(v.SoortSoort.GeslachtGeslacht.Geslachtnaam)
                        .Contains(PlantenParser.ParseSearchText(genus))
                    && PlantenParser.ParseSearchText(v.SoortSoort.GeslachtGeslacht.FamilieFamile.Familienaam)
                        .Contains(PlantenParser.ParseSearchText(family))
                    && PlantenParser.ParseSearchText(v.SoortSoort.GeslachtGeslacht.FamilieFamile.TypeType.Planttypenaam)
                        .Contains(PlantenParser.ParseSearchText(type)))
                .ToList();
        }

        private List<Plant> SearchPlantsWithTgsvAndName(List<TfgsvVariant> variants, string name)
        {
            return _context.Plant
                .ToList()
                .Where(p => 
                    p.VariantId != null && variants.Select(v => v.VariantId)
                        .Contains((long)p.VariantId) 
                    && variants
                        .Select(v => v.SoortSoort.Soortid)
                        .Contains((long)p.SoortId!) 
                    && variants
                        .Select(v => v.SoortSoort.GeslachtGeslacht.GeslachtId)
                        .Contains((long)p.GeslachtId!) 
                    && variants
                        .Select(v => v.SoortSoort.GeslachtGeslacht.FamilieFamile.FamileId)
                        .Contains((long)p.FamilieId!) 
                    && PlantenParser.ParseSearchText(p.Fgsv)
                        .Contains(PlantenParser.ParseSearchText(name)))
                .OrderBy(p => p.Fgsv)
                .ToList();
        }

        public List<string> GetUniqueFamilyNames()
        {
            return _context.TfgsvFamilie
                .Select(f => f.Familienaam)
                .Distinct()
                .ToList();
        }

        public List<string> GetUniqueGenusNames()
        {
            return _context.TfgsvGeslacht
                .Select(g => g.Geslachtnaam)
                .Distinct()
                .ToList();
        }

        public List<string> GetUniqueSpeciesNames()
        {
            return _context.TfgsvSoort
                .Select(s => s.Soortnaam)
                .Distinct()
                .ToList();
        }

        public List<TfgsvType> GetTypes()
        {
            return _context.TfgsvType
                .ToList();
        }
    }
}