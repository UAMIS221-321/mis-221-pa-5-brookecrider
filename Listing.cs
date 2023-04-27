namespace mis_221_pa_5_brookecrider
{
    public class Listing
    {
        private int listingId;
        private string trainerName;
        private DateOnly sessionDate;
        private TimeOnly sessionTime;
        private int sessionCost;
        private bool listingAvailability = true;
        private bool isDeleted= false; 
        static private int listingCount;

        public Listing()
        {

        }

        public Listing(int listingId, string trainerName, DateOnly sessionDate, TimeOnly sessionTime, int sessionCost, bool listingAvailability,bool isDeleted)
        {
            this.listingId = listingCount + 1;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionCost = sessionCost;
            this.listingAvailability = listingAvailability;
            this.isDeleted = isDeleted;
        }

        public void SetListingId()
        {
            this.listingId = listingCount + 1;
        }

        public int GetListingId()
        {
            return listingId;
        }

        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public void SetSessionDate(DateOnly sessionDate)
        {
            this.sessionDate = sessionDate;
        }

        public DateOnly GetSessionDate()
        {
            return sessionDate;
        }

        public void SetSessionTime(TimeOnly sessionTime)
        {
            this.sessionTime = sessionTime;
        }

        public TimeOnly GetSessionTime()
        {
            return sessionTime;
        }

        public void SetSessionCost(int sessionCost)
        {
            this.sessionCost = sessionCost;
        }

        public int GetSessionCost()
        {
            return sessionCost;
        }

        public bool ListingAvailability()
        {
            return listingAvailability;
        }

        public void IsAvailable()
        {
            listingAvailability = !listingAvailability;
        }

        public bool GetIsDeleted()
        {
            return isDeleted;
        }

        public void IsDeleted()
        {
            isDeleted = !isDeleted;
        }

        static public void SetListingCount(int listingCount)
        {
            Listing.listingCount = listingCount;
        }

        static public void IncListingCount()
        {
            Listing.listingCount++;
        }

        static public int GetListingCount()
        {
            return Listing.listingCount;
        }

        public string ToFile()
        {
            return $"{listingId}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{listingAvailability}#{isDeleted}";
        }

        public override string ToString() {
                return $"Listing ID:{listingId} Trainer Name:{trainerName} Session Date:{sessionDate} Session Time{sessionTime} Session Cost:${sessionCost} Listing Availability:{listingAvailability}";
        }


    }
}