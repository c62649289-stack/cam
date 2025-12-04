using System;
using System.Collections.Generic;
namespace PA53
{


    public class Menu
    {
        private List<Session> sessions;
        private List<Registration> registrations;
        private SessionFile sessionFile;
        private RegistrationFile registrationFile;

        public Menu()
        {
            sessionFile = new SessionFile();
            registrationFile = new RegistrationFile();
            sessions = sessionFile.LoadSessions();
            registrations = registrationFile.LoadRegistrations();
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome to Crimson Sports Complex!");
                Console.WriteLine("1. Athlete Menu");
                Console.WriteLine("2. Manager Menu");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AthleteMenu();
                        break;
                    case "2":
                        ManagerMenu();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ----------------- Athlete Section -----------------
        private void AthleteMenu()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            bool athleteRunning = true;

            while (athleteRunning)
            {
                Console.WriteLine("\nAthlete Menu:");
                Console.WriteLine("1. View Available Sessions");
                Console.WriteLine("2. Register for a Session");
                Console.WriteLine("3. View My Past Sessions");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAvailableSessions();
                        break;
                    case "2":
                        RegisterForSession(email);
                        break;
                    case "3":
                        ViewPastSessions(email);
                        break;
                    case "0":
                        athleteRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewAvailableSessions()
        {
            Console.WriteLine("\nAvailable Sessions:");
            for (int i = 0; i < sessions.Count; i++)
            {
                Session s = sessions[i];
                if (!s.GetIsSoldOut())
                {
                    Console.WriteLine(s.GetSessionId() + " - " + s.GetSportName() + " | Coach: " + s.GetCoachName() +
                                    " | Length: " + s.GetSessionLength() + " mins | Price: $" + s.GetSessionPrice() +
                                    " | Seats: " + s.GetSessionSeats());
                }
            }
        }

        private void RegisterForSession(string email)
        {
            ViewAvailableSessions();
            Console.Write("Enter Session ID to register: ");
            string sessionId = Console.ReadLine();
            Session selected = null;

            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].GetSessionId() == sessionId && !sessions[i].GetIsSoldOut())
                {
                    selected = sessions[i];
                    break;
                }
            }

            if (selected == null)
            {
                Console.WriteLine("Invalid session ID or session is full.");
                return;
            }

            Console.Write("Enter your full name: ");
            string name = Console.ReadLine();

            string regId = (registrations.Count + 1).ToString();
            string date = DateTime.Now.ToString("MM/dd/yy");
            string status = "Pending";

            Registration newReg = new Registration(regId, email, name, sessionId, date, status);
            registrations.Add(newReg);

            // Decrease seat count and update sold out status
            selected.SetSessionSeats(selected.GetSessionSeats() - 1);
            if (selected.GetSessionSeats() <= 0)
            {
                selected.SetIsSoldOut(true);
            }

            // Save files
            registrationFile.SaveRegistrations(registrations);
            sessionFile.SaveSessions(sessions);

            Console.WriteLine("Successfully registered!");
        }

        private void ViewPastSessions(string email)
        {
            Console.WriteLine("\nYour Past Sessions:");
            for (int i = 0; i < registrations.Count; i++)
            {
                Registration r = registrations[i];
                if (r.GetEmail() == email)
                {
                    string sportName = "";
                    for (int j = 0; j < sessions.Count; j++)
                    {
                        if (sessions[j].GetSessionId() == r.GetSessionId())
                        {
                            sportName = sessions[j].GetSportName();
                            break;
                        }
                    }
                    Console.WriteLine(r.GetRegistrationId() + " - " + sportName + " | Date: " + r.GetRegistrationDate() +
                                    " | Status: " + r.GetCompletionStatus());
                }
            }
        }

        // ----------------- Manager Section -----------------
        private void ManagerMenu()
        {
            bool managerRunning = true;

            while (managerRunning)
            {
                Console.WriteLine("\nManager Menu:");
                Console.WriteLine("1. Add Session");
                Console.WriteLine("2. Remove Session");
                Console.WriteLine("3. Edit Session");
                Console.WriteLine("4. Mark Session Complete");
                Console.WriteLine("5. View Reports");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddSession();
                        break;
                    case "2":
                        RemoveSession();
                        break;
                    case "3":
                        EditSession();
                        break;
                    case "4":
                        MarkSessionComplete();
                        break;
                    case "5":
                        ViewReports();
                        break;
                    case "0":
                        managerRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void AddSession()
        {
            Console.Write("Enter Session ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Sport Name: ");
            string sport = Console.ReadLine();
            Console.Write("Enter Session Length (minutes): ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Enter Coach Name: ");
            string coach = Console.ReadLine();
            Console.Write("Enter Session Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter Number of Seats: ");
            int seats = int.Parse(Console.ReadLine());

            Session newSession = new Session(id, sport, length, coach, price, seats, seats <= 0);
            sessions.Add(newSession);
            sessionFile.SaveSessions(sessions);

            Console.WriteLine("Session added successfully!");
        }

        private void RemoveSession()
        {
            Console.Write("Enter Session ID to remove: ");
            string id = Console.ReadLine();
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].GetSessionId() == id)
                {
                    sessions.RemoveAt(i);
                    sessionFile.SaveSessions(sessions);
                    Console.WriteLine("Session removed!");
                    return;
                }
            }
            Console.WriteLine("Session ID not found.");
        }

        private void EditSession()
        {
            Console.Write("Enter Session ID to edit: ");
            string id = Console.ReadLine();
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].GetSessionId() == id)
                {
                    Console.Write("Enter new Sport Name: ");
                    sessions[i].SetSportName(Console.ReadLine());
                    Console.Write("Enter new Session Length: ");
                    sessions[i].SetSessionLength(int.Parse(Console.ReadLine()));
                    Console.Write("Enter new Coach Name: ");
                    sessions[i].SetCoachName(Console.ReadLine());
                    Console.Write("Enter new Session Price: ");
                    sessions[i].SetSessionPrice(double.Parse(Console.ReadLine()));
                    Console.Write("Enter new Number of Seats: ");
                    int seats = int.Parse(Console.ReadLine());
                    sessions[i].SetSessionSeats(seats);
                    sessions[i].SetIsSoldOut(seats <= 0);
                    sessionFile.SaveSessions(sessions);
                    Console.WriteLine("Session updated!");
                    return;
                }
            }
            Console.WriteLine("Session ID not found.");
        }

        private void MarkSessionComplete()
        {
            Console.Write("Enter Session ID to mark complete: ");
            string id = Console.ReadLine();
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].GetSessionId() == id)
                {
                    sessions[i].SetIsCompleted(true);
                    sessionFile.SaveSessions(sessions);
                    Console.WriteLine("Session marked complete!");
                    return;
                }
            }
            Console.WriteLine("Session ID not found.");
        }

        private void ViewReports()
        {
            Console.WriteLine("\nReports Menu:");
            Console.WriteLine("1. Daily Sessions Report");
            Console.WriteLine("2. In-Progress Sessions");
            Console.WriteLine("3. Average Fee by Sport");
            Console.WriteLine("4. Session Pairs >= 1 hour");
            Console.Write("Select report: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DailySessionsReport();
                    break;
                case "2":
                    InProgressSessions();
                    break;
                case "3":
                    AverageFeeBySport();
                    break;
                case "4":
                    SessionPairsOneHour();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void DailySessionsReport()
        {
            Console.WriteLine("\nDaily Sessions Report:");
            for (int i = 0; i < registrations.Count; i++)
            {
                Registration r = registrations[i];
                Console.WriteLine(r.GetRegistrationDate() + " | Registration ID: " + r.GetRegistrationId() + " | Session ID: " + r.GetSessionId() + " | Athlete: " + r.GetName());
            }
        }

        private void InProgressSessions()
        {
            Console.WriteLine("\nIn-Progress Sessions:");
            for (int i = 0; i < sessions.Count; i++)
            {
                Session s = sessions[i];
                if (!s.GetIsCompleted())
                {
                    Console.WriteLine(s.GetSessionId() + " - " + s.GetSportName() + " | Coach: " + s.GetCoachName());
                }
            }
        }

        private void AverageFeeBySport()
        {
            Console.WriteLine("\nAverage Fee by Sport:");
            Dictionary<string, List<double>> fees = new Dictionary<string, List<double>>();

            for (int i = 0; i < sessions.Count; i++)
            {
                Session s = sessions[i];
                if (!fees.ContainsKey(s.GetSportName()))
                {
                    fees[s.GetSportName()] = new List<double>();
                }
                fees[s.GetSportName()].Add(s.GetSessionPrice());
            }

            foreach (var kvp in fees)
            {
                double total = 0;
                for (int i = 0; i < kvp.Value.Count; i++) total += kvp.Value[i];
                double avg = total / kvp.Value.Count;
                Console.WriteLine(kvp.Key + ": $" + avg);
            }
        }

        private void SessionPairsOneHour()
        {
            Console.WriteLine("\nSession Pairs >= 1 hour:");
            for (int i = 0; i < sessions.Count; i++)
            {
                for (int j = i + 1; j < sessions.Count; j++)
                {
                    if (sessions[i].GetSessionLength() + sessions[j].GetSessionLength() >= 60)
                    {
                        Console.WriteLine(sessions[i].GetSportName() + " + " + sessions[j].GetSportName() +
                                        " = " + (sessions[i].GetSessionLength() + sessions[j].GetSessionLength()) + " mins");
                    }
                }
            }
        }
    }

}