using System;
using System.IO;
using System.Collections.Generic;
namespace PA53
{
    public class RegistrationFile
    {
        private string filePath = "registration.txt";

        public List<Registration> LoadRegistrations()
        {
            List<Registration> registrations = new List<Registration>();
            if (!File.Exists(filePath)) return registrations;

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('#');
                string regId = parts[0];
                string email = parts[1];
                string name = parts[2];
                string sessionId = parts[3];
                string date = parts[4];
                string status = parts[5];
                registrations.Add(new Registration(regId, email, name, sessionId, date, status));
            }
            return registrations;
        }

        public void SaveRegistrations(List<Registration> registrations)
        {
            string[] lines = new string[registrations.Count];
            for (int i = 0; i < registrations.Count; i++)
            {
                Registration r = registrations[i];
                lines[i] = r.GetRegistrationId() + "#" + r.GetEmail() + "#" + r.GetName() + "#" +
                        r.GetSessionId() + "#" + r.GetRegistrationDate() + "#" + r.GetCompletionStatus();
            }
            File.WriteAllLines(filePath, lines);
        }
    }

}