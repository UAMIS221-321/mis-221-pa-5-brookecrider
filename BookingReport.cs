namespace mis_221_pa_5_brookecrider
{
    public class BookingReport
    {
        Booking[] bookings;
        private ListingUtility listingUtility;
        private BookingUtility bookingUtility;

        public BookingReport(Booking[] bookings, ListingUtility listingUtility, BookingUtility bookingUtility)
        {
            this.bookings = bookings;
            this.listingUtility = listingUtility;
            this.bookingUtility = bookingUtility;
        }

        public void SessionsByCustomer()
        {
            System.Console.WriteLine("Please enter the customer email address");
            string currCustomer = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < Booking.GetSessionCount(); i++)
            {
                if (bookings[i].GetCustomerEmail() == currCustomer)
                {
                    System.Console.WriteLine(bookings[i].ToString());
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Enter 1 if you would like to save this report to a file\nEnter 2 to exit");
            string saveChoice = Console.ReadLine();
            while (saveChoice != "1" && saveChoice != "2")
            {
                System.Console.WriteLine("Invalid input!");
                System.Console.WriteLine("Enter 1 if you would like to save this report to a file\nEnter 2 to exit");
                saveChoice = Console.ReadLine();
            }
            if (saveChoice == "1")
            {
                System.Console.WriteLine("Enter the name of the file you would like to save this report to.");
                string outFile = Console.ReadLine();
                StreamWriter newFile = new StreamWriter(outFile);
                for (int i = 0; i < Booking.GetSessionCount(); i++)
                {
                    if (bookings[i].GetCustomerEmail() == currCustomer)
                    {
                        newFile.WriteLine(bookings[i].ToString());
                    }
                }
                newFile.Close();
            }

        }

        public void HistoricalCustomerSessions()
        {
            bookingUtility.Sort();
            string currentCustomer = bookings[0].GetCustomerName();
            int count = 0;
            for (int i = 0; i < Booking.GetSessionCount(); i++)
            {
                if (bookings[i].GetCustomerName() == currentCustomer)
                {
                    count++;
                }
                else
                {
                    ProcessBreak(ref currentCustomer, ref count, bookings[i]);
                }
                System.Console.WriteLine(bookings[i].ToString());
            }
            ProcessBreak(currentCustomer, count);
            System.Console.WriteLine();
            System.Console.WriteLine("Enter 1 if you would like to save this report to a file\nEnter 2 to exit");
            string saveChoice = Console.ReadLine();
            while(saveChoice != "1" && saveChoice != "2"){
                System.Console.WriteLine("Invalid input!");
                System.Console.WriteLine("Enter 1 if you would like to save this report to a file\nEnter 2 to exit");
                saveChoice = Console.ReadLine();
            }
            if(saveChoice == "1"){
                System.Console.WriteLine("Enter the name of the file you would like to save this report to.");
                string outFile = Console.ReadLine();
                StreamWriter newFile = new StreamWriter(outFile);
                currentCustomer = bookings[0].GetCustomerName();
                count = 0;
                for(int i = 0; i < Booking.GetSessionCount(); i++) {
                if(bookings[i].GetCustomerName() == currentCustomer) {
                    count++;
                } else{
                    newFile.WriteLine(ProcessBreakFile(ref currentCustomer, ref count, bookings[i]));
                }
                newFile.WriteLine(bookings[i].ToString());
            }
            newFile.WriteLine(ProcessBreakFile(currentCustomer, count));
            newFile.Close();
            }

        }

        public string ProcessBreak(ref string currentCustomer, ref int count, Booking newBooking)
        {
            System.Console.WriteLine($"{currentCustomer} had {count} sessions.");
            string writeline = $"{currentCustomer} had {count} sessions.";
            currentCustomer = newBooking.GetCustomerName();
            count = 1;
            return writeline;
        }

        public string ProcessBreak(string currentCustomer, int count)
        {
            System.Console.WriteLine($"{currentCustomer} had {count} sessions.");
            string writeline = $"{currentCustomer} had {count} sessions.";
            return writeline;
        }

        public string ProcessBreakFile(ref string currentCustomer, ref int count, Booking newBooking)
        {
            string writeline = $"{currentCustomer} had {count} sessions.";
            currentCustomer = newBooking.GetCustomerName();
            count = 1;
            return writeline;
        }

        public string ProcessBreakFile(string currentCustomer, int count)
        {
            string writeline = $"{currentCustomer} had {count} sessions.";
            return writeline;
        }

        public void HistoricalRevenueByMonthByYear()
        {
            bookingUtility.SortByDate();
            listingUtility.GetAllListing();
            int currentMonth = bookings[0].GetTrainingDate().Month;
            int currentYear = bookings[0].GetTrainingDate().Year;
            int searchVal = bookings[0].GetListingId();
            Listing listingInfo = listingUtility.FindListing(searchVal);
            int currMonthRevenue = listingInfo.GetSessionCost();
            int currYearRevenue = listingInfo.GetSessionCost();
            for (int i = 1; i < Booking.GetSessionCount(); i++)
            {
                if (bookings[i].GetStatus() != "Cancelled")
                {
                    if (bookings[i].GetTrainingDate().Year == currentYear)
                    {
                        searchVal = bookings[i].GetListingId();
                        listingInfo = listingUtility.FindListing(searchVal);
                        currYearRevenue += listingInfo.GetSessionCost();
                        if (bookings[i].GetTrainingDate().Month == currentMonth)
                        {
                            currMonthRevenue += listingInfo.GetSessionCost();
                        }
                        else
                        {
                            ProcessMonthBreak(ref currentMonth, ref currMonthRevenue, bookings[i], ref searchVal, ref listingInfo);
                        }
                    }
                    else
                    {
                        ProcessMonthBreak(ref currentMonth, ref currMonthRevenue, bookings[i], ref searchVal, ref listingInfo);
                        ProcessYearBreak(ref currentYear, ref currYearRevenue, bookings[i], ref searchVal, ref listingInfo);
                    }
                }
            }
            ProcessMonthBreak(currentMonth, currMonthRevenue);
            ProcessYearBreak(currentYear, currYearRevenue);
            System.Console.WriteLine();
            System.Console.WriteLine("Enter 1 if you would like to save this report to a file\nEnter 2 to exit");
            string saveChoice = Console.ReadLine();
            while(saveChoice != "1" && saveChoice != "2"){
                System.Console.WriteLine("Invalid input!");
                System.Console.WriteLine("Enter 1 if you would like to save this report to a file\nEnter 2 to exit");
                saveChoice = Console.ReadLine();
            }
            if(saveChoice == "1"){
                System.Console.WriteLine("Enter the name of the file you would like to save this report to.");
                string outFile = Console.ReadLine();
                StreamWriter newFile = new StreamWriter(outFile);
                bookingUtility.SortByDate();
                listingUtility.GetAllListing();
                currentMonth = bookings[0].GetTrainingDate().Month;
                currentYear = bookings[0].GetTrainingDate().Year;
                searchVal = bookings[0].GetListingId();
                listingInfo = listingUtility.FindListing(searchVal);
                currMonthRevenue = listingInfo.GetSessionCost();
                currYearRevenue = listingInfo.GetSessionCost();
                for (int i = 1; i < Booking.GetSessionCount(); i++)
                {
                if (bookings[i].GetStatus() != "Cancelled")
                {
                    if (bookings[i].GetTrainingDate().Year == currentYear)
                    {
                        searchVal = bookings[i].GetListingId();
                        listingInfo = listingUtility.FindListing(searchVal);
                        currYearRevenue += listingInfo.GetSessionCost();
                        if (bookings[i].GetTrainingDate().Month == currentMonth)
                        {
                            currMonthRevenue += listingInfo.GetSessionCost();
                        }
                        else
                        {
                            newFile.WriteLine(ProcessMonthBreakFile(ref currentMonth, ref currMonthRevenue, bookings[i], ref searchVal, ref listingInfo));
                        }
                    }
                    else
                    {
                        newFile.WriteLine(ProcessMonthBreakFile(ref currentMonth, ref currMonthRevenue, bookings[i], ref searchVal, ref listingInfo));
                        newFile.WriteLine(ProcessYearBreakFile(ref currentYear, ref currYearRevenue, bookings[i], ref searchVal, ref listingInfo));
                    }
                }
            }
            newFile.WriteLine(ProcessMonthBreakFile(currentMonth, currMonthRevenue));
            newFile.WriteLine(ProcessYearBreakFile(currentYear, currYearRevenue));
            newFile.Close();
            }

        }

        public string ProcessMonthBreak(ref int currentMonth, ref int currMonthRevenue, Booking newBooking, ref int searchVal, ref Listing listingInfo)
        {
            System.Console.WriteLine($"Month {currentMonth}  Revenue: {currMonthRevenue}");
            string writeline = $"Month {currentMonth}  Revenue: {currMonthRevenue}";
            currentMonth = newBooking.GetTrainingDate().Month;
            searchVal = newBooking.GetListingId();
            listingInfo = listingUtility.FindListing(searchVal);
            currMonthRevenue = listingInfo.GetSessionCost();
            return writeline;
        }

        public string ProcessYearBreak(ref int currentYear, ref int currYearRevenue, Booking newBooking, ref int searchVal, ref Listing listingInfo)
        {
            System.Console.WriteLine($"{currentYear} Revenue: {currYearRevenue}");
            string writeline = $"{currentYear} Revenue: {currYearRevenue}";
            currentYear = newBooking.GetTrainingDate().Year;
            searchVal = newBooking.GetListingId();
            listingInfo = listingUtility.FindListing(searchVal);
            currYearRevenue = listingInfo.GetSessionCost();
            return writeline;
        }

        public string ProcessMonthBreak(int currentMonth, int currMonthRevenue)
        {
            System.Console.WriteLine($"Month {currentMonth} Revenue: {currMonthRevenue}");
            string writeline = $"Month {currentMonth} Revenue: {currMonthRevenue}";
            return writeline;
        }

        public string ProcessYearBreak(int currentYear, int currYearRevenue)
        {
            System.Console.WriteLine($"{currentYear} Revenue: {currYearRevenue}");
            string writeline = $"{currentYear} Revenue: {currYearRevenue}";
            return writeline;
        }

        public string ProcessMonthBreakFile(ref int currentMonth, ref int currMonthRevenue, Booking newBooking, ref int searchVal, ref Listing listingInfo)
        {
            string writeline = $"Month {currentMonth} Revenue: {currMonthRevenue}";
            currentMonth = newBooking.GetTrainingDate().Month;
            searchVal = newBooking.GetListingId();
            listingInfo = listingUtility.FindListing(searchVal);
            currMonthRevenue = listingInfo.GetSessionCost();
            return writeline;
        }

        public string ProcessYearBreakFile(ref int currentYear, ref int currYearRevenue, Booking newBooking, ref int searchVal, ref Listing listingInfo)
        {
            string writeline = $"{currentYear} Revenue: {currYearRevenue}";
            currentYear = newBooking.GetTrainingDate().Year;
            searchVal = newBooking.GetListingId();
            listingInfo = listingUtility.FindListing(searchVal);
            currYearRevenue = listingInfo.GetSessionCost();
            return writeline;
        }

        public string ProcessMonthBreakFile(int currentMonth, int currMonthRevenue)
        {
            string writeline = $"Month {currentMonth} Revenue: {currMonthRevenue}";
            return writeline;
        }

        public string ProcessYearBreakFile(int currentYear, int currYearRevenue)
        {
            string writeline = $"{currentYear} Revenue: {currYearRevenue}";
            return writeline;
        }
    }
}