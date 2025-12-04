namespace PA53
{
    public class Session
    {
        private string sessionId;
        private string sportName;
        private int sessionLength; // minutes
        private string coachName;
        private double sessionPrice;
        private int sessionSeats;
        private bool isSoldOut;
        private bool isCompleted; // New field for manager completion

        public Session(string sessionId, string sportName, int sessionLength, string coachName, double sessionPrice, int sessionSeats, bool isSoldOut)
        {
            this.sessionId = sessionId;
            this.sportName = sportName;
            this.sessionLength = sessionLength;
            this.coachName = coachName;
            this.sessionPrice = sessionPrice;
            this.sessionSeats = sessionSeats;
            this.isSoldOut = isSoldOut;
            this.isCompleted = false;
        }

        // Getters and setters (keep as-is)
        public string GetSessionId() { return sessionId; }
        public string GetSportName() { return sportName; }
        public int GetSessionLength() { return sessionLength; }
        public string GetCoachName() { return coachName; }
        public double GetSessionPrice() { return sessionPrice; }
        public int GetSessionSeats() { return sessionSeats; }
        public bool GetIsSoldOut() { return isSoldOut; }
        public bool GetIsCompleted() { return isCompleted; }

        public void SetSportName(string name) { sportName = name; }
        public void SetSessionLength(int length) { sessionLength = length; }
        public void SetCoachName(string coach) { coachName = coach; }
        public void SetSessionPrice(double price) { sessionPrice = price; }
        public void SetSessionSeats(int seats) { sessionSeats = seats; }
        public void SetIsSoldOut(bool soldOut) { isSoldOut = soldOut; }
        public void SetIsCompleted(bool completed) { isCompleted = completed; }
    }

}