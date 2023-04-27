namespace mis_221_pa_5_brookecrider
{
    public class Rating
    {
        private int ratingId;
        private string customerName;
        private int trainerId;
        private string trainerName;
        private string rating;
        static private int ratingCount;

        public Rating() {

        }

        public Rating(int ratingId, string customerName, int trainerId, string trainerName, string rating){
            this.ratingId = ratingCount + 1;
            this.customerName = customerName;
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.rating = rating;
        }

        public void SetRatingId()
        {
            this.ratingId = ratingCount + 1;
        }

        public int GetRatingId()
        {
            return ratingId;
        }

        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public string GetCustomerName()
        {
            return customerName;
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

        public void SetRating(string rating){
            this.rating = rating;
        }

        public string GetRating(){
            return rating;
        }

        static public void SetRatingCount(int ratingCount)
        {
            Rating.ratingCount = ratingCount;
        }

        static public void IncRatingCount()
        {
            Rating.ratingCount++;
        }

        static public int GetRatingCount()
        {
            return ratingCount;
        }

        public override string ToString() {
            return $"Rating ID:{ratingId}  Customer Name:{customerName}  Trainer ID:{trainerId}  Trainer Name:{trainerName}  Rating:{rating}";
        }

        public string ToFile() {
            return $"{ratingId}#{customerName}#{trainerId}#{trainerName}#{rating}";
        }
    }
}