using System.Collections;


namespace DictionariesAndSets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hashtable = new Hashtable();

            hashtable.Add("key", "value");


            // as the hashtabple calss is a non generic variant of hash tbale related classes,
            //you need to cast the returned result to the proper type 
            string value = (string)hashtable["key"];

            hashtable["key1"] = "value";

            //get all the entreis fron a HashTable
            foreach( DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }
            Hashtable phoneBook = new Hashtable()
            {
                {"Ibukunoluwa Akintobi" , "08092876471"},
                {"John Legend","999-66-345" }
            };
            // add elements
            phoneBook["key2"] = "value";

            try
            {
                phoneBook.Add("Mary Fox", "222-222-2223");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entry already exists");
            }

            Console.WriteLine("Phone numbers:");

            if (phoneBook.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach(DictionaryEntry entry in phoneBook)
                {
                    Console.WriteLine($" - {entry.Key}: {entry.Value}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Search by name:  ");
            string name = Console.ReadLine();
            if (phoneBook.Contains(name))
            {
                string number = (string)phoneBook[name];
                Console.WriteLine($"Found phone number: {number}");
            }
            else
            {
                Console.WriteLine("The entry does not exist");
            }
            // If you need to present your answers in a sorted Format you need to use a SorteddDictionary

            //Dictionaries
            //Product Location
            Dictionary<string, string> products = new Dictionary<string, string>
            {
                { "5900000000", "A1" },
                { "37289473839", "B1"},
                { "4930430i431", "C9" }
            };
            products["5900000000"] = "D7";

            try
            {
                products.Add("5900004000","A3");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entry already exists");
            }
            Console.WriteLine("All products");
            if (products.Count == 0)
            {
                Console.WriteLine("Empty");
            } else
            {
                foreach (KeyValuePair<string,string> product in products)
                {
                    Console.WriteLine($" - {product.Key} : {product.Value}");
                }
            }
            Console.WriteLine();
            Console.Write("Search by barcode");
            string barcode = Console.ReadLine();
            if (products.TryGetValue(barcode, out string location))
            {
                Console.WriteLine($"The product is in the area {location}");
            }
            else
            {
                Console.WriteLine("The product does not exist");
            }
            //User details
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
            employees.Add(150, new Employee()
            {
                FirstName = "Marcello",
                LastName = "Modric",
                PhoneNumber = "000-000-333-1234"
            });
            employees.Add(100, new Employee()
            {
                FirstName = "Amala",
                LastName = "Rishna",
                PhoneNumber = "000-000-333-1234"
            });
            employees.Add(120, new Employee()
            {
                FirstName = "Linda",
                LastName = "Ekpunobi",
                PhoneNumber = "000-000-333-1234"
            });

            bool isCorrect = true;
            do
            {
                Console.Write("Enter the employee identifier: ");
                string idString = Console.ReadLine();
                isCorrect = int.TryParse(idString, out int id);
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (employees.TryGetValue(id, out Employee employee))
                    {
                        Console.WriteLine("First name : {1} {0} Last name: {2} {0} Phone number : {3}",
                            Environment.NewLine,
                            employee.FirstName,
                            employee.LastName,
                            employee.PhoneNumber
                         );
                    } else
                    {
                        Console.WriteLine("The employee with the given identifer does not exist");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                

            } while (isCorrect);

            //Sorted Dictionaries

        } 
    }
}