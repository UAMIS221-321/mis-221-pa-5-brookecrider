namespace mis_221_pa_5_brookecrider
{
    public class RatingReport
    {
        Rating[] ratings;

        public RatingReport(Rating[] ratings)
        {
            this.ratings = ratings;
        }

        public void PrintAllListings()
        {
            for (int i = 0; i < Rating.GetRatingCount(); i++)
            {
                    System.Console.WriteLine(ratings[i].ToString());
            }
        }

        public void RatingsByTrainer() {
            System.Console.WriteLine("Please enter the trainer name of the ratings you would like to view");
            string currTrainer = Console.ReadLine();
            for(int i=0; i< Rating.GetRatingCount(); i++) {
                if(ratings[i].GetTrainerName() == currTrainer) {
                    System.Console.WriteLine(ratings[i].ToString());
                }
            }
            System.Console.WriteLine("Enter 1 if you would like to save this report\nEnter 2 if you do not want to save this report");
            string saveChoice = Console.ReadLine();
            while(saveChoice != "1" && saveChoice != "2"){
                System.Console.WriteLine("Invalid input!");
                System.Console.WriteLine("Enter 1 if you would like to save this report\nEnter 2 if you do not want to save this report");
                saveChoice = Console.ReadLine();
            }
             if(saveChoice == "1"){
                System.Console.WriteLine("Enter the name of the file you would like to save this report to.");
                string outFile = Console.ReadLine();
                StreamWriter newFile = new StreamWriter(outFile);
                for(int i=0; i< Rating.GetRatingCount(); i++) {
                    if(ratings[i].GetTrainerName() == currTrainer) {
                        newFile.WriteLine(ratings[i].ToString());
                }
                }
                newFile.Close();
             }

        }
    }
}