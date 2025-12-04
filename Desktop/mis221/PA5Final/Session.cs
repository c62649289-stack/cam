namespace PA5Final
{
    public class Session
    {
        private string sessionId;
        private string sportName;
        private int sessionLength;
        private string coachName;
        private double sessionPrice;
        private int seats;
        private bool isFull;
        static private int count;
        public Session()
        {
            
        }
        public Session(string sessionId, string sportName, int sessionLength, string coachName, double sessionPrice, int seats, bool isFull)
        {
            this.sportName = sportName;
            this.sessionLength = sessionLength;
            this.sessionId = sessionId;
            this.coachName = coachName;
            this.sessionPrice = sessionPrice;
            this.isFull = isFull;
            this.seats = seats;
        }
        public string GetSportName()
        {
            return sportName;
        }
        public void SetSportName(string sportName)
        {
            this.sportName = sportName;

        }
        public int GetSessionLength()
        {
            return sessionLength;
        }
        public void SetSessionLength(int sessionLength)
        {
            this.sessionLength = sessionLength;
        }
        public string GetSessionId()
        {
            return sessionId;
        }
        public void SetSessionId(string sessionId)
        {
            this.sessionId = sessionId;
        }
        public string GetCoachName()
        {
            return coachName;
        }
        public void SetCoachName()
        {
            this.coachName = coachName;
        }
        public double GetSessionPrice()
        {
            return sessionPrice;
        }
        public void SetSessionPrice(double price)
        {
            this.sessionPrice = price;
        }
        public bool GetIsFull()
        {
            return isFull;

        }
        public void SetFull(bool full)
        {
            this.isFull = full;
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
        public int CompareTo(Session other, string sortBy)
        {
            sortBy = sortBy.ToUpper();
            if(sortBy == "SPORTNAME")
            {
                return this.sportName.CompareTo(other.sportName());
            }
            
            if(sortBy == "COACHNAME")
            {
                return this.coachName.CompareTo(other.coachName());
            }
            
            if(sortBy == "Price")
            {
                return this.sessionPrice.CompareTo(other.sessionPrice());
            }
            return this.sessionId.CompareTo(other.sessionId);
        }
        public int CompareTo(string sessionId)
        {
            return this.sessionId.CompareTo(sessionId);
        }
        public override string ToString()
        {
            return $"{sessionId}\t{sportName}\t{sessionLength}\t{coachName}\t{sessionPrice}\t{seats}\t{isFull}";
        }
        public string ToFile()
        {
            return $"{sessionId}#{sportName}#{sessionLength}#{coachName}#{sessionPrice}#{seats}#{isFull}";
        }

       
    }
}