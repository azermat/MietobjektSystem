using System.Threading;
using static System.Console;





namespace Mietobjekt_Verwaltungssystem
{
    class View        //-----------------------------------------------------Design---------------------------------------------------------//
    {
        public static void EmptyScreen()
        {
            ForegroundColor = System.ConsoleColor.Cyan;
            CursorVisible = false;
            WriteLine("┌────────────────────────────────────────────┬────────────────────────────┬───────────────────────────────────────────┐");
            WriteLine("│ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ Mietobjekt Verwaltungssystem ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ │");
            WriteLine("│┌───────────────────────────────────────────┴────────────────────────────┴──────────────────────────────────────────┐│");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                                     │");
            WriteLine("│                                                                                                     Ste@lMonC)ey KG │");
            WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
            ResetColor();
        }

        public static void WelcomeScreen()
        {
            EmptyScreen();
            ForegroundColor = System.ConsoleColor.DarkCyan;
            Service.WriteAt(Settings.viewWelcome, 39, 14);
        }

        public static void MainScreen()
        {
            EmptyScreen();
            ForegroundColor = System.ConsoleColor.Cyan;
            Service.WriteAt(Settings.letterRow, 57, 5);
            Service.WriteAt(Settings.letterH, 57, 6);
            Service.WriteAt(Settings.letterRow, 57, 7);
            Service.WriteAt(Settings.letterA, 57, 8);
            Service.WriteAt(Settings.letterRow, 57, 9);
            Service.WriteAt(Settings.letterU, 57, 10);
            Service.WriteAt(Settings.letterRow, 57, 11);
            Service.WriteAt(Settings.letterP, 57, 12);
            Service.WriteAt(Settings.letterRow, 57, 13);
            Service.WriteAt(Settings.letterT, 57, 14);
            Service.WriteAt(Settings.letterRow, 57, 15);
            Service.WriteAt(Settings.letterM, 57, 16);
            Service.WriteAt(Settings.letterRow, 57, 17);
            Service.WriteAt(Settings.letterE, 57, 18);
            Service.WriteAt(Settings.letterRow, 57, 19);
            Service.WriteAt(Settings.letterN, 57, 20);
            Service.WriteAt(Settings.letterRow, 57, 21);
            Service.WriteAt(Settings.letterUE, 57, 22);
            Service.WriteAt(Settings.letterRow, 57, 23);
            Service.WriteAt(Settings.customerMngm, 19, 5);
            Service.WriteAt(Settings.objectMngm, 81, 5);

            Service.WriteAt(Settings.letterRowUpRight, 114, 6);
            Service.WriteAt(Settings.letterRow, 114, 7);
            Service.WriteAt(Settings.letterRow, 114, 8);
            Service.WriteAt(Settings.letterS, 114, 9);
            Service.WriteAt(Settings.letterT, 114, 10);
            Service.WriteAt(Settings.letterA, 114, 11);
            Service.WriteAt(Settings.letterT, 114, 12);
            Service.WriteAt(Settings.letterI, 114, 13);
            Service.WriteAt(Settings.letterS, 114, 14);
            Service.WriteAt(Settings.letterT, 114, 15);
            Service.WriteAt(Settings.letterI, 114, 16);
            Service.WriteAt(Settings.letterK, 114, 17);
            Service.WriteAt(Settings.letterE, 114, 18);
            Service.WriteAt(Settings.letterN, 114, 19);
            Service.WriteAt(Settings.letterRow, 114, 20);
            Service.WriteAt(Settings.letterRowDownRight, 114, 21);


            Service.WriteAt(Settings.letterRowUpLeft, 4, 6);
            Service.WriteAt(Settings.letterRow, 0, 7);
            Service.WriteAt(Settings.letterRow, 0, 8);
            Service.WriteAt(Settings.letterI, 0, 9);
            Service.WriteAt(Settings.letterN, 0, 10);
            Service.WriteAt(Settings.letterS, 0, 11);
            Service.WriteAt(Settings.letterT, 0, 12);
            Service.WriteAt(Settings.letterR, 0, 13);
            Service.WriteAt(Settings.letterU, 0, 14);
            Service.WriteAt(Settings.letterK, 0, 15);
            Service.WriteAt(Settings.letterT, 0, 16);
            Service.WriteAt(Settings.letterI, 0, 17);
            Service.WriteAt(Settings.letterO, 0, 18);
            Service.WriteAt(Settings.letterN, 0, 19);
            Service.WriteAt(Settings.letterRow, 0, 20);
            Service.WriteAt(Settings.letterRowDownLeft, 4, 21);


            ResetColor();
            Service.WriteAt("[9]", 115, 7);
            Service.WriteAt("[i]", 1, 7);
            Service.WriteAt(Settings.viewAddNewCustomer, 17, 11);
            Service.WriteAt(Settings.viewPrintAllCustomers, 17, 14);
            Service.WriteAt(Settings.viewPrintCustomerDetails, 17, 17);
            Service.WriteAt(Settings.viewDeleteCustomer, 17, 20);
            Service.WriteAt(Settings.viewAddNewObject, 79, 11);
            Service.WriteAt(Settings.viewPrintAllObjects, 79, 14);
            Service.WriteAt(Settings.viewPrintObjectDetails, 79, 17);
            Service.WriteAt(Settings.viewDeleteObject, 79, 20);
            Service.WriteAt(Settings.viewExit, 53, 27);
            Service.WriteAt("Objekte: ", 3, 26);
            Service.WriteAt("Kunden: ", 3, 25);
        }

        public static void DeleteScreenCustomer()
        {
            EmptyScreen();
            CursorVisible = true;
            Service.WriteAt(Settings.deleteScreenHeadCustomer, 51, 3);
            Service.WriteAt(Settings.deleteScreenInputCustomer, 13, 7);
            Service.WriteAt(Settings.deleteScreenConfirm, 28, 9);
            ForegroundColor = System.ConsoleColor.Red;
            Service.WriteAt(Settings.delteScreenWarning, 4, 25);
            ResetColor();
        }

        public static void DeleteScreenObject()
        {
            EmptyScreen();
            CursorVisible = true;
            Service.WriteAt(Settings.deleteScreenHeadObject, 49, 3);
            Service.WriteAt(Settings.deleteScreenInputObject, 9, 7);
            Service.WriteAt(Settings.deleteScreenConfirm, 28, 9);
            ForegroundColor = System.ConsoleColor.Red;
            Service.WriteAt(Settings.delteScreenWarning, 4, 25);
            ResetColor();
        }

        public static void DeleteScreenFindObject()
        {
            EmptyScreen();
            CursorVisible = true;
            Service.WriteAt(Settings.deleteScreenHeadObject, 49, 3);
            Service.WriteAt(Settings.deleteScreenInputCustomerObject, 6, 7);
            Service.WriteAt(Settings.deleteScreenConfirm, 28, 9);
            ForegroundColor = System.ConsoleColor.Red;
            Service.WriteAt(Settings.delteScreenWarning, 4, 25);
            ResetColor();
        }

        public static void IDCheckScreen()
        {
            EmptyScreen();
            Service.WriteAt(Settings.idCheckHeadline, 55, 3);
            CursorVisible = false;
        }

        public static void BootScreen()
        {
            WelcomeScreen();
            Thread.Sleep(3000);
            Clear();
        }

        public static void StatisticsScreen()
        {
            EmptyScreen();
            ForegroundColor = System.ConsoleColor.Cyan;
            Service.WriteAt(Settings.statisticsHeadline, 54, 3);
            Service.WriteAt(Settings.lastThreeCustomers, 3, 6);
            Service.WriteAt(Settings.lastThreeObjects, 3, 10);
            Service.WriteAt(Settings.highestrentObject, 3, 14);
            Service.WriteAt(Settings.lowestrentObject, 3, 17);
            Service.WriteAt(Settings.mostLucrativeCurrent, 3, 20);
            Service.WriteAt(Settings.mostLukrativeObjectsince, 3, 23);
            Service.WriteAt(Settings.mostLukrativeCustomersince, 3, 26);
            ResetColor();
        }

        public static void InstructionScreen()
        {

        }
    }
}
