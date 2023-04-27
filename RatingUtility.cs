namespace mis_221_pa_5_brookecrider
{
    public class RatingUtility
    {
        private Rating[] ratings;
        private TrainerUtility trainerUtility;
        public RatingUtility(Rating[] ratings, TrainerUtility trainerUtility)
        {
            this.ratings = ratings;
            this.trainerUtility = trainerUtility;
        }

        public void GetAllRatings()
        {
            StreamReader inFile = new StreamReader("ratings.txt");
            Rating.SetRatingCount(0);
            string input = inFile.ReadLine();
            while (input != null && input != "")
            {
                string[] temp = input.Split('#');
                int ratingTemp = int.Parse(temp[0]);
                int trainerIdTemp = int.Parse(temp[2]);
                ratings[Rating.GetRatingCount()] = new Rating(ratingTemp, temp[1], trainerIdTemp, temp[3], temp[4]);
                Rating.IncRatingCount();
                input = inFile.ReadLine();
            }
            inFile.Close();
        }

        public void AddRating(){
            trainerUtility.GetAllTrainers();
            Rating newRating = new Rating();
            System.Console.WriteLine("Please enter your name.");
            newRating.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("Enter the name of your trainer");
            string searchValue = Console.ReadLine();
            Trainer trainerInfo = trainerUtility.FindTrainer(searchValue);
            bool isFound= false;
            while(isFound == false){
                newRating.SetRatingId(); 
                newRating.SetTrainerId(trainerInfo.GetTrainerId());
                System.Console.WriteLine($"Enter 1 if the trainer failed to meet all your excpectations\nEnter 2 if the trainer met very few expectaions\nEnter 3 if the trainer was mediocre and met half of your expectations at best\nEnter 4 if the trainer met almost all expectaions\nEnter 5 if your trainer was excellent and met and exceeded all expectations");
                string userRating = Console.ReadLine();
                while(userRating != "1" && userRating != "2" && userRating != "3" && userRating != "4" && userRating != "5") {
                    System.Console.WriteLine("Invalid Rating!");
                    System.Console.WriteLine($"Enter 1 if the trainer failed to meet all your expectations\nEnter 2 if the trainer met very few expectaions\nEnter 3 if the trainer was mediocre and met half of your expectations at best\nEnter 4 if the trainer met almost all expectaions\nEnter 5 if your trainer was excellent and met and exceeded all expectations");
                    userRating= Console.ReadLine();
                }
                if(userRating == "1"){
                    newRating.SetRating("Failed to meet all expectations");
                }   
                if(userRating == "2"){
                    newRating.SetRating("Met very few expectaions");
                }
                if(userRating == "3"){
                    newRating.SetRating("Mediocre and met half of expectations at best");
                }
                if(userRating == "4"){
                    newRating.SetRating("Met almost all expectaions");
                }
                if(userRating == "5"){
                    newRating.SetRating("Excellent and met and exceeded all expectations");
                }
                ratings[Rating.GetRatingCount()] = newRating;
                Rating.IncRatingCount();
                Save();
                isFound = true;
                
            }


        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("ratings.txt");
            for (int i = 0; i < Rating.GetRatingCount(); i++)
            {
                outFile.WriteLine(ratings[i].ToFile());

            }
            outFile.Close();
        }
    }
}