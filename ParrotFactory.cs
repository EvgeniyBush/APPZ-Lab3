#pragma warning disable 

public class ParrotFactory : AnimalFactory
{
    public override Animal CreateAnimal(string name) => new Parrot(name);
}