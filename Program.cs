#pragma warning disable 

using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter owner's name:");
        string ownerName = Console.ReadLine();
        Owner owner = new Owner(ownerName);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n1. Get a new animal\n2. Feed animal\n3. Clean animal\n4. Perform action\n5. Show status\n6. Release animal\n7. Exit");
            if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Choose: 1 - Cat, 2 - Parrot, 3 - Snake");
                    AnimalFactory factory = Console.ReadLine() == "1" ? new CatFactory() :
                                           Console.ReadLine() == "2" ? new ParrotFactory() : new SnakeFactory();
                    owner.GetNewAnimal(factory);
                    break;
                case 2: owner.Animal?.Feed(); break;
                case 3: owner.Animal?.Clean(); break;
                case 4: owner.Animal?.PerformAction(); break;
                case 5: owner.Animal?.ShowStatus(); break;
                case 6: owner.ReleaseAnimal(); break;
                case 7: exit = true; break;
            }
        }
    }
}
