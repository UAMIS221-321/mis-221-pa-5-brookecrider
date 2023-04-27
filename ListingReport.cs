namespace mis_221_pa_5_brookecrider
{
    public class ListingReport
    {
        Listing[] listings;

        public ListingReport(Listing[] listings)
        {
            this.listings = listings;
        }

        public void PrintAllListings()
        {
            for (int i = 0; i < Listing.GetListingCount(); i++)
            {
                if (listings[i].GetIsDeleted() == false)
                {
                    System.Console.WriteLine(listings[i].ToString());
                }
            }
        }

        public void PrintAllAvailableListings()
        {
            for (int i = 0; i < Listing.GetListingCount(); i++)
            {
                if (listings[i].GetIsDeleted() == false)
                {
                    if (listings[i].ListingAvailability() == true)
                    {
                        System.Console.WriteLine(listings[i].ToString());
                    }
                }
            }
        }
    }
}