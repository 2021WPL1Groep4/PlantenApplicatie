using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using PlantenApplicatie.Domain;

namespace PlantenApplicatie.Data
{
    public class PlantenDao
    {
        private static readonly PlantenDao DaoInstance;
        private PlantenContext _context;

        static PlantenDao()
        {
            DaoInstance = new PlantenDao();
        }

        private PlantenDao()
        {
            _context = new PlantenContext();
        }

        public static PlantenDao Instance => DaoInstance;

        public List<Plant> GetPlanten()
        {
            return _context.Plant.ToList();
        }
        
        public List<Plant> GetPlantenByName(string name) {
            return _context.Plant.Where(p => 
                    p.Fgsv.ToLower().Replace("'", "")
                        .Contains(name.Trim().ToLower().Replace("'", "")))
                .OrderBy(p => p.Fgsv)
                .ToList();
        }

        public List<Plant> GetPlantenByFamily(string family)
        {
            return _context.Plant.Where(p =>
                    p.Familie.ToLower()
                        .Contains(family.Trim().ToLower()))
                .OrderBy(p => p.Familie)
                .ToList();
        }

        public List<Plant> GetPlantenByGeslacht(string name)
        {
            return _context.Plant.Where(p => 
                    p.Geslacht.ToLower()
                        .Contains(name.Trim().ToLower().Replace("'","")))
                .OrderBy(p => p.Geslacht)
                .ToList();
        }

        public List<Plant> GetPlantenBySoort(string name)
        {
            return _context.Plant.Where(p => 
                    p.Soort.ToLower()
                        .Contains(name.Trim().ToLower().Replace("'", "")))
                .OrderBy(p => p.Soort)
                .ToList();
        }

        public List<Plant> GetPlantenByVariant(string name)
        {
            return _context.Plant.Where(p => 
                    p.Variant.ToLower().Replace("'", "")
                        .Contains(name.Trim().ToLower().Replace("'", "")))
                .OrderBy(p => p.Variant)
                .ToList();
        }

        public string RemoveAccentCharacters(string originalText)
        {
            var newText = string.Empty;
            
            foreach (var c in originalText.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
            {
                newText += c;
            }

            return newText;
        }
    }
}