#pragma warning disable 

using System;

public class Owner
{
    public string Name { get; }
    public Animal Animal { get; private set; }

    public Owner(string name)
    {
        Name = name;
        Animal = null;
    }

    public void GetNewAnimal(AnimalFactory factory)
    {
        if (Animal != null)
        {
            Console.WriteLine("You already have an animal! Release it first.");
            return;
        }

        Console.WriteLine("Enter the name of your new pet:");
        string petName = Console.ReadLine();
        Animal = factory.CreateAnimal(petName);

        Console.WriteLine($"You now have a new pet: {Animal.Name}");
    }

    public void ReleaseAnimal()
    {
        if (Animal != null)
        {
            Console.WriteLine($"{Animal.Name} has been released.");
            Animal = null;
        }
        else
        {
            Console.WriteLine("You don't have an animal to release.");
        }
    }
}
