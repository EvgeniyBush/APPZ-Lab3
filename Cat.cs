#pragma warning disable 

public class Cat : Animal
{
    public Cat(string name) : base(name)
    {
        OnAnimalHungry += () => Console.WriteLine($"{Name} is hungry and meowing.");
    }

    public override void PerformAction()
    {
        Console.WriteLine(IsAlive ? $"{Name} is walking around." : $"{Name} cannot perform any actions as it is dead.");
    }
}