using System;

namespace deliverables_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ask for first date year-month-day");
            string firstDateString = Console.ReadLine();

            Console.WriteLine("ask for second date year-month-day");
            string secondDateString = Console.ReadLine();

            DateTime firstDate = CreateDateTime(firstDateString);
            DateTime secondDate = CreateDateTime(secondDateString);

            if (firstDate == DateTime.MinValue || secondDate == DateTime.MinValue)
            {
                return;
            }

            TimeSpan difference;
            if (firstDate < secondDate) {
                difference = secondDate - firstDate;
            }
            else {
                difference = firstDate - secondDate;
            }

            int hours = difference.Days * 24;
            int minutes = hours * 60;

            Console.WriteLine("Days: " + difference.Days + " Hours: " + hours + " Minutes: " + minutes); 

        }

        private static DateTime CreateDateTime(string dateString) {
            String[] substrings = dateString.Split('-');
            if (substrings.Length != 3)
            {
                Console.WriteLine("Date Non Existent");
                return DateTime.MinValue;
            }

            string yearString = substrings[0];
            string monthString = substrings[1];
            string dayString = substrings[2];

            if (yearString.Length != 4)
            {
                Console.WriteLine("Year not of Length 4");
                return DateTime.MinValue;
            }

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

            if (month < 1 || month > 12)
            {
                Console.WriteLine("Invalid Month");
                return DateTime.MinValue;
            }

            if (day < 1 || day > 31)
            {

                Console.WriteLine("Invalid Day");
                return DateTime.MinValue;
            }

            return new DateTime(year, month, day);
        }
    }
}
