#pragma warning disable 

public class SnakeFactory : AnimalFactory
{
    public override Animal CreateAnimal(string name) => new Snake(name);
}