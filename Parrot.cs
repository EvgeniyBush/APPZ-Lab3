#pragma warning disable 

public class Parrot : Animal
{
    public Parrot(string name) : base(name)
    {
        OnAnimalHungry += () => Console.WriteLine($"{Name} is squawking for food.");
    }

    public override void PerformAction()
    {
        Console.WriteLine(IsAlive ? $"{Name} is flying." : $"{Name} cannot perform any actions as it is dead.");
    }
}