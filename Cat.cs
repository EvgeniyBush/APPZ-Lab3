#pragma warning disable 

public class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override void PerformAction()
    {
        Console.WriteLine(IsAlive ? $"{Name} is playing." : $"{Name} cannot move.");
    }
}