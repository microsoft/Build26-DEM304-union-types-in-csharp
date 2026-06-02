Queue<Result<int>> results = new([
    new Success<int>(42),
    new Error("Nothing here!"),
    new Success<int>(19)
]);

while (results.TryDequeue(out var result))
{
    int data = result switch
    {
        Success<int>(var d) => d,
        Error(string m) => throw new InvalidOperationException(m)
    };

    WriteLine(data);
}

[Union] struct Result<T> : IUnion
{
    public Result(Success<T> value) => Value = value;
    public Result(Error value) => Value = value;

    public object? Value { get; }
}

//union Result<T>(Success<T>, Error);

record struct Success<T>(T Data);
record struct Error(string Message);
