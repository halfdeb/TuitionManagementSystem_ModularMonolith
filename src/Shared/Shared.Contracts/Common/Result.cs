namespace Shared.Contracts.Common;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public IReadOnlyList<Error> Errors { get; }
    public Error Error => Errors.Count > 0 ? Errors[0] : Error.None;

    protected Result(bool isSuccess, IReadOnlyList<Error> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success() => new(true, Array.Empty<Error>());
    public static Result Failure(Error error) => new(false, new[] { error });
    public static Result Failure(IReadOnlyList<Error> errors) => new(false, errors);
    public static Result ValidationFailure(IReadOnlyList<Error> errors) => new(false, errors);
    public static Result<T> Success<T>(T value) => Result<T>.Success(value);
    public static Result<T> Failure<T>(Error error) => Result<T>.Failure(error);
}

public sealed class Result<T> : Result
{
    private readonly T? _value;

    private Result(T? value, bool isSuccess, IReadOnlyList<Error> errors)
        : base(isSuccess, errors) => _value = value;

    /// <summary>Throws if accessed on a failed result — always check IsSuccess first.</summary>
    public T Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Cannot access Value of a failed Result.");

    public static Result<T> Success(T value) => new(value, true, Array.Empty<Error>());
    public static new Result<T> Failure(Error error) => new(default, false, new[] { error });
    public static new Result<T> ValidationFailure(IReadOnlyList<Error> errors) => new(default, false, errors);

    public static implicit operator Result<T>(T value) => Success(value);
}