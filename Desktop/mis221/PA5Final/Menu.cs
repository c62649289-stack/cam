namespace PA5Final
{
    public class Menu
    {
        private SessionUtility2 sessionUtility;
        private SessionUtility2 registrationUtility;
        private SessionFile sessionFile;
        private RegistrationFile registrationFile;
        private Session[] sessions;
        private Registration[] registrations;

        public Menu(int maxSessions = 500, int maxRegistrations = 500)
        {
            sessions = new Session[maxSessions];
            registrations = new Registration[maxRegistrations];

            sessionFile = new SessionFile(sessions);
            registrationFile = new RegistrationFile(registrations);
            sessionUtility = new SessionUtility2(sessions, registrations);
            registrationUtility = new SessionUtility2(sessions, registrations);
        }
        public static void Pause()
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void GetMenuChoice()
        {
            bool exit = false;
            while(!exit)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                System.Console.WriteLine("Welsome to Crimson Sports Complex!");
                System.Console.WriteLine("Please Select a Menu Option (1-3):");
                System.Console.WriteLine("1. Athlete Menu");
                System.Console.WriteLine("2. Manager Menu");
                System.Console.WriteLine("3. Exit Application");

                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        System.Console.WriteLine("Athlete Menu");
                        AthleteMenu();
                        break;
                    case "2":
                        System.Console.WriteLine("Manager Menu");
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Warning: Manager use only");
                        PasswordPage();
                        ManagerMenu();
                        break;
                    case "3":
                        exit = true;
                        System.Console.WriteLine("Exiting System");
                        break;
                    default:
                        System.Console.WriteLine("Invalid input. Try Again");
                        Pause();
                        break;

                }

        
            }
        }
        public void ManagerMenu()
        {   
            Console.Clear();
            System.Console.WriteLine("Manager Menu");
            System.Console.WriteLine("1. Add a Session ");
            System.Console.WriteLine("2. Remove a Session");
            System.Console.WriteLine("3. Edit Session Information");
            System.Console.WriteLine("4. Mark Registration as Complete");
            System.Console.WriteLine("5. View Report");
            System.Console.WriteLine("6. Return to the Main Menu");

            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    System.Console.WriteLine("Add Session");
                    System.Console.WriteLine();
                    sessionFile.GetAllSessions();
                    sessionUtility2.CreateSession();
                    sessionFile.SaveAllSessions();
                    System.Console.WriteLine("Session succesfully added");
                    Pause();
                    ManagerMenu();
                    break;
                case "2":
                    System.Console.WriteLine("Remove Session");
                    sessionFile.GetAllSessions();
                    sessionUtility2.RemoveSession();
                    sessionFile.SaveAllSessions();
                    Pause();
                    ManagerMenu();
                    break;
                case "3":
                    System.Console.WriteLine("Edit Session");
                    System.Console.WriteLine();
                    sessionFile.GetAllSessions();
                    sessionUtility2.UpdateSessions();
                    sessionFile.SaveAllSessions();
                    Pause();
                    ManagerMenu();
                    break;
                case "4":
                    System.Console.WriteLine("Mark session full");
                    registrationFile.GetAllRegistrations();
                    registrationUtility.MarkRegistrationComplete();
                    registrationFile.SaveAllRegistrations();
                    Pause();
                    ManagerMenu();
                    break;
                case "5":
                    System.Console.WriteLine("viewing report menu...");
                    ReportMenu();
                    break;
                case "6":
                    GetMenuChoice();
                    break;
                default:
                    System.Console.WriteLine("Invalid input.Try Again");
                    Pause();
                    ManagerMenu();
                    break;



            }
        }
        public void AthleteMenu()
        {
            Console.Clear();
            System.Console.WriteLine("Athlete Menu");
            System.Console.WriteLine("1. View Session Opening");
            System.Console.WriteLine("2. Register for a Session");
            System.Console.WriteLine("3. Past Sessions");
            System.Console.WriteLine("4. Return to Main Menu");

            string menuChoice = Console.ReadLine();
            switch(menuChoice)
            {
                case "1":
                    System.Console.WriteLine("loading session menu");
                    System.Console.WriteLine();
                    sessionFile.GetAllSessions();
                    sessionUtility.ViewAvailableSessions();
                    Pause();
                    AthleteMenu();
                    break;
                case "2":
                    System.Console.WriteLine("Placing order...");
                    System.Console.WriteLine();
                    sessionFile.GetAllSessions();
                    registrationFile.GetAllRegistrations();
                    sessionUtility.RegisterForSession();
                    registrationFile.SaveAllRegistrations();
                    System.Console.WriteLine("Order has been placed");
                    Pause();
                    AthleteMenu();
                    break;
                case "3":
                    System.Console.WriteLine("Showing past orders");
                    registrationFile.GetAllRegistrations();
                    sessionUtility.ViewPastSessions();
                    Pause();
                    AthleteMenu();
                    break;
                case "4":
                    System.Console.WriteLine("returning to menu");
                    GetMenuChoice();
                    break;
                default:
                    System.Console.WriteLine("Invalid input.Try Again");
                    Pause();
                    AthleteMenu();
                    break;

            }
        }
        public void ReportMenu()
        {
            Console.Clear();
            System.Console.WriteLine("1. Daily Session Report");
            System.Console.WriteLine("2. Session in Progress");
            System.Console.WriteLine("3. Average Session Fee by Sport ");
            System.Console.WriteLine("4. 2 Sessions >= 1 Hour");
            System.Console.WriteLine("5. Retrun to manager menu");

            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    System.Console.WriteLine(" Daily Session report");
                    registrationFile.GetAllRegistrations();
                    sessionUtility.DailySessionReport();
                    Pause();
                    ReportMenu();
                    break;
                case "2":
                    System.Console.WriteLine("Sessions Ongoing");
                    System.Console.WriteLine();
                    registrationFile.GetAllRegistrations();
                    sessionUtilitiy.ViewSessionsInProgress();
                    Pause();
                    ReportMenu();
                    break;
                case "3":
                    System.Console.WriteLine("Average session fee by sport");
                    sessionFile.GetAllSessions();
                    sessionUtility.AverageSessionFeeBySport();
                    Pause();
                    ReportMenu();
                    break;
                case "4":
                    System.Console.WriteLine("Sessions Equal to or Over an Hour");
                    sessionFile.GetAllSessions();
                    sessionUtility.SessionPairsOneHour();
                    Pause();
                    ReportMenu();
                    break;
                case "5":
                    System.Console.WriteLine("returning to manager menu");
                    Pause();
                    ManagerMenu();
                    break;
                default:
                    System.Console.WriteLine("Invalid input. Try Again");
                    Pause();
                    ReportMenu();
                    break;
                

            }
        }
        public void PasswordPage()
        {
            System.Console.WriteLine("Please enter the password to acces the manager page.");
            string password = "whoopty do";
            if(Console.ReadLine() == password)
            {
                System.Console.WriteLine("Access granted");
            }
            else
            {
                System.Console.WriteLine("Access denied");
                GetMenuChoice();
            }
        }
    }
}