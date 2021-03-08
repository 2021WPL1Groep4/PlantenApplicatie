using System;
using System.Collections.Generic;

namespace PlantenApplicatie.Domain
{
    public partial class TfgsvFamilie
    {
        public long FamileId { get; set; }
        public long TypeTypeid { get; set; }
        public string Familienaam { get; set; }
        public string NlNaam { get; set; }

        // override ToString, toon de property waarde in de combobox
        public override string ToString()
        {
            return Familienaam;
        }
    }
}
