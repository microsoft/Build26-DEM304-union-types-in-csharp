List<Pet> pets = [
    new Dog("Fido"),
    new Cat("tabby"),
    new Bird { Species = "crow" },
];

foreach (var pet in pets)
{
    WriteLine(pet.Description);
}

union Pet(Dog, Cat, Bird)
{
    public string Description => this switch
    {
        Dog dog => dog.Name,
        Cat(var adjective) => $"A {adjective} cat",
        Bird { Species: var species } => $"A {species}",
    };
}

public record class Dog(string Name);
public record struct Cat(string Adjective);
public class Bird { public required string Species; };
public record class Shark(int Teeth);
