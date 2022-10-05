namespace LinqBeginProject
{
    class City
    {
        public string? Title { set; get; }
    }
    class Company
    {
        public string? Title { set; get; }
        public City? City { set; get; }
    }
    class User : IComparable<User>
    {
        public string? Name { set; get; }
        public int Age { set; get; }
        public Company? Company { set; get; }

        public int CompareTo(User? other)
        {
            //return Name.CompareTo(other.Name);
            return Age - other!.Age;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            List<City> cities = new List<City>()
            {
                new City(){ Title = "Moscow" },
                new City(){ Title = "Novosibirsk" },
                new City(){ Title = "Ulan-Ude" },
            };

            List<Company> companies = new List<Company>()
            {
                new Company(){ Title = "Yandex", City = cities[0] },
                new Company(){ Title = "SibirCo", City = cities[1] },
                new Company(){ Title = "Baykal", City = cities[2] }
            };

            List<User> users = new List<User>()
            {
                new User(){ Name = "Bob", Age = 25, Company = companies[0] },
                new User(){ Name = "Tim", Age = 35, Company = companies[1] },
                new User(){ Name = "Sam", Age = 17, Company = companies[2] },
                new User(){ Name = "Joe", Age = 47, Company = companies[1] },
                new User(){ Name = "Tom", Age = 29, Company = companies[0] },
            };


            // обычная выборка foreach
            List<User> usersYangs = new List<User>();
            foreach (User user in users)
                if (user.Age < 30)
                    usersYangs.Add(user);

            usersYangs.Sort();

            foreach (User user in usersYangs)
                Console.WriteLine($"{user.Name} - {user.Age}");
            Console.WriteLine("\n---------------------\n");


            // операторы запроса LINQ
            var userLinqOne = from user in users
                              where user.Age < 30
                              orderby user.Age
                              select user;

            foreach (User user in userLinqOne)
                Console.WriteLine($"{user.Name} - {user.Age}");
            Console.WriteLine("\n---------------------\n");


            // методы расширения LINQ
            var userLinqTwo = users.Where(user => user.Age < 30).OrderBy(user => user.Age);

            foreach (User user in userLinqTwo)
                Console.WriteLine($"{user.Name} - {user.Age}");
            Console.WriteLine("\n---------------------\n");

        }
    }
}