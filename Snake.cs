#pragma warning disable 

public class Snake : Animal
{
    public Snake(string name) : base(name)
    {
        OnAnimalHungry += () => Console.WriteLine($"{Name} is hissing for food.");
    }

    public override void PerformAction()
    {
        Console.WriteLine(IsAlive ? $"{Name} is crawling." : $"{Name} cannot perform any actions as it is dead.");
    }
}