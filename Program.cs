using System;

namespace deliverables_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // asked for first and second date
            Console.WriteLine("ask for first date year-month-day");
            string firstDateString = Console.ReadLine();

            Console.WriteLine("ask for second date year-month-day");
            string secondDateString = Console.ReadLine();

           //convert string to date time
            DateTime firstDate = CreateDateTime(firstDateString);
            DateTime secondDate = CreateDateTime(secondDateString);

            //check to see if date time had minimum value (signals failure)
            if (firstDate == DateTime.MinValue || secondDate == DateTime.MinValue)
            {
                return;
            }

            //Takes the smaller date and subracts from larger one
            TimeSpan difference;
            if (firstDate < secondDate) {
                difference = secondDate - firstDate;
            }
            else {
                difference = firstDate - secondDate;
            }

            //takes the amount of days and converts them into hours and minutes
            int hours = difference.Days * 24;
            int minutes = hours * 60;

            Console.WriteLine("Days: " + difference.Days + " Hours: " + hours + " Minutes: " + minutes); 

        }
        //makes sure year month and day are correct inputs
        private static DateTime CreateDateTime(string dateString) {
            String[] substrings = dateString.Split('-');

            //checking to make sure there are 3 strings
            if (substrings.Length != 3)
            {
                Console.WriteLine("Date Non Existent");
                return DateTime.MinValue;
            }

            string yearString = substrings[0];
            string monthString = substrings[1];
            string dayString = substrings[2];

            //making sure year string has 4 characters
            if (yearString.Length != 4)
            {
                Console.WriteLine("Year not of Length 4");
                return DateTime.MinValue;
            }

            //converts the strings to numbers
            int year = 0;
            int month = 0;
            int day = 0;

            try
            {
                year = int.Parse(yearString);
                month = int.Parse(monthString);
                day = int.Parse(dayString);

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input");
                return DateTime.MinValue;
            }

            //gives minimum value if input is not 1-12 (signals error)
            if (month < 1 || month > 12)
            {
                Console.WriteLine("Invalid Month");
                return DateTime.MinValue;
            }

            //gives minimum value if input is not 1-31 (signals error)
            if (day < 1 || day > 31)
            {

                Console.WriteLine("Invalid Day");
                return DateTime.MinValue;
            }

            return new DateTime(year, month, day);
        }
    }
}
