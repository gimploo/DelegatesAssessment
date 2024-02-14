using DelegatesAssessment.Algorithms;
using DelegatesAssessment.Models;
using DelegatesAssessment.Repositories;
using DelegatesAssessment.Services;

class Program
{
    static void Main()
    {
        Solution01();
        Solution02();
    }

    static void Solution01()
    {
        List<Student> users = new List<Student>
        {
            new Student(100, "Ram", 15, 99),
            new Student(121, "Arjun", 19, 89.8),
            new Student(101, "Rahul", 15, 99.9),
            new Student(102, "Riya", 16, 78.5),
        };

        List<Student> sorted = MySort<Student>.GetSorted(
            users, 
            (Student x, Student y) => {
                if (x.Id > y.Id) return true;
                return false;
            });

        Console.WriteLine("Before sorted");
        users.ForEach((user) => Console.Write(user.ToString()));

        Console.WriteLine("\nAfter sorted");
        sorted.ForEach((user) => Console.Write(user.ToString()));

    }

    static void Solution02() 
    {
        string COMMANDS = 
        $@"
            COMMANDS
            --------
            /add               := Add user 
            /update            := Update user
            /remove            := Remove user

            /help              := Display available commands
            /exit              := Exit program
        ";

        UserRepository userRepository = new UserRepository();

        UserService userService = new UserService(
            new EmailService(userRepository),
            new PushNotificationService(userRepository),
            new SMSService(userRepository));


        Console.WriteLine(COMMANDS);
        while(true)
        {
            User user = default;
            User newUser = default;

            Console.Write("> ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "/add":
                    user = ReadUserInput(userRepository, true);
                    if (user == null) break;
                    userService.OnAdd(user);
                break;

                case "/remove":
                    user = ReadUserInput(userRepository);
                    if (user == null) break;
                    userService.OnRemove(user);
                break;

                case "/update":
                    user = ReadUserInput(userRepository);
                    newUser = ReadUserInput(userRepository);
                    if (user == null) break;
                    if (newUser == null) break;
                    userService.OnUpdate(user, newUser);
                break;
                 
                case "/help":
                    Console.WriteLine(COMMANDS);
                break;
                case "/exit":
                    return;
                default:
                    Console.WriteLine("Invalid command!, use /help");
                break;
            }
        }

    }
    static User ReadUserInput(UserRepository repo, bool toCreateNew = false)
    {
        Console.WriteLine("Enter Id > ");
        int Id;
        if (!int.TryParse(Console.ReadLine(), out Id))
        {
            Console.WriteLine("Invalid input, expected int");
            return null;
        }

        User ? user = repo.GetAll().ToList().Find((e) => e.Id == Id);

        if (toCreateNew && (user != null))
        {
            Console.WriteLine("That id already exist!");
            return null;
        } 

        if (!toCreateNew && (user == null))
        {
            Console.WriteLine("That id doesn`t exist!");
            return null;
        }

        Console.WriteLine("Enter Name > ");
        string Name = Console.ReadLine();

        Console.WriteLine("Enter Email > ");
        string Email= Console.ReadLine();

        Console.WriteLine("Enter Contact > ");
        string Contact= Console.ReadLine();

        return new User(Id, Name, Email, Contact);
    }

}
