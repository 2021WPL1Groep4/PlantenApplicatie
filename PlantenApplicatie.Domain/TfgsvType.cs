using System;
using System.Collections.Generic;

namespace PlantenApplicatie.Domain
{
    public partial class TfgsvType
    {
        public long Planttypeid { get; set; }
        public string Planttypenaam { get; set; }

        // override ToString, toon de property waarde in de combobox
        public override string ToString()
        {
            return Planttypenaam;
        }
    }
}
