namespace Portfolio.Web.SharedKernel.Primitives;

public class Result
{
    protected internal Result(bool isSuccess, List<Error> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public List<Error> Errors { get; } = [];

    public static Result Success() => new(true, []);

    public static Result Failure(List<Error> errors) => new(false, errors);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, []);

    public static Result<TValue> Failure<TValue>(List<Error> errors) =>
        new(default!, false, errors);

    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>([Error.NullValue]);
}

public class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue value, bool isSuccess, List<Error> errors)
        : base(isSuccess, errors)
    {
        _value = value;
    }

    public TValue? Value => IsSuccess ? _value : default;

    public static implicit operator Result<TValue>(TValue value) => Create(value);
}
