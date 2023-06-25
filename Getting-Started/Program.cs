// See https://aka.ms/new-console-template for more information
using System.Globalization;


namespace GettingStarted { 
    // Place your classes, interfaces, enums, etc. here

    class Program
    {
        static void Main(string[] args) 
        {
            // Entry point of your application
            // You can write your code logic here or call other methods or classes
            // to start the execution of your program

            Person person = new Person("Mary", 20);

            person.Relocate("London");

            double distance = person.GetDistance("Warsaw");

            Console.WriteLine(distance);

            // declaration
            int number;

            // assignment
            number = 500;


            // assignment and declaration
            int number1 = 500;


            // constant - immutable values

            const int DAYS_IN_WEEK = 7;


            // enumerations 
            //enum Language { PL, EN, DE };

            //Language language = language.PL;

            //switch (language)
            //{
            //    case Language.PL:
            //        Console.WriteLine("Polish");
            //        break;
            //    case Language.DE:
            //        Console.WriteLine("German");
            //        break;
            //    default:
            //        Console.WriteLine("English");
            //        break;
            //}

            // strings

            string firstName = "Marcin", lastName = "Jamro";
            int year = 1988;

            string note = firstName + " " + lastName.ToUpper() + " was born in " + year;

            string initials = firstName[0] + "." + lastName[0] + ".";


            // we can also use the format static method for constructing the string

            string note1 = string.Format("{0} {1} was born in {2}", firstName, lastName.ToUpper(), year);


            // interpolated string
            string note2 = $"{firstName} {lastName.ToUpper()} was born in {year}";


            int age = 28;
            object ageBoxing = age;
            int ageUnboxing = (int)ageBoxing;

            //dynamic

            //Delegates
            //delegate double Mean(double a, double b, double c);

            //static double Harmonic(double a, double b, double c)
            //{
            //    return 3 / ((1 / a) + (1 / b) + (1 / c));
            //}

            //Mean arithmetic = (a, b, c) => (a + b + c) / 3;

            //Mean geometric = delegate (double a, double b, double c)
            //{
            //    return Math.Pow(a * b * c, 1 / 3.0);
            //};
            //Mean harmonic = Harmonic;

            //double arithmeticResult = arithmetic.Invoke(5, 6.5, 7);
            //double geometricResult = geometric.Invoke(5, 6.5, 7);
            //double harmonicResult = harmonic.Invoke(5, 6.5, 7);

            // her you used the ReadLine() method,it waits until the user presses the key
            // then the entered text is stored as a value of the fullName string variable
            Console.Write("Enter your fullName:  ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter a number:  ");
            string numberString = Console.ReadLine();

            
            if (int.TryParse(numberString, out int number2))
            {
                Console.WriteLine($"{numberString} is a number which is {number2}");
            }

            Console.Write("Enter a date:  ");
            string dateTimeString = Console.ReadLine();

            if (!DateTime.TryParseExact(
                dateTimeString, "M/d/yyyy HH:mm", new CultureInfo("en-US"),
                DateTimeStyles.None, out DateTime dateTime
            ))
            {
                //dateTime = DateTime.Now;
                Console.WriteLine(dateTime);
            }

            Console.Write("Enter a key:  ");
            ConsoleKeyInfo key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.S:
                    Console.WriteLine("Pressed S");
                break;
                case ConsoleKey.F1:
                    Console.WriteLine("Pressed F1");
                break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Pressed Escape");
                break;
            }
            CultureInfo cultureInfo = new CultureInfo("en-US");

            Console.Write("The table number");

            string table = Console.ReadLine();

            Console.Write("The number of people");

            string countString = Console.ReadLine();

            int.TryParse(countString, out int count);

            Console.Write("The reservation date (MM/dd/yyyy) : ");

            string dateTimeString1 = Console.ReadLine();

            if (!DateTime.TryParseExact(
                dateTimeString1,
                "M/d/yyyy HH:mm",
                cultureInfo,
                DateTimeStyles.None,
                out DateTime dateTime1))
            {
                dateTime1 = DateTime.Now;
            }
            Console.WriteLine("Table {0} has been booked for {1} people on {2} at { 3}",
            table,
            count,
            dateTime.ToString("M/d/yyyy", cultureInfo),
            dateTime.ToString("HH:mm", cultureInfo));

            Console.ReadLine();
        }
    }
}


//classes

public class Person
{
    private string _location = string.Empty;
    public string Name { get; set; }
    public int Age { get; set; }

    private Person() => Name = "___";

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public void Relocate(string location)
    {
        if (!String.IsNullOrEmpty(location))
        {
            _location = location;
        }
    }
    public double GetDistance(string location)
    {
        return DistanceHelpers.GetDistance(_location, location);
    }
}


public static class DistanceHelpers
{
    private const double EarthRadiusKm = 6371.0;

    public static double GetDistance(string location1, string location2)
    {
        var coordinates1 = GetCoordinates(location1);
        var coordinates2 = GetCoordinates(location2);

        var lat1 = ToRadians(coordinates1.latitude);
        var lon2 = ToRadians(coordinates2.longitude);
        var lat2 = ToRadians(coordinates2.latitude);
        var lon1 = ToRadians(coordinates1.latitude);


        var dlon = lon2 - lon1;
        var dlat = lat2 - lat1;

        var a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var distance = EarthRadiusKm * c;

        return distance;
    }
    private static (double latitude, double longitude) GetCoordinates(string location)
    {

        var coordinates = new Dictionary<string, (double, double)>
        {
            { "New York", (40.7128, -74.0060)},  // New York City coordinates
            { "London", (51.5074, -0.1278) },
            { "Warsaw",(52.2297,21.0122) }
        };

        if (coordinates.ContainsKey(location))
        {
            return coordinates[location];
        }
        else
        {
            throw new ArgumentException("Location coordinates not found");
        }
    }
    private static double ToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }
}

//interfaces
// when a class implements the interface below, it should contain the following properties and
//methods
//public interface IDevice
//{
//    string Model { get; set; }
//    string Number { get; set; }
//    int Year { get; set; }

//    void Configure(DeviceConfiguration configuration);
//    bool Start();
//    bool Stop();


