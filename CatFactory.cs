#pragma warning disable 

public class CatFactory : AnimalFactory
{
    public override Animal CreateAnimal(string name) => new Cat(name);
}
