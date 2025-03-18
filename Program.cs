#pragma warning disable 

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the owner's name:");
        string ownerName = Console.ReadLine();
        var owner = new Owner(ownerName);

        bool exit = false;
        while (!exit)
        {
            owner.ShowMenu();
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1: owner.Animal?.Feed(); break;
                case 2: owner.Animal?.Clean(); break;
                case 3: owner.Animal?.PerformAction(); break;
                case 4: owner.Animal?.ShowStatus(); break;
                case 5: owner.ReleaseAnimal(); break;
                case 6: owner.GetNewAnimal(); break;
                case 7: exit = true; Console.WriteLine("Exiting the program."); break;
                default: Console.WriteLine("Invalid choice, please try again."); break;
            }
        }
    }
}