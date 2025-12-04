namespace PA53
{
    public class Registration
    {
        private string registrationId;
        private string athleteEmail;
        private string athleteName;
        private string sessionId;
        private string registrationDate;
        private string completionStatus;

        public Registration(string registrationId, string athleteEmail, string athleteName, string sessionId, string registrationDate, string completionStatus)
        {
            this.registrationId = registrationId;
            this.athleteEmail = athleteEmail;
            this.athleteName = athleteName;
            this.sessionId = sessionId;
            this.registrationDate = registrationDate;
            this.completionStatus = completionStatus;
        }

        public string GetRegistrationId() { return registrationId; }
        public string GetEmail() { return athleteEmail; }
        public string GetName() { return athleteName; }
        public string GetSessionId() { return sessionId; }
        public string GetRegistrationDate() { return registrationDate; }
        public string GetCompletionStatus() { return completionStatus; }

        public void SetEmail(string email) { athleteEmail = email; }
        public void SetName(string name) { athleteName = name; }
        public void SetSessionId(string id) { sessionId = id; }
        public void SetRegistrationDate(string date) { registrationDate = date; }
        public void SetCompletionStatus(string status) { completionStatus = status; }
    }

}