using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using static System.Console;

namespace Mietobjekt_Verwaltungssystem
{
    public class RentObjectFlat : RentalObject
    {
        public override string Rentalobjecttype { get { return "Wohnung"; } }
        public override double Increase { get { return 2; } }

        [XmlIgnore]
        public string renovationdate;

        [XmlIgnore]
        public string shortcomings;

        [XmlIgnore]
        public string donerenovations;

        public List<string> Renovations = new List<string>();


        private void ResidenceRenovations(RentalObject rentalObject)
        {
            DateTime moment = DateTime.Now;
            int year = moment.Year - rentalObject.RentStart.Year;
            DateTime yearcounter = rentalObject.RentStart;
            int position = 0;

            if (year >= 7)
            {
                if (renovationdate != string.Empty)
                {
                    CursorVisible = true;
                    do
                    {
                        Service.WriteAt($"Termin Angabe für Jahr {yearcounter:yyyy}: ", 60, 8 + (position * 4));
                        renovationdate = ReadLine();
                        Service.WriteAt("Renovierungen: ", 60, 9 + (position * 4));
                        donerenovations = ReadLine();
                        Service.WriteAt("Festgestellte Mängel: ", 60, 10 + (position * 4));
                        shortcomings = ReadLine();
                        yearcounter = yearcounter.AddYears(7);

                        year -= 7;
                        position++;
                        Renovations.Add(" Termin: " + renovationdate + "         Renovierungen: " + donerenovations + "         Mängel: " + shortcomings);
                    }
                    while (year >= 7);
                    CursorVisible = false;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
                Service.WriteAt("Die Renovierungsdaten für dieses Mietobjekt sind bereits eingetragen.", 24, 6);
                ResetColor();
            }
        }

        public void RentRenovation(RentalObject rentalObject)
        {
            ResidenceRenovations(rentalObject);
        }

        public override void PrintMenu()
        {
            Service.WriteAt("[1] Renovierungen Anzeigen", 89, 24);
            Service.WriteAt("[2] Renovierungen Eintragen", 89, 25);
            Service.WriteAt("[0] Zurück", 54, 27);           
        }

        public override void PrintExtraDetails()
        {
            Clear();
            Renovations.ForEach(shortcomings => WriteLine(shortcomings));
        }

        public override void NewEntryDetails()
        {
            RentRenovation(this);
        }
    }
}
