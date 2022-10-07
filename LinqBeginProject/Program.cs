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
            //List<User> usersYangs = new List<User>();
            //foreach (User user in users)
            //    if (user.Age < 30)
            //        usersYangs.Add(user);

            //usersYangs.Sort();

            //foreach (User user in usersYangs)
            //    Console.WriteLine($"{user.Name} - {user.Age}");
            //Console.WriteLine("\n---------------------\n");


            // операторы запроса LINQ
            //var userLinqOne = from user in users
            //                  where user.Age < 30
            //                  orderby user.Age
            //                  select user;

            //var userNamesOne = from user in users
            //                where user.Age < 30
            //                orderby user.Name
            //                select user.Name;

            //Console.WriteLine(userLinqOne.GetType());
            //Console.WriteLine(userNamesOne.GetType());

            //foreach (User user in userLinqOne)
            //    Console.WriteLine($"{user.Name} - {user.Age}");
            //Console.WriteLine("\n---------------------\n");

            //foreach (var item in userNamesOne)
            //    Console.WriteLine($"{item}");
            //Console.WriteLine("\n---------------------\n");


            // методы расширения LINQ
            //var userLinqTwo = users.Where(user => user.Age < 30)
            //                       .OrderBy(user => user.Age);

            //var userNamesTwo = users.Where(user => user.Age < 30)
            //                       .OrderBy(user => user.Name)
            //                       .Select(user => user.Name);

            //foreach (User user in userLinqTwo)
            //    Console.WriteLine($"{user.Name} - {user.Age}");
            //Console.WriteLine("\n---------------------\n");

            //foreach (var item in userNamesTwo)
            //    Console.WriteLine($"{item}");
            //Console.WriteLine("\n---------------------\n");



            // select отображения.
            // отображение в анонимный класс
            //var usersSibirCo = from user in users
            //                   where user?.Company?.Title == "SibirCo"
            //                   select new 
            //                   { 
            //                       FirstName = "mr." + user.Name, 
            //                       Age = user.Age
            //                   };

            //var usersSibirCo = from user in users
            //                   let name = "mr. " + user.Name
            //                   let year = DateTime.Now.Year - user.Age
            //                   select new
            //                   {
            //                       FirstName = name,
            //                       Year = year
            //                   };


            //foreach (var item in usersSibirCo)
            //{
            //    //Console.WriteLine($"{item.FirstName} {item.Age}");
            //    Console.WriteLine($"{item.FirstName} {item.Year}");
            //}

            //Console.WriteLine("\n---------------------\n");

            var userComp = from user in users
                           from company in companies
                           where user?.Company?.Title == company.Title
                           select new
                           {
                               Name = user.Name,
                               CompanyName = company.Title
                           };

            foreach (var item in userComp)
            {
                Console.WriteLine($"{item.Name} {item.CompanyName}");
            }

            Console.WriteLine("\n---------------------\n");
        }
    }
}