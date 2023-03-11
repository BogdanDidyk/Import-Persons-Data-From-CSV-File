using System.Text;

namespace ImportPersonsDataFromCSVFile
{
    public class Person
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public Guid ID { get; set; }
        public DateTime DayOfBirth { get; set; }
        public int TotalDays
        {
            get
            {
                return DateTime.Now.Subtract(DayOfBirth).Days;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Day of birth: {DayOfBirth}");
            Console.WriteLine($"Total days: {TotalDays}");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            const string pathToFile = "Data.csv";

            if (!File.Exists(pathToFile))
            {
                Console.WriteLine($"File \"{Path.GetFullPath(pathToFile)}\" does not exist!");
                Thread.Sleep(10000);
                return;
            }

            string[] lines = File.ReadAllLines(pathToFile, Encoding.UTF8);
            List<Person> persons = new List<Person>();

            foreach (string line in lines)
            {
                string[] info = line.Split(',', ';');
                persons.Add(new Person()
                {
                    Name = info[0],
                    Surname = info[1],
                    DayOfBirth = DateTime.Parse(info[2]),
                    ID = Guid.Parse(info[3])
                });
            }

            foreach (Person item in persons)
            {
                item.PrintInfo();
                Console.WriteLine();
            }

            Console.ReadKey(true);
        }
    }
}