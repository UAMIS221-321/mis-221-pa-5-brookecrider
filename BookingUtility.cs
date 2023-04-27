namespace mis_221_pa_5_brookecrider
{
    public class BookingUtility
    {
        private Booking[] bookings;
        private ListingUtility listingUtility;
        private TrainerUtility trainerUtility;
        public BookingUtility(Booking[] bookings, ListingUtility listingUtility, TrainerUtility trainerUtility)
        {
            this.bookings = bookings;
            this.listingUtility = listingUtility;
            this.trainerUtility = trainerUtility;
        }

        public void GetAllBookings()
        {
            StreamReader inFile = new StreamReader("transactions.txt");
            Booking.SetSessionCount(0);
            string input = inFile.ReadLine();
            while (input != null && input != "")
            {
                string[] temp = input.Split('#');
                int sessionTemp = int.Parse(temp[0]);
                DateOnly dateTemp = DateOnly.Parse(temp[3]);
                int trainerIdTemp = int.Parse(temp[4]);
                int listingIdTemp = int.Parse(temp[7]);
                bookings[Booking.GetSessionCount()] = new Booking(sessionTemp, temp[1], temp[2], dateTemp, trainerIdTemp, temp[5], temp[6], listingIdTemp);
                Booking.IncSessionCount();
                input = inFile.ReadLine();
            }
            inFile.Close();
        }

        public void BookSession()
        {
            listingUtility.GetAllListing();
            trainerUtility.GetAllTrainers();
            System.Console.WriteLine("Enter the Listing ID that you would like to book.");
            int searchVal = int.Parse(Console.ReadLine());
            Listing listingInfo = listingUtility.FindListing(searchVal);
            string searchValue = listingInfo.GetTrainerName();
            Trainer trainerInfo = trainerUtility.FindTrainer(searchValue);
            bool isFound = false;
            while (isFound == false)
            {
                Booking myBooking = new Booking();
                System.Console.WriteLine("Enter your name");
                myBooking.SetSessionId();
                myBooking.SetCustomerName(Console.ReadLine());
                System.Console.WriteLine("Enter your email");
                myBooking.SetCustomerEmail(Console.ReadLine());
                myBooking.SetTrainingDate(listingInfo.GetSessionDate());
                myBooking.SetTrainerId(trainerInfo.GetTrainerId());
                myBooking.SetTrainerName(listingInfo.GetTrainerName());
                myBooking.SetStatus("Booked");
                myBooking.SetListingId(searchVal);
                bookings[Booking.GetSessionCount()] = myBooking;
                Booking.IncSessionCount();
                Save();
                listingInfo.IsAvailable();
                listingUtility.Save();
                isFound = true;
                System.Console.WriteLine($"Your session has been booked! Your Session Id is: {myBooking.GetSessionId()}");
                System.Console.WriteLine();
            }



        }

        public int Find(int searchVal)
        {
            for (int i = 0; i < Booking.GetSessionCount(); i++)
            {
                if (bookings[i].GetSessionId() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public void CompletedBooking()
        {
            System.Console.WriteLine("Please enter your Session ID");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                bookings[foundIndex].SetStatus("Completed");
                Save();
            }
            else
            {
                System.Console.WriteLine("Session ID not found");
            }
        }

        public void CancelBooking()
        {
            System.Console.WriteLine("Please enter your Session ID");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                bookings[foundIndex].SetStatus("Cancelled");
                Save();
            }
            else
            {
                System.Console.WriteLine("Session ID not found");
            }
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for (int i = 0; i < Booking.GetSessionCount(); i++)
            {
                outFile.WriteLine(bookings[i].ToFile());

            }
            outFile.Close();
        }

        public void Sort()
        {
            for (int i = 0; i < Booking.GetSessionCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Booking.GetSessionCount(); j++)
                {
                    if (bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName()) < 0 || bookings[j].GetCustomerName() == bookings[min].GetCustomerName() && bookings[j].GetTrainingDate() < bookings[min].GetTrainingDate())
                    {
                        min = j;
                    }
                }
                    if (min != i)
                    {
                        Swap(min, i);
                    }
            }
        }

        public void SortByDate()
        {
            for (int i = 0; i < Booking.GetSessionCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Booking.GetSessionCount(); j++)
                {
                    if (bookings[min].GetTrainingDate().CompareTo(bookings[j].GetTrainingDate()) > 0)
                    {
                        min = j;
                    }
                }
                 if (min != i)
                    {
                        Swap(min, i);
                    }
            }
        }

        public void Swap(int x, int y)
        {
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }
    }
}