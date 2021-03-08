using System;
using System.Collections.Generic;

namespace PlantenApplicatie.Domain
{
    public partial class TfgsvSoort
    {
        public long Soortid { get; set; }
        public long GeslachtGeslachtId { get; set; }
        public string Soortnaam { get; set; }
        public string NlNaam { get; set; }

        // override ToString, toon de property waarde in de combobox
        public override string ToString()
        {
            return Soortnaam;
        }
    }
}
