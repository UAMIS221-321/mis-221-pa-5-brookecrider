using mis_221_pa_5_brookecrider;

Trainer[] trainers = new Trainer[100];
TrainerUtility utility = new TrainerUtility(trainers);
TrainerReport report = new TrainerReport(trainers);
Listing[] listings = new Listing[100];
ListingUtility listUtility = new ListingUtility(listings);
ListingReport listReport = new ListingReport(listings);
Booking[] bookings = new Booking[100];
BookingUtility bookingUtility = new BookingUtility(bookings, listUtility, utility);
BookingReport bookingReport = new BookingReport(bookings, listUtility, bookingUtility);
Rating[] ratings = new Rating[100];
RatingUtility ratingUtility = new RatingUtility(ratings, utility);
RatingReport ratingReport = new RatingReport(ratings);

//start main


string userChoice = GetUserChoice();
while (userChoice != "6")
{
    RouteMenu(userChoice);
    userChoice = GetUserChoice();
}

//end main

//main menu

string GetUserChoice()
{
    DisplayMenu();
    string userChoice = Console.ReadLine();
    if (IsValidChoice(userChoice))
    {
        return userChoice;
    }
    return "-1";
}

static void DisplayMenu()
{
    Console.Clear();
    string title = @"
    _________ __          ______           _       _            
   / ____/ (_) /____     /_  __/________ _(_)___  (_)___  ____ _
  / __/ / / / __/ _ \     / / / ___/ __ `/ / __ \/ / __ \/ __ `/
 / /___/ / / /_/  __/    / / / /  / /_/ / / / / / / / / / /_/ / 
/_____/_/_/\__/\___/    /_/ /_/   \__,_/_/_/ /_/_/_/ /_/\__, /  
                                                       /____/   
    ";
    System.Console.WriteLine(title);
    System.Console.WriteLine("Welcome to Elite Training!");
    System.Console.WriteLine();
    System.Console.WriteLine("Enter 1 to Manage Trainer Data\nEnter 2 to Manage Listing Data\nEnter 3 to Book a Session\nEnter 4 to Run Reports\nEnter 5 to Rate a Trainer\nEnter 6 to Exit");
}

static bool IsValidChoice(string userChoice)
{
    if (userChoice == "1" || userChoice == "2" || userChoice == "3" || userChoice == "4" || userChoice == "5" || userChoice == "6")
    {
        return true;
    }
    return false;
}

void RouteMenu(string userChoice)
{
    if (userChoice == "1")
    {
        Console.Clear();
        System.Console.WriteLine("Enter 1 to Add Trainer\nEnter 2 to Edit Trainer\nEnter 3 to Delete Trainer\nEnter 4 to Exit");
        string trainerChoice = Console.ReadLine();
        while (trainerChoice != "1" && trainerChoice != "2" && trainerChoice != "3" && trainerChoice != "4")
        {
            SayInvalid();
            System.Console.WriteLine("Enter 1 to Add Trainer\nEnter 2 to Edit Trainer\nEnter 3 to Delete Trainer\nEnter 4 to Exit");
            trainerChoice = Console.ReadLine();
        }
        if (trainerChoice != "4")
        {
            if (trainerChoice == "1")
            {
                Console.Clear();
                utility.GetAllTrainers();
                utility.AddTrainer();
                System.Console.WriteLine("You have sucessfully added a new trainer.");
                PauseAction();
            }
            if (trainerChoice == "2")
            {
                Console.Clear();
                utility.GetAllTrainers();
                report.PrintAllTrainers();
                Console.WriteLine();
                utility.UpdateTrainer();
                System.Console.WriteLine("Your edit has been saved.");
                PauseAction();
            }
            if (trainerChoice == "3")
            {
                Console.Clear();
                utility.GetAllTrainers();
                report.PrintAllTrainers();
                Console.WriteLine();
                utility.DeleteTrainer();
                System.Console.WriteLine("Trainer has been deleted.");
                PauseAction();
            }
        }
    }
    else if (userChoice == "2")
    {
        Console.Clear();
        System.Console.WriteLine("Enter 1 to Add Listing\nEnter 2 to Edit Listing\nEnter 3 to Delete Listing\nEnter 4 to Exit");
        string listingChoice = Console.ReadLine();
        while (listingChoice != "1" && listingChoice != "2" && listingChoice != "3" && listingChoice != "4")
        {
            SayInvalid();
            System.Console.WriteLine("Enter 1 to Add Listing\nEnter 2 to Edit Listing\nEnter 3 to Delete Listing\nEnter 4 to Exit");
            listingChoice = Console.ReadLine();
        }
        if (listingChoice != "4")
        {
            if (listingChoice == "1")
            {
                Console.Clear();
                listUtility.GetAllListing();
                listUtility.AddListing();
                System.Console.WriteLine("Listing has been added.");
                PauseAction();
            }
            if (listingChoice == "2")
            {
                Console.Clear();
                listUtility.GetAllListing();
                listReport.PrintAllListings();
                System.Console.WriteLine();
                listUtility.UpdateListing();
                System.Console.WriteLine("Listing has been updated.");
                PauseAction();
            }
            if (listingChoice == "3")
            {
                Console.Clear();
                listUtility.GetAllListing();
                listReport.PrintAllListings();
                System.Console.WriteLine();
                listUtility.DeleteListing();
                System.Console.WriteLine("Listing has been deleted.");
                PauseAction();
            }
        }
    }
    else if (userChoice == "3")
    {
        Console.Clear();
        System.Console.WriteLine("Enter 1 to Book a Session\nEnter 2 to Exit");
        string bookingChoice = Console.ReadLine();
        while (bookingChoice != "1" && bookingChoice != "2")
        {
            SayInvalid();
            System.Console.WriteLine("Enter 1 to Book a Session\nEnter 2 to Exit");
            bookingChoice = Console.ReadLine();
        }
        if (bookingChoice == "1")
        {
            Console.Clear();
            listUtility.GetAllListing();
            listReport.PrintAllAvailableListings();
            bookingUtility.GetAllBookings();
            System.Console.WriteLine();
            bookingUtility.BookSession();
            System.Console.WriteLine("Enter 1 if you completed your session\nEnter 2 if did not show at your session or if you would like to cancel your session");
            string sessionChoice = Console.ReadLine();
            while (sessionChoice != "1" && sessionChoice != "2")
            {
                SayInvalid();
                System.Console.WriteLine("Enter 1 if you completed your session\nEnter 2 if did not show at your session or if you would like to cancel your session");
                sessionChoice = Console.ReadLine();
            }
            if (sessionChoice == "1")
            {
                bookingUtility.CompletedBooking();
            }
            if (sessionChoice == "2")
            {
                bookingUtility.CancelBooking();
            }

        }
    }
    if(userChoice == "4"){
        Console.Clear();
        System.Console.WriteLine("Enter 1 to Run Report on Individual Customer Sessions\nEnter 2 to Run Report on Historical Customer Sessions\nEnter 3 to Run Report on Historical Revenue\nEnter 4 to Run Indivual Trainer Rating Report\nEnter 5 to Exit");
        string reportChoice = Console.ReadLine();
        while (reportChoice != "1" && reportChoice != "2" && reportChoice != "3" && reportChoice != "4" && reportChoice != "5")
        {
            SayInvalid();
            System.Console.WriteLine("Enter 1 to Run Report on Individual Customer Sessions\nEnter 2 to Run Report on Historical Customer Sessions\nEnter 3 to Run Report on Historical Revenue\nEnter 4 to Run Indivual Trainer Rating Report\nEnter 5 to Exit");
            reportChoice = Console.ReadLine();
        }
        if(reportChoice == "1"){
            bookingUtility.GetAllBookings();
            bookingReport.SessionsByCustomer();
            PauseAction();
        }
        if(reportChoice == "2"){
            bookingUtility.GetAllBookings();
            bookingReport.HistoricalCustomerSessions();
            PauseAction();
        }
        if(reportChoice == "3") {
            bookingUtility.GetAllBookings();
            listUtility.GetAllListing();
            bookingReport.HistoricalRevenueByMonthByYear();
            PauseAction();
        }
        if(reportChoice == "4"){
            ratingUtility.GetAllRatings();
            ratingReport.RatingsByTrainer();
            PauseAction();
        }

    }
    if(userChoice == "5") {
        ratingUtility.GetAllRatings();
        ratingUtility.AddRating();
        System.Console.WriteLine("Your rating is appreciated! Thank you!");
        PauseAction();
    }
    else if (userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "4" && userChoice != "5" && userChoice != "6")
        {
            SayInvalid();
        }
}

static void PauseAction()
{
    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

static void SayInvalid()
{
    System.Console.WriteLine("Invalid!");
    PauseAction();
}

