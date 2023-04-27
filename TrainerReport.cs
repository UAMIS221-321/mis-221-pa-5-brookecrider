namespace mis_221_pa_5_brookecrider
{
    public class TrainerReport
    {
        Trainer[] trainers;

        public TrainerReport(Trainer[] trainers)
        {
            this.trainers = trainers;
        }

        public void PrintAllTrainers()
        {
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                if (trainers[i].GetIsDeleted() == false)
                {
                    System.Console.WriteLine(trainers[i].ToString());
                }
            }
        }
    }
}