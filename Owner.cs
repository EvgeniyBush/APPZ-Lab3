#pragma warning disable 

using System.Xml.Linq;

public class Owner
{
    public string Name { get; }
    public Animal Animal { get; private set; }

    public Owner(string name)
    {
        Name = name;
        Animal = null;
    }

    public void CareForAnimal()
    {
        if (Animal != null)
        {
            Animal.Feed();
            Animal.Clean();
            Animal.PerformAction();
            Animal.ShowStatus();
        }
    }

    public void ReleaseAnimal()
    {
        if (Animal != null)
        {
            Console.WriteLine($"{Animal.Name} has been released to the wild.");
            Animal = null;
        }
        else
        {
            Console.WriteLine("You don't have any animal to release.");
        }
    }

    public void GetNewAnimal()
    {
        if (Animal != null)
        {
            Console.WriteLine("You already have an animal! Please release it first.");
            return;
        }

        Console.WriteLine("Choose a new animal (1 - Cat, 2 - Parrot, 3 - Snake):");
        if (!int.TryParse(Console.ReadLine(), out int animalChoice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        switch (animalChoice)
        {
            case 1:
                Animal = new Cat("Tom");
                break;
            case 2:
                Animal = new Parrot("Polly");
                break;
            case 3:
                Animal = new Snake("Slither");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Console.WriteLine($"You have a new animal: {Animal.Name}");
    }

    public void ShowMenu()
    {
        Console.WriteLine("\n=== Menu ===");
        Console.WriteLine("1. Feed the animal");
        Console.WriteLine("2. Clean the animal");
        Console.WriteLine("3. Perform animal action");
        Console.WriteLine("4. Show animal status");
        Console.WriteLine("5. Release the animal to the wild");
        Console.WriteLine("6. Get a new animal");
        Console.WriteLine("7. Exit");
    }
}