namespace mis_221_pa_5_brookecrider
{
    public class TrainerUtility
    {
        private Trainer[] trainers;
         

        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }

        public void GetAllTrainers()
        {
            StreamReader inFile = new StreamReader("trainers.txt");
            Trainer.SetCount(0); 
            string input = inFile.ReadLine();
            while (input != null)
            {
                string[] temp = input.Split('#');
                int tempId = int.Parse(temp[0]);
                bool tempIsDeleted = bool.Parse(temp[4]);
                trainers[Trainer.GetCount()] = new Trainer(tempId, temp[1], temp[2], temp[3], tempIsDeleted);
                Trainer.IncCount();
                input = inFile.ReadLine();
            }
            inFile.Close();
        
        }

        public void AddTrainer()
        {
            
            System.Console.WriteLine("Enter trainer name");
            Trainer myTrainer = new Trainer();
            myTrainer.SetTrainerId();
            myTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Enter trainer mailing address");
            myTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("Enter trainer email address");
            myTrainer.SetTrainerEmail(Console.ReadLine());
            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();
            Save();

        }


        public void Save()
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].ToFile());

            }
            outFile.Close();
        }

        public int Find(int searchVal)
        {
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                if (trainers[i].GetTrainerId() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public Trainer FindTrainer(string searchValue) {
            Trainer trainer = new Trainer(); 
            for(int i=0; i < Trainer.GetCount(); i++){
                if(trainers[i].GetTrainerName() == searchValue) {
                     trainer = trainers[i]; 
                }
            
            }
            return trainer;
        }
        public void UpdateTrainer()
        {
            
            System.Console.WriteLine("Enter the ID of the trainer you would like to edit.");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                System.Console.WriteLine("Please enter trainer name");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter mailing address");
                trainers[foundIndex].SetMailingAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter email address");
                trainers[foundIndex].SetTrainerEmail(Console.ReadLine());

                Save();
            }
            else
            {
                System.Console.WriteLine("Trainer ID not found");
            }
        }

        public void DeleteTrainer()
        {
             
            System.Console.WriteLine("Enter the ID of the trainer you would like to delete.");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                trainers[foundIndex].IsDeleted();
                Save();
            }
            else
            {
                System.Console.WriteLine("Trainer ID not found");
            }
        }
    }
}


