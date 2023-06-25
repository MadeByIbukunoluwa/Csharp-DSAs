using System.Globalization;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialization
            int[] numbers;
            // declaration
            numbers = new int[5];

            //initialization and declaration;
            int[] numbers1 = new int[5];

            // all elements have default values, zeros in the case of integer
            //values we can assign values to the elements using array indexing 
            numbers[0] = 7;
            numbers[1] = 4;
            numbers[2] = 3;

            int[] numbers2 = new int[] { 9, -11, 4, 56, 78 };

            // get values using the [] operator
            int middle = numbers[2];

            string[] months = new string[] {"January","February","March","April","May",
             "June","July","August","September","October","November","December"};

            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year,month,1);
                string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                months[month - 1] = name;


            }
            foreach(string month in months)
            {
                Console.WriteLine($"--> {month}");
            }
        }
    }
}