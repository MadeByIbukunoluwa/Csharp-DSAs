using System.Globalization;
using System.Collections;

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
                DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                months[month - 1] = name;


            }
            foreach (string month in months)
            {
                Console.WriteLine($"--> {month}");
            }

            // multidimensional arrays
            //2 dimensional array
            // we initialized an array with five rows and two columns
            int[,] numbersArr1 = new int[5, 2];

            //3 dimensional array
            int[,,] numbersArr2 = new int[5, 4, 3];

            //2 dimensional array declared and initialized
            int[,] numbersArr3 = new int[,] {
                { 9, 5, -9},
                { -11, 4, 0 },
                { 6, 115, 3 },
                { -12, -9, 71 },
                { 1, -6, -1 }
            };

            //int number2 = numbersArr3[1][3];

            //multiplication table
            // build the multiplication table
            int[,] results = new int[10, 10];

            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    results[i, j] = (i + 1) * (j + 1);
                }
            }
            // display the results
            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    Console.WriteLine("{0,4}", results[i, j]);
                }
                Console.WriteLine();
            }

            // Game map


            //Console.ReadLine();
            TerrainEnum[,] map =
            {
                {
                    TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND,
                    TerrainEnum.SAND, TerrainEnum.GRASS, TerrainEnum.GRASS,
                    TerrainEnum.GRASS, TerrainEnum.GRASS, TerrainEnum.GRASS,
                    TerrainEnum.GRASS
                },
                {
                    TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,
                     TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,
                     TerrainEnum.WATER, TerrainEnum.WALL, TerrainEnum.WATER,
                     TerrainEnum.WATER
                }
            };

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    Console.ForegroundColor = map[row, column].GetColor();
                    Console.Write(map[row,column].GetChar() + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            //Jagged Arrays
            //int[][] numbersJagged = new int[4][];

            //numbers[0] = new int[] { 9, 5, -9 };
            //numbers[1] = new int[] { 0, -3, 12, 51, -3 };
            //numbers[3] = new int[] { 54 };

            int[][] numbersJagged1 =
            {
                new int[] {9,5,-9},
                new int[] {0,-3, 12, 51,-3 },
                null,
                new int[] {54}
            };
            int number = numbersJagged1[1][2];
            numbersJagged1[1][3] = 50;

            Random random = new Random();

            // get the number types of transport from getting the enum length
            int TransportTypesCount = Enum.GetNames(typeof(TransportEnum)).Length;

            // initialize a jagged array with 12 elements, each is a one dimensional array

            TransportEnum[][] transport = new TransportEnum[12][];

            for (int month = 1; month <= 12; month++)
            {
                //get the number of days in a month 
                int DaysCount = DateTime.DaysInMonth(DateTime.Now.Year, month);

               transport[month - 1] = new TransportEnum[DaysCount];

                // populate all the days in the month with random enum types
                for (int day = 1;day <= DaysCount; day++)
                {
                   int randomType = random.Next(0,TransportTypesCount);

                   transport[month - 1][day - 1] = (TransportEnum)randomType;
                }
            }

            string[] monthNames = GetMonthNames();

            int monthNamesPart = monthNames.Max(n => n.Length) + 2;

            for (int month = 1; month <= transport.Length; month++)
            {
                Console.Write($"{monthNames[month - 1]}:".PadRight(monthNamesPart));

                for (int day = 1; day <= transport[month - 1].Length; day++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor =
               transport[month - 1][day - 1].GetColor();
                    Console.Write(transport[month - 1][day - 1].GetChar());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }



            static string[] GetMonthNames()
            {
                string[] names = new string[12];

                for (int month = 1; month <= 12; month++)
                {
                    DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                    string name = firstDay.ToString("MMMM",
                        CultureInfo.CreateSpecificCulture("en"));
                    names[month - 1] = name;
                }
                return names;
            }

            //lists
            // add an element or elements to an arraylist 
            ArrayList arrayList = new ArrayList();
            arrayList.Add(5);
            arrayList.AddRange(new int[] { 6, -7, 8 });
            arrayList.AddRange(new object[] { "Marcin", "Mary" });
            arrayList.Insert(5, 9.8);

            object first = arrayList[0];
            // this casting is necessary, because the array list stores object values
            int third = (int)arrayList[2];

            foreach(object element in arrayList)
            {
                Console.WriteLine(element);
            }
            // count returns the number of elements stored in the arrayList
            int count = arrayList.Count;
            // capacity returns the how many elements can be stored within it 
            int capacity = arrayList.Capacity;

            //check if arraylist contains element with a particular value
            bool containsMary = arrayList.Contains("Mary");

            // find the index of an element
            //first occurrence of an element
            int minusIndex = arrayList.IndexOf(-7);

            //last occurence of an element
            int minusIndexLast = arrayList.LastIndexOf(-7);

            arrayList.Remove(5);

            Console.WriteLine(containsMary.ToString());
            Console.WriteLine(capacity.ToString());
            Console.WriteLine(minusIndex.ToString());
            Console.WriteLine(minusIndexLast.ToString());
            //Generic List
            //average value
            List<double> numbersList = new List<double>();

            do
            {
                Console.Write("Enter a number:");

                string numberString = Console.ReadLine();

                if (!double.TryParse(numberString,NumberStyles.Float,new NumberFormatInfo(),out double numberResult))
                {
                    break;
                }
                numbersList.Add(numberResult);
                Console.WriteLine($"The average value is {numbers.Average()} ");
            }
            while (true);



            //list of people
            // add people to the people list
            List<Person> people = new List<Person>();

            people.Add(new Person()
            {
                name = "Marcello",
                Country = CountryEnum.PL,
                age = 36
            });
            people.Add(new Person()
            {
                name = "Rinola",
                Country = CountryEnum.DE,
                age = 23
            });
            people.Add(new Person()
            {
                name = "letam",
                Country = CountryEnum.UK,
                age = 23
            });

            // Here we used a lINQ expression to 
            List<Person> results1 = people.OrderBy(p => p.name).ToList();

            foreach(Person person in people)
            {
                Console.WriteLine($"{person.name} {person.age} years from {person.Country}");
            }
            // selects the names of all people whose age is lower than or equal to 30
            //years and orders them , then returns them as a list 

            List<string> names = people.Where(p => p.age <= 30)
                .OrderBy(p => p.name)
                .Select(p => p.name)
                .ToList();
            // we can also achieve this with the query syntax
            List<string> namesQuery = (from p in people
                                       where p.age <= 30
                                       orderby p.name
                                       select p.name).ToList();

            //Sorted Lists

            SortedList<string, Person> peopleSorted = new SortedList<string, Person>();


            people.Add(new Person()
            {
                name = "Marcello",
                Country = CountryEnum.PL,
                age = 36
            });
            people.Add(new Person()
            {
                name = "Rinola",
                Country = CountryEnum.DE,
                age = 23
            });
            people.Add(new Person()
            {
                name = "letam",
                Country = CountryEnum.UK,
                age = 23
            });

            //When all the data are stored within the collection, you can easily iterate through its elements
            //    (key - value pairs) using the foreach loop.It is worth mentioning that
            //    a type of the variable used in the loop is KeyValuePair<string, Person>.Thus, you need to use the Key
            //    and Value properties to get access to a key and a value
            foreach (KeyValuePair<string,Person> person in peopleSorted)
            {
                Console.WriteLine($"{person.Value.name}{person.Value.age}from {person.Value.Country}");
            }

            //Linked Lists
            //Book Reader
            // create new pages
            Page page1 = new Page() { Content = "Common sense, often regarded as an innate gift, is a remarkable trait that allows individuals to navigate the complexities of " +
                "life with wisdom and prudence. It is an intuitive understanding of what is sensible and logical in a given situation, enabling people to make sound judgments and decisions." +
                " Common sense acts as a compass, guiding us through the intricacies of everyday challenges and helping us avoid unnecessary pitfalls. While education and knowledge are valuable, " +
                "common sense remains a vital component in our lives. It encourages practicality, critical thinking, and an awareness of consequences. Embracing common sense leads to " +
                "well-rounded individuals who can thrive in both personal and professional spheres. In a world that often complicates matters unnecessarily, the power of common sense should never be underestimated." };
            Page page2 = new Page() { Content = "Systems thinking is an invaluable approach that allows us to perceive the world in its entirety, acknowledging " +
                "the interconnectedness and interdependence of various elements within a system. It goes beyond linear thinking and embraces complexity, " +
                "recognizing that actions and events are shaped by multiple factors and relationships. By adopting systems thinking, we gain a holistic " +
                "understanding of the world, enabling us to uncover the hidden dynamics and unintended consequences of our decisions." +
                " This approach empowers us to identify leverage points and find sustainable solutions to complex problems. Systems thinking" +
                " encourages collaboration, as it emphasizes the importance of collective intelligence and the impact of interconnected systems on our lives." +
                " In an increasingly interconnected and interdependent world, systems thinking is an essential tool for navigating the challenges and complexities " +
                "we face, enabling us to create positive change and build a more sustainable future.\n\n\n\n\n\n\n" };
            Page page3 = new Page() { Content = "Logic, often hailed as the cornerstone of rationality, is a powerful tool that enables us to reason, analyze, and make " +
                "sound judgments. Rooted in a systematic and coherent framework, logic provides us with a foundation for critical thinking and problem-solving. " +
                "It helps us identify fallacies, detect inconsistencies, and construct valid arguments. By employing logical principles, " +
                "we can navigate through complex information, unraveling the truth from the sea of biases and misconceptions. Logic fosters " +
                "clarity of thought and promotes intellectual rigor, allowing us to approach challenges with a rational mindset. It empowers us to evaluate ideas, " +
                "weigh evidence, and form well-founded conclusions. In a world inundated with information, the power of logic serves as a compass, guiding us towards " +
                "reliable knowledge and rational decision-making. By embracing logic, we unlock the ability to think critically, ensuring that reason triumphs over mere conjecture.\n\n\n\n\n\n" };
            Page page4 = new Page() { Content = "The intricacies of human mating encompass a complex interplay of biological, psychological, and sociocultural factors that " +
                "shape our reproductive behavior. At the biological level, hormones such as testosterone and estrogen influence sexual desire and attraction. " +
                "Evolutionary psychology suggests that mate selection is influenced by innate preferences shaped by our ancestors' reproductive success, " +
                "such as physical attractiveness, fertility cues, and indicators of genetic fitness. Psychological factors, such as personal preferences, " +
                "personality traits, and attachment styles, also play a significant role in mate choice. Sociocultural influences, including societal norms, " +
                "cultural values, and gender roles, further shape mating patterns and expectations. Additionally, factors like social status, resources, and " +
                "mutual compatibility contribute to the complexity of human mating dynamics. Understanding these intricacies can provide insights into the multifaceted nature" +
                " of human relationships and the diverse strategies employed in the pursuit of romantic partnerships.\n\n\n\n\n\n\n" };
            Page page5 = new Page() { Content = "The concept of God has been a subject of profound contemplation and diverse interpretations across cultures and throughout history." +
                " While the understanding of God varies greatly among individuals and belief systems, the notion generally refers to a supreme being or a transcendent entity " +
                "that is revered as the creator and sustainer of the universe. Religions provide frameworks through which people conceptualize and relate to the " +
                "divine, offering teachings, rituals, and moral guidance. Different religious traditions depict God with unique attributes and characteristics, " +
                "including omnipotence, omniscience, benevolence, and immanence. For some, God represents a personal and loving deity, while for others, " +
                "God is seen as an impersonal force or a cosmic consciousness. Beyond religious contexts, philosophical inquiries and personal experiences " +
                "shape individuals' perspectives on the nature of God. Some perceive God as a source of meaning, purpose, and moral guidance, while others" +
                " grapple with questions of existence and the problem of evil. Ultimately, the concept of God is deeply intertwined with humanity's search " +
                "for answers to existential questions and the desire for a connection to something greater than ourselves. It remains a subject of ongoing exploration, debate, and personal belief.\n\n\n\n\n\n\n" };
            Page page6 = new Page() { Content = "The inconsistency avoidance tendency is a cognitive bias that highlights our inclination to seek consistency and coherence in our beliefs, " +
                "attitudes, and actions. It stems from our innate desire to avoid cognitive dissonance, the uncomfortable state of holding conflicting or contradictory thoughts simultaneously. " +
                "Humans tend to strive for internal harmony by aligning their beliefs and behaviors to reduce this dissonance.\n\nThis tendency manifests in various ways. " +
                "We tend to interpret new information in a way that aligns with our existing beliefs, selectively seeking out evidence that supports our preconceived notions. " +
                "We may also engage in rationalization, finding justifications or excuses to maintain consistency and avoid the discomfort of cognitive dissonance." +
                "\n\nWhile the inconsistency avoidance tendency helps maintain psychological stability, it can hinder rational thinking and objective decision-making. " +
                "It may prevent us from critically evaluating new information and considering alternative viewpoints, leading to confirmation bias and closed-mindedness.\n\n" +
                "Recognizing and managing this tendency is crucial for fostering intellectual growth and maintaining an open, adaptable mindset. " +
                "Embracing cognitive flexibility allows us to challenge our beliefs, entertain diverse perspectives, and embrace the inherent complexities and nuances of reality." +
                " By actively seeking out cognitive dissonance and using it as an opportunity for growth, we can overcome the limitations imposed by the inconsistency avoidance tendency" +
                " and approach situations with a more rational and balanced mindset.\n\nIn conclusion, the inconsistency avoidance tendency highlights our inclination to seek consistency " +
                "in our beliefs and actions. While it serves to maintain cognitive harmony, it can hinder rational thinking. By actively confronting cognitive dissonance and " +
                "embracing cognitive flexibility, we can cultivate a more open-minded and rational approach to decision-making, enabling personal growth and intellectual development.\n\n\n\n\n" };

            //create the linkedList
            LinkedList<Page> pages = new LinkedList<Page>();
            pages.AddLast(page2);
            LinkedListNode<Page> nodePage4 = pages.AddLast(page4);
            pages.AddLast(page6);
            pages.AddFirst(page1);
            pages.AddBefore(nodePage4,page3);
            pages.AddAfter(nodePage4,page5);

            LinkedListNode<Page> current = pages.First;

            int numberOfPage = 1;

            static string GetSpaces(int number)
            {

                string result = string.Empty;
                for (int i = 0; i < number; i++)
                {
                    result += " ";
                }
                return result;
            }

            while (current != null)
            {
                Console.Clear();
                string numberString = $"- {numberOfPage} -";
                int leadingSpaces = (90 - numberString.Length) / 2;
                Console.WriteLine(numberString.PadLeft(leadingSpaces + numberString.Length));
                Console.WriteLine();
                string content = current.Value.Content;

                for (int i = 0; i < content.Length; i += 90)
                {
                    string line = content.Substring(i);
                    //line = content.Length > 90 ? content.Substring(0,90) : line;
                    //Console.WriteLine(content.Length);
                    Console.Write(line);
                    //Console.WriteLine(content);
                }
                    Console.WriteLine();
                    Console.WriteLine("Quote from 'Windows Application Development Cookbook' " +
                        "by Marcin Jamro,\npublished by Packt Publishing in 2016.");
                    Console.WriteLine();
                    Console.WriteLine(current.Previous != null ? "< PREVIOUS [P]" : GetSpaces(14));
                    Console.WriteLine(current.Next != null ? "> NEXT [N] ".PadLeft(76): String.Empty);
                    Console.WriteLine();

                ConsoleKey key = Console.ReadKey(true).Key;

                    switch(key)
                    {
                        case ConsoleKey.N:
                            if (current.Next != null)
                        {
                            current = current.Next;
                            numberOfPage++;
                        }
                        break;
                        case ConsoleKey.P:
                            if (current.Previous != null)
                        {
                            current = current.Previous;
                            numberOfPage--;
                        }
                        break;
                    default:
                       return; 
                    }
            }


        }
    }
}
