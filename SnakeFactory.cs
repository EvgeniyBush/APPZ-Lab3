#pragma warning disable 

using System.Xml.Linq;

public class SnakeFactory : AnimalFactory
{
    public override Animal CreateAnimal(string name) => new Snake(name);
}