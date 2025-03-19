#pragma warning disable 

public class Parrot : Animal
{
    public Parrot(string name) : base(name) { }

    public override void PerformAction()
    {
        Console.WriteLine(IsAlive ? $"{Name} is flying." : $"{Name} cannot fly.");
    }
}
