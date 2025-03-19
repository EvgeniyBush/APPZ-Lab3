#pragma warning disable 

public class Snake : Animal
{
    public Snake(string name) : base(name) { }

    public override void PerformAction()
    {
        Console.WriteLine(IsAlive ? $"{Name} is crawling." : $"{Name} cannot crawl.");
    }
}