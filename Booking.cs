namespace mis_221_pa_5_brookecrider
{
    public class Booking
    {
        private int sessionId;
        private string customerName;
        private string customerEmail;
        private DateOnly trainingDate;
        private int trainerId;
        private string trainerName;
        private string status;
        private int listingId;
        static private int sessionCount;

        public Booking()
        {

        }

        public Booking(int sessionId, string customerName, string customerEmail, DateOnly trainingDate, int trainerId, string trainerName, string status, int listingId)
        {
            this.sessionId = sessionCount + 1;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.status = status;
            this.listingId = listingId;
        }

        public void SetSessionId()
        {
            this.sessionId = sessionCount + 1;
        }

        public int GetSessionId()
        {
            return sessionId;
        }

        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail()
        {
            return customerEmail;
        }

        public void SetTrainingDate(DateOnly trainingDate)
        {
            this.trainingDate = trainingDate;
        }

        public DateOnly GetTrainingDate()
        {
            return trainingDate;
        }

        public void SetTrainerId(int trainerId)
        {
            this.trainerId = trainerId;
        }

        public int GetTrainerId()
        {
            return trainerId;
        }

        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }

        public string GetStatus()
        {
            return status;
        }

        public void SetListingId(int listingId){
            this.listingId = listingId;
        }

        public int GetListingId() {
            return listingId;
        }

        static public void SetSessionCount(int sessionCount)
        {
            Booking.sessionCount = sessionCount;
        }

        static public void IncSessionCount()
        {
            Booking.sessionCount++;
        }

        static public int GetSessionCount()
        {
            return sessionCount;
        }

        public override string ToString()
        {
            return $"Session ID:{sessionId}  Customer Name:{customerName}  Customer Email:{customerEmail}  Training Date:{trainingDate}  Trainer ID:{trainerId}  Status:{status}";
        }

        public string ToFile()
        {
            return $"{sessionId}#{customerName}#{customerEmail}#{trainingDate}#{trainerId}#{trainerName}#{status}#{listingId}";
        }

    }
}