using System;

namespace _5._6._Итоговый_проект
{
    class Program
    {
        static (string Name, string Surename, int Age, bool HasPet,
           string[] theNameOfPets, string[] favColours) FillUsersTuple()
        {
            (string Name, string Surename, int Age, bool HasPet, string[] theNameOfPets, string[] favColours) UsersProfile;

            Console.Write("Enter your name: ");
            UsersProfile.Name = Console.ReadLine();

            Console.Write("Enter your sure name: ");
            UsersProfile.Surename = Console.ReadLine();


            string age;
            int correctage;
            do
            {
                Console.Write("Enter your age (Write intager > 0): ");
                age = Console.ReadLine();
            }
            while (ChekingEnter(age, out correctage) == false);

            UsersProfile.Age = correctage;

            Console.Write("Have you got a pet?(write \"yes\" or \"no\"): ");
            string haspet = Console.ReadLine();

            if (haspet == "yes")
            {
                UsersProfile.HasPet = true;
                string num;
                int correctnum;
                do
                {
                    Console.Write("How many pet have you got? (write integer > 0): ");
                    num = Console.ReadLine();
                }
                while (ChekingEnter(num, out correctnum) == false);

                Console.WriteLine("write the names of the pets:");

                UsersProfile.theNameOfPets = FillArray(correctnum);

            }
            else
            {
                UsersProfile.HasPet = false;
                UsersProfile.theNameOfPets = new string[] { "Users has not pets" };
            }

            string numcolour;
            int correctcolour;
            do
            {
                Console.Write("write how many colours do you like? (write intager > 0): ");
                numcolour = Console.ReadLine();
            }
            while (ChekingEnter(numcolour, out correctcolour) == false);

            Console.WriteLine("Write your favourite colours");
            UsersProfile.favColours = FillArray(correctcolour);

            return UsersProfile;

        }

        static bool ChekingEnter(string number, out int correctnum)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    correctnum = intnum;
                    return true;
                }
            }
            {
                correctnum = 0;
                return false;
            }
        }

        //метод, принимающий на вход количество питомцев (колличество любимых цветов)
        //и возвращающий массив их кличек (массив названий любимых цветов)
        static string[] FillArray(int num)
        {
            var array = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.Write("Name {0}: ", i + 1);
                array[i] = Console.ReadLine();
            }

            return array;
        }

        static void ShowTuple(
            (string Name, string Surename, int Age, bool HasPet,
            string[] theNameOfPets, string[] favColours) user)
        {
            Console.WriteLine("Users profile:");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Sure name: {user.Surename}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine();
            if (user.HasPet == true)
            {
                Console.WriteLine($"User has {user.theNameOfPets.Length} pet");
                Console.WriteLine("pet names:");
                foreach (var item in user.theNameOfPets)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                foreach (var item in user.theNameOfPets)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Favorite users colours:");
            foreach (var item in user.favColours)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            var user = FillUsersTuple();
            Console.WriteLine();
            ShowTuple(user);
            Console.ReadKey();
        }
    }
}
