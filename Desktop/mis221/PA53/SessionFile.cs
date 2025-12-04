using System;
using System.IO;
using System.Collections.Generic;
namespace PA53
{
    public class SessionFile
    {
        private string filePath = "session.txt";

        public List<Session> LoadSessions()
        {
            List<Session> sessions = new List<Session>();
            if (!File.Exists(filePath)) return sessions;

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('#');
                string id = parts[0];
                string sport = parts[1];
                int length = int.Parse(parts[2]);
                string coach = parts[3];
                double price = double.Parse(parts[4]);
                int seats = int.Parse(parts[5]);
                bool soldOut = bool.Parse(parts[6]);
                sessions.Add(new Session(id, sport, length, coach, price, seats, soldOut));
            }
            return sessions;
        }

        public void SaveSessions(List<Session> sessions)
        {
            string[] lines = new string[sessions.Count];
            for (int i = 0; i < sessions.Count; i++)
            {
                Session s = sessions[i];
                lines[i] = s.GetSessionId() + "#" + s.GetSportName() + "#" + s.GetSessionLength() + "#" +
                        s.GetCoachName() + "#" + s.GetSessionPrice() + "#" + s.GetSessionSeats() + "#" + s.GetIsSoldOut();
            }
            File.WriteAllLines(filePath, lines);
        }
    }

}