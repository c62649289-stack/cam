namespace PA5Final
{
    public class Registration
    {
        
        private string registrationId;
        private string athleteEmail;
        private string athleteName;
        private string sessionId;
        private string registrationDate;
        private bool isCompleted;

        private static int count;

        public Registration() {}

        public Registration(string regId, string email, string name, string sessionId, string date, bool completed)
        {
            this.registrationId = regId;
            this.athleteEmail = email;
            this.athleteName = name;
            this.sessionId = sessionId;
            this.registrationDate = date;
            this.isCompleted = completed;
        }

        public string GetRegistrationId()
        {
            return registrationId;
        }
        public void SetRegistrationId(string registrationId)
        {
            this.registrationId = registrationId;

        }
        public string GetEmail()
        {
            return athleteEmail;
        }
        public void SetEmail(string athleteEmail)
        {
            this.athleteEmail = athleteEmail;
        }
        public string GetName()
        {
            return athleteName;
        }
        public void SetName(string athleteName)
        {
            this.athleteName = athleteName;
        }
        public string GetSessionId()
        {
            return sessionId;
        }
        public void SetSessionId(string sessionId)
        {
            this.sessionId = sessionId;
        }
        public string GetRegistrationDate()
        {
            return registrationDate;
        }
        public void SetRegistrationDate(string registrationDate)
        {
            this.registrationDate = registrationDate;
        }
        public bool GetIsCompleted()
        {
            return isCompleted;

        }
        public void SetIsCompleted(bool isCompleted)
        {
            this.isCompleted = isCompleted;
        }
        public static int GetCount()
        {
            return count;
        }
        public static void SetCount(int count)
        {
            count = count;
        }
        public static void IncCount()
        {
            count++;
        }
        public static void DecCount()
        {
            count--;
        }
       

        public string ToFile()
        {
            return $"{registrationId}#{athleteEmail}#{athleteName}#{sessionId}#{registrationDate}#{isCompleted}";
        }

        public override string ToString()
        {
            return $"RegID: {registrationId}\t{athleteName} ({athleteEmail})\tSession: {sessionId}\t" + $"Date: {registrationDate}\tCompleted: {isCompleted}";
        
        }
    }

}
