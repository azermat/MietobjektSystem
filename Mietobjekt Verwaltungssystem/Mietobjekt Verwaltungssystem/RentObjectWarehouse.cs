using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mietobjekt_Verwaltungssystem
{
    public class RentObjectWarehouse : IndustrialRentals
    {
        public override string Rentalobjecttype { get { return "Lagerhaus"; } }
        public override double Increase { get { return 1.5; } }

        public override void PrintMenu()
        {
            Service.WriteAt("[1] Termine Anzeigen", 89, 24);
            Service.WriteAt("[2] Termin Eintragen", 89, 25);
            Service.WriteAt("[0] Zurück", 54, 27);
        }

        public override void PrintExtraDetails()
        {
            
        }

        public override void NewEntryDetails()
        {
            throw new NotImplementedException();
        }
    }
}
