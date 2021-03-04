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
        
        public List<Plant> GetPlantenByName(string name)
        {

            return GetPlanten().Where(p =>
                    (p.Fgsv is not null && Parse(p.Fgsv).Contains(Parse(name))))
                .OrderBy(p => p.Fgsv)
                .ToList();
        }

        public List<Plant> GetPlantenByFamily(string family)
        {
            return GetPlanten().Where(p =>
                    (p.Familie is not null && Parse(p.Familie).Contains(Parse(family))))
                .OrderBy(p => p.Familie)
                .ToList();
        }

        public List<Plant> GetPlantenByGeslacht(string gender)
        {
            return GetPlanten().Where(p =>
                    (p.Geslacht is not null && Parse(p.Geslacht).Contains(gender)))
                .OrderBy(p => p.Geslacht)
                .ToList();
        }

        public List<Plant> GetPlantenBySoort(string kind)
        {
            return GetPlanten().Where(p =>
                    (p.Soort is not null && Parse(p.Soort).Contains(kind)))
                .OrderBy(p => p.Soort)
                .ToList();
        }

        public List<Plant> GetPlantenByVariant(string variant)
        {
            return GetPlanten().Where(p =>
                    (p.Variant is not null && Parse(p.Variant).Contains(Parse(variant))))
                .OrderBy(p => p.Variant)
                .ToList();
        }

        private static string Parse(string text)
        {
            return RemoveAccentCharacters(text.Trim().ToLower().Replace("'", ""));
        }

        private static string RemoveAccentCharacters(string originalText)
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