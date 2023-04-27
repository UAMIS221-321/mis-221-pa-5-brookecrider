namespace mis_221_pa_5_brookecrider
{
    public class Trainer
    {
        private int trainerId;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmail;
        private bool isDeleted = false;
        static private int count;

        public Trainer()
        {

        }

        public Trainer(int trainerId, string trainerName, string mailingAddress, string trainerEmail, bool isDeleted)
        {
            this.trainerId = count + 1;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.trainerEmail = trainerEmail;
            this.isDeleted = isDeleted;
        }

        public void SetTrainerId()
        {
            this.trainerId = count + 1;
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

        public void SetMailingAddress(string mailingAddress)
        {
            this.mailingAddress = mailingAddress;
        }

        public string GetMailingAddress()
        {
            return mailingAddress;
        }

        public void SetTrainerEmail(string trainerEmail)
        {
            this.trainerEmail = trainerEmail;
        }

        public string GetTrainerEmail()
        {
            return trainerEmail;
        }

        public bool GetIsDeleted()
        {
            return isDeleted;
        }

        public void IsDeleted()
        {
            isDeleted = !isDeleted;
        }

        static public void SetCount(int count)
        {
            Trainer.count = count;
        }

        static public void IncCount()
        {
            Trainer.count++;
        }
        static public int GetCount()
        {
            return Trainer.count;
        }
        public string ToFile()
        {
            return $"{trainerId}#{trainerName}#{mailingAddress}#{trainerEmail}#{isDeleted}";
        }

        public override string ToString() {
            return $"Trainer ID:{trainerId}  Trainer Name:{trainerName}  Trainer Mailing Address:{mailingAddress}  Trainer Email:{trainerEmail}";

        }

    }
}