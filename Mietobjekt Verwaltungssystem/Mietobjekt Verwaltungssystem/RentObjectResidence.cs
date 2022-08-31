using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using static System.Console;

namespace Mietobjekt_Verwaltungssystem
{
    public class RentObjectResidence : RentalObject
    {
        public override string Rentalobjecttype { get { return "Wohnhaus"; } }
        public override double Increase { get { return 2.5; } }

        [XmlIgnore]
        private string chimneysweep;

        public List<string> chimneysweeps = new List<string>();

        private void ChimneySweepings(RentalObject rentalObject)
        {
            DateTime moment = DateTime.Now;
            int year = moment.Year - rentalObject.RentStart.Year;
            DateTime yearcounter = rentalObject.RentStart;

            if (chimneysweep == string.Empty)
            {
                do
                {
                    Service.WriteAt($"Datum der Durchführung für Jahr {yearcounter:yyyy}: ", 60, 8);
                    chimneysweep = ReadLine();
                    yearcounter = yearcounter.AddYears(1);

                    year--;
                    chimneysweeps.Add("Datum der Durchführung: " + chimneysweep);
                }
                while (year != 0);
            }
            else
            {
                Service.WriteAt("Die Schornsteinfeger Termine für dieses Mietobjekt sind bereits eingetragen.", 50, 3);
            }
        }

        public void RentChimneySweep(RentalObject rentalObject)
        {
            ChimneySweepings(rentalObject);
        }

        public override void PrintMenu()
        {
            Service.WriteAt("[1] Termine Anzeigen", 89, 24);
            Service.WriteAt("[2] Termin Eintragen", 89, 25);
            Service.WriteAt("[0] Zurück", 54, 27);
        }

        public override void PrintExtraDetails()
        {
            Clear();
            chimneysweeps.ForEach(chimneysweep => WriteLine(chimneysweep));
        }

        public override void NewEntryDetails()
        {
            RentChimneySweep(this);
        }
    }
}
