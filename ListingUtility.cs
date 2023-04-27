namespace mis_221_pa_5_brookecrider
{
    public class ListingUtility
    {
        private Listing[] listings;
        
        public ListingUtility(Listing[] listings)
        {
            this.listings = listings;
        }

        public void GetAllListing()
        {
            StreamReader inFile = new StreamReader("listings.txt");
            Listing.SetListingCount(0);
            string input = inFile.ReadLine();
            while (input != null && input != "")
            {
                string[] temp = input.Split('#');
                int listingTemp = int.Parse(temp[0]);
                DateOnly dateTemp = DateOnly.Parse(temp[2]);
                TimeOnly timeTemp = TimeOnly.Parse(temp[3]);
                int costTemp = int.Parse(temp[4]);
                bool availabiltyTemp = bool.Parse(temp[5]);
                bool isDeletedTemp = bool.Parse(temp[6]);
                listings[Listing.GetListingCount()] = new Listing(listingTemp, temp[1], dateTemp, timeTemp, costTemp, availabiltyTemp, isDeletedTemp);
                Listing.IncListingCount();
                input = inFile.ReadLine();
            }
            inFile.Close();
        }

        public void AddListing()
        {
            System.Console.WriteLine("Enter trainer name");
            Listing myListing = new Listing();
            myListing.SetListingId();
            myListing.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Enter date of the session in mm/dd/year format");
            myListing.SetSessionDate(DateOnly.Parse(Console.ReadLine()));
            System.Console.WriteLine("Enter time of the session");
            myListing.SetSessionTime(TimeOnly.Parse(Console.ReadLine()));
            System.Console.WriteLine("Enter cost of the session");
            Console.Write('$');
            myListing.SetSessionCost(int.Parse(Console.ReadLine()));
            listings[Listing.GetListingCount()] = myListing;
            Listing.IncListingCount();
            Save();

        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");
            for (int i = 0; i < Listing.GetListingCount(); i++)
            {
                outFile.WriteLine(listings[i].ToFile());

            }
            outFile.Close();
        }

        public int Find(int searchVal)
        {
            for (int i = 0; i < Listing.GetListingCount(); i++)
            {
                if (listings[i].GetListingId() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public Listing FindListing(int searchVal) {
            Listing listing = new Listing(); 
            for(int i=0; i < Listing.GetListingCount(); i++){
                if(listings[i].GetListingId() == searchVal) {
                    listing = listings[i]; 
                }
            
            }
            return listing;
        }

        public Listing FindListingRevenue(string searchVal) {
            Listing listing = new Listing();
                for(int i=0; i < Listing.GetListingCount(); i++){
                if(listings[i].GetTrainerName() == searchVal) {
                    listing = listings[i]; 
                }
            
            }
            return listing;
        }

        public void UpdateListing()
        {
            
            System.Console.WriteLine("Enter the ID of the listing you would like to edit.");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                System.Console.WriteLine("Please enter trainer name");
                listings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter date of the session in mm/dd/yyyy format");
                listings[foundIndex].SetSessionDate(DateOnly.Parse(Console.ReadLine()));
                System.Console.WriteLine("Enter time of the session");
                listings[foundIndex].SetSessionTime(TimeOnly.Parse(Console.ReadLine()));
                Console.Write('$');
                System.Console.WriteLine("Enter the cost of the session");
                listings[foundIndex].SetSessionCost(int.Parse(Console.ReadLine()));
                Save();
            }
            else
            {
                System.Console.WriteLine("Listing ID not found");
            }
        }

        public void DeleteListing()
        {
            
            System.Console.WriteLine("Enter the ID of the listing you would like to delete.");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                listings[foundIndex].IsDeleted();
                Save();
            }
            else
            {
                System.Console.WriteLine("Listing ID not found");
            }
        }

        public void AvailabilityChange()
        {
            System.Console.WriteLine("Enter the ID of the listing you would like to book.");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1)
            {
                listings[foundIndex].IsAvailable();
                Save();
            }
            else
            {
                System.Console.WriteLine("Listing ID not found");
            }
        }
    }
}