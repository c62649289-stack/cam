using System;
using System.IO;

namespace PA5Final
{
    public class SessionUtility2
    {
        private Session[] sessions;
        private Registration[] registrations;

        public SessionUtility2(Session[] sessions, Registration[] registrations)
        {
            this.sessions = sessions;
            this.registrations = registrations;
        }

        public void Sort(string sortBy = "sessionId")
        {
            for (int i = 0; i < Session.GetCount() - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < Session.GetCount(); j++)
                {
                    if (sessions[min].CompareTo(sessions[j], sortBy) > 0)
                        min = j;
                }

                if (min != i)
                {
                    Session temp = sessions[min];
                    sessions[min] = sessions[i];
                    sessions[i] = temp;
                }
                Swap(min, i);
            }
        }

    
        public int FindSession(string sessionId)
        {
            for (int i = 0; i < Session.GetCount(); i++)
            {
                if (sessions[i].GetSessionId() == sessionId)
                    return i;
            }
            return -1;
        }

        public void UpdateSessions()
        {
            Console.WriteLine("Enter Session ID to update:");
            string id = Console.ReadLine();

            int index = FindSession(id);

            if (index >= 0)
                UpdateSessionInfo(sessions[index]);
            else
                Console.WriteLine("Session not found.");
        }

        private void UpdateSessionInfo(Session s)
        {
            Console.WriteLine("Enter new sport name:");
            s.SetSportName(Console.ReadLine());

            Console.WriteLine("Enter new session length (minutes):");
            s.SetSessionLength(int.Parse(Console.ReadLine()));

            Console.WriteLine("Enter coach name:");
            s.SetCoachName(Console.ReadLine());

            Console.WriteLine("Enter new session price:");
            s.SetSessionPrice(double.Parse(Console.ReadLine()));

            Console.WriteLine("Is the session full? (true/false)");
            s.SetIsFull(bool.Parse(Console.ReadLine()));

            Console.WriteLine("Session updated successfully.");
        }

        public void RemoveSession()
        {
            Console.WriteLine("Enter Session ID to remove:");
            string id = Console.ReadLine();

            int index = FindSession(id);

            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }

            
            for (int i = index; i < Session.GetCount() - 1; i++)
            {
                sessions[i] = sessions[i + 1];
            }

            sessions[Session.GetCount() - 1] = null;
            Session.DecCount();

            Console.WriteLine("Session removed successfully.");
        }

        public void CreateSession()
        {
            Session s = new Session();

            s.SetSessionId((Session.GetCount() + 1).ToString());

            Console.WriteLine("Type a sport name:");
            s.SetName(Console.ReadLine());

            Console.WriteLine("Type session length:");
            s.SetSessionCount(int.Parse(Console.ReadLine()));

            Console.WriteLine("Type a coach name:");
            s.SetSportType(Console.ReadLine());

            Console.WriteLine("Type a session price:");
            s.SetSessionPrice(double.Parse(Console.ReadLine()));

            Console.WriteLine("Enter number of seats:");
            int seats = int.Parse(Console.ReadLine());

            Console.WriteLine("Is the current session full? (true/false)");
            bool full = bool.Parse(Console.ReadLine());
            s.SetIsSoldOut(full);

            sessions[Session.GetCount()] = s;
            Session.IncCount();

            Console.WriteLine("Session added successfully.");
        }

        public void ViewAvailableSessions()
        {
            Console.WriteLine("\nAvailable Sessions:");
            for (int i = 0; i < Session.GetCount(); i++)
            {
                if (!sessions[i].GetIsSoldOut())
                    Console.WriteLine(sessions[i].ToString());
            }
        }

        public void RegisterForSession()
        {
            Registration r = new Registration();

            r.SetRegistrationId((Registration.GetCount() + 1).ToString());

            Console.WriteLine("Enter your email:");
            r.SetEmail(Console.ReadLine());

            Console.WriteLine("Enter your name:");
            r.SetName(Console.ReadLine());

            Console.WriteLine("Enter session ID:");
            string sid = Console.ReadLine();
            r.SetSessionId(sid);

            int index = FindSession(sid);

            if (index == -1 || sessions[index].GetIsSoldOut())
            {
                Console.WriteLine("Invalid or full session.");
                return;
            }

            r.SetRegistrationDate(DateTime.Now.ToString("MM/dd/yyyy"));
            r.SetIsCompleted(false);

            registrations[Registration.GetCount()] = r;
            Registration.IncCount();

            File.AppendAllLines("registration.txt", new[] { r.ToFile() });

            Console.WriteLine("Registration successful!");
        }

        public void ViewPastSessions()
        {
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

            for (int i = 0; i < Registration.GetCount(); i++)
            {
                if (registrations[i].GetEmail() == email)
                    Console.WriteLine(registrations[i].ToString());
            }
        }

        public int FindRegistration(string regId)
        {
            for (int i = 0; i < Registration.GetCount(); i++)
            {
                if (registrations[i].GetRegistrationId() == regId)
                    return i;
            }
            return -1;
        }

        public void MarkRegistrationComplete()
        {
            Console.WriteLine("Enter registration ID:");
            string rid = Console.ReadLine();

            int index = FindRegistration(rid);
            if (index == -1)
            {
                Console.WriteLine("Registration not found.");
                return;
            }

            registrations[index].SetIsCompleted(true);
            Console.WriteLine("Marked as completed.");
        }

        public void DailySessionReport()
        {
            string today = DateTime.Now.ToString("MM/dd/yyyy");

            Console.WriteLine("Registrations for the current day:");

            for (int i = 0; i < Registration.GetCount(); i++)
            {
                if (registrations[i].GetRegistrationDate() == today)
                    Console.WriteLine(registrations[i].ToString());
            }
        }

        public void ViewSessionsInProgress()
        {
            Console.WriteLine("\nSessions in Progress:");

            for (int i = 0; i < Registration.GetCount(); i++)
            {
                if (!registrations[i].GetIsCompleted())
                    Console.WriteLine(registrations[i].ToString());
            }
        }
        public void AverageSessionFeeBySport()
            {
                string curr = sessions[0].GetSportName();
                double total = sessions[0].GetSessionPrice();
                int count = 1;
                for(int i = 1; i < Session.GetCount(); i++)
                {
                    if (sessions[i].GetSportName() == curr)
                    {
                        total += sessions[i].GetSessionPrice();
                        count++;
                    }
                    else
                    {
                        ProcessBreak(ref curr, ref total, ref count, i);
                    }
                }
                ProcessBreak(curr,total,count);
            }
            private void ProcessBreak(ref string curr, ref int total, ref int count, int i)
            {
                System.Console.WriteLine($"{curr}\t{total/count}");
                curr = sessions[i].GetSportType();
                total = int.Parse(orders[i].GetSessionSize());
                count = 1;
            }
            private void ProcessBreak(string curr, int total, int count)
            {
                System.Console.WriteLine($"{curr}\t{total / count}");
            }

        public void SessionPairsOneHour()
        {
            Console.WriteLine("\nSession Pairs ≥ 60 Minutes:");

            for (int i = 0; i < Session.GetCount(); i++)
            {
                for (int j = i + 1; j < Session.GetCount(); j++)
                {
                    if (sessions[i].GetSessionLength() + sessions[j].GetSessionLength() >= 60)
                    {
                        Console.WriteLine($"{sessions[i].GetSportName()} + {sessions[j].GetSportName()}");
                    }
                }
            }
        }
    }
}

    
