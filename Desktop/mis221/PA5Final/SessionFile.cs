
namespace PA5Final
{
    public class SessionFile
    {
        private Session[] sessions;

        public SessionFile(Session[] sessions )
        {
            this.sessions = sessions;
        }
        public void GetAllSessions()
        {
            session.SetCount(0);
            StreamReader inFile = new StreamReader("sessions.txt");
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                sessions[session.GetCount()] = new Session(temp[0], temp[1],int.Parse(temp[2]), temp[3], double.Parse(temp[4]), int.Parse(temp[5]), bool.Parse(temp[6]));
                Session.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        public void SaveAllSessions()
        {
            StreamWriter outFile = new StreamWriter("sessions.txt");
            for(int i = 0; i < Session.GetCount(); i++)
            {
                outFile.WriteLine(sessions[i].ToFile());
            }
            outFile.Close();
        }
    }
}