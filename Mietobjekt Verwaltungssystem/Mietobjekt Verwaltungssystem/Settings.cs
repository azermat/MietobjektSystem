

namespace Mietobjekt_Verwaltungssystem
{
    public class Settings
    {
        //Titel
        public const string apptitle = "Mietobjekt Verwaltungssystem";

        //MainScreen 
        public const string viewWelcome = "Willkommen im Mietobjekt Verwaltungssystem!";
        public const string viewAddNewCustomer = "[1] Neuer Kunde";
        public const string viewPrintAllCustomers = "[2] Alle Kunden";
        public const string viewPrintCustomerDetails = "[3] Kundendetails";
        public const string viewDeleteCustomer = "[4] Kunden entfernen";
        public const string viewAddNewObject = "[5] Neues Mietobjekt";
        public const string viewPrintAllObjects = "[6] Alle Mietobjekte";
        public const string viewPrintObjectDetails = "[7] Mietobjektdetails";
        public const string viewDeleteObject = "[8] Mietobjekt entfernen";
        public const string viewExit = "[0] Beenden";
        public const string customerMngm = "[Kundenverwaltung]";
        public const string objectMngm = "[Objektverwaltung]";
        public const string letterH = "│ H │";
        public const string letterA = "│ A │";
        public const string letterU = "│ U │";
        public const string letterP = "│ P │";
        public const string letterT = "│ T │";
        public const string letterM = "│ M │";
        public const string letterE = "│ E │";
        public const string letterN = "│ N │";
        public const string letterUE = "│ Ü │";
        public const string letterRow = "│   │";
        public const string letterRowDownRight = "└";
        public const string letterRowUpRight = "┌";
        public const string letterRowUpLeft = "┐";
        public const string letterRowDownLeft = "┘";
        public const string letterI = "│ I │";
        public const string letterL = "│ L │";
        public const string letterG = "│ G │";
        public const string letterR = "│ R │";
        public const string letterO = "│ O │";
        public const string letterK = "│ K │";
        public const string letterS = "│ S │";
        public const string backButton = "[Enter] Fortfahren";

        //Check ID
        public const string inputField = "Eingabe: ";
        public const string idFound = "ID Check erfolgreich!   Weiterleitung erfolgt in kürze...";
        public const string idCheckHeadline = "[ID Check]";
        public const string idCheckNote = "Bitte geben Sie Ihre ID im Eingabefeld ein um fortzufahren.";

        //Statistics Screen
        public const string statisticsHeadline = "[Statistiken]";
        public const string lastThreeCustomers = "3 zuletzt hinzugefügte Kunden: ";
        public const string lastThreeObjects = "3 zuletzt hinzugefügte Objekte: ";
        public const string highestrentObject = "Mietobjekt mit höchster Miete: ";
        public const string lowestrentObject = "Mietobjekt mit niedrigster Miete: ";
        public const string mostLucrativeCurrent = "Lukrativstes Mietobjekt aktuell: ";
        public const string mostLukrativeObjectsince = "Lukrativstes Mietobjekt seit beginn: ";
        public const string mostLukrativeCustomersince = "Lukrativster Kunde seit beginn: ";

        //XML Writer
        public const string xmlFile = "CustomerFile.xml";
        public const string backupFile = "Backup.xml";
        public const string xmlNotFound = " Fehlgeschlagen - Keine lesbare Datei im angegebenen Pfad gefunden! \n\n Beliebige Taste drücken um eine neue Datei anzulegen...";

        //Add Customer, Add Rentobject
        public const string Name = "Name: ";
        public const string InputID = "Geben Sie eine ID ein: ";
        public const string CustomerObjects = "Welche Mietobjekte besitzen Sie?: ";
        public const string TotalIncomeFirst = "Gesamteinnahmen im ersten Jahr: ";
        public const string TotalIncomeCurrent = "Gesamteinnahmen im aktuellen Jahr: ";
        public const string TotalIncomeSince = "Gesamteinnahmen seit (Jahr): ";
        public const string ManagementCostsCurrent = "Verwaltungskosten aktuelles Jahr: ";
        public const string ManagementCostsFirst = "Verwaltungskosten im ersten Jahr: ";
        public const string ManagementCostsSince = "Verwaltungskosten seit (Jahr): ";

        //Delete 
        public const string idNotFound = "ID konnte nicht gefunden werden.Bitte prüfen Sie die Eingabe und versuchen es erneut.";
        public const string confirmDelete = "'Ja' bestätigen | Enter abbrechen: ";
        public const string yesDelete = "Ja";
        public const string customerRemoved = "Kunde wurde erfolgreich Entfernt.";
        public const string cancelDelete = "Vorgang abgebrochen.";
        public const string askIfSureCustomer = "!! Sind Sie sicher das Sie den Kunden mit der ID:{0} löschen möchten? !!";
        public const string deleteScreenHeadCustomer = "[Kunden entfernen]";
        public const string deleteScreenInputCustomer = "Geben Sie die zugehörige ID des Kunden, den Sie entfernen möchten im unteren Eingabefeld ein.";
        public const string deleteScreenConfirm = "Bestätigen Sie anschließend Ihre Eingabe mit der Eingabetaste.";
        public const string delteScreenWarning = "WARNUNG: Dieser Vorgang kann nicht rückgängig gemacht werden!";
        public static string confirmInput;

        public const string objectRemoved = "Mietobjekt wurde erfolgreich Entfernt.";
        public const string askIfSureObject = "!! Sind Sie sicher das Sie das Mietobjekt mit der ID:{0} löschen möchten? !!";
        public const string deleteScreenHeadObject = "[Mietobjekt entfernen]";
        public const string deleteScreenInputCustomerObject = "Geben Sie die zugehörige ID des Kunden, dessen Mietobjekt Sie entfernen möchten im unteren Eingabefeld ein.";
        public const string deleteScreenInputObject = "Geben Sie die zugehörige ID des Mietobjekts, welches Sie entfernen möchten im unteren Eingabefeld ein.";


        //InstructionScreen
        public const string InstructionHeadline = "[Instruktion]";
        public const string InstructionGuide = "Steuerung: Zum Bedienen des Konsolenprogramms benutzen Sie bitte die Nummern auf den NumPad Tasten.";
        public const string InstructionGuide2 = "Um die Erfassten Einträge nicht zu verlieren, Beenden Sie das Programm bitte Ordnungsgemäß";
        public const string InstructionGuide3 = "";

    }
}
