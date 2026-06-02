List<object> pets = [
    new Dog("Fido"),
    new Cat("tabby"),
    new Bird { Species = "crow" },
    new Shark(Teeth: 300),
];

foreach (var pet in pets)
{
    var description = pet switch
    {
        Dog dog => dog.Name,
        Cat(var adjective) => $"A {adjective} cat",
        Bird { Species: var species } => $"A {species}",
        Shark(var teeth) => $"{new('A', teeth)} shark!"
    };

    WriteLine(description);
}

public record class Dog(string Name);
public record struct Cat(string Adjective);
public class Bird { public required string Species; };
public record class Shark(int Teeth);
