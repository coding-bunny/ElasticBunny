namespace CodingBunny.ElasticBunny.Exceptions;

/// <summary>
/// This is a custom exception that is thrown when the provided index name is considered invalid.
/// By using custom Exception types, we can provide more context to the caller of the method that threw the exception.
/// </summary>
/// <remarks>See https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-create-index.html#indices-create-api-path-params</remarks>
public class InvalidIndexNameException : ArgumentException
{
    public static readonly char[] InvalidCharacters = { '\\', '/', '*', '?', '"', '<', '>', '|', ',', '#', ':' };
    public static readonly char[] InvalidStartCharacters = { '-', '_', '+' };
    public static readonly string[] ForbiddenNames = { ".", ".." };
    public const int MaxLength = 255;
    
    private InvalidIndexNameException(string message) : base(message)
    {}

    public static void ThrowIfUpperCase(string name)
    {
        if (name.Any(char.IsUpper))
        {
            throw new InvalidIndexNameException($"Index '{name}' cannot contain uppercase letters.");
        }
    }

    public static void ThrowIfNullOrWhitespace(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidIndexNameException("Index name cannot be null or empty.");
        }
    }
    
    public static void ThrowIfContainsInvalidCharacters(string name)
    {
        if (InvalidCharacters.Any(name.Contains))
        {
            throw new InvalidIndexNameException(
                $"Index '{name}' cannot contain any of the following characters: {InvalidCharacters}");
        }
    }
    
    public static void ThrowIfStartsWithInvalidCharacters(string name)
    {
        if (InvalidStartCharacters.Any(name.StartsWith))
        {
            throw new InvalidIndexNameException(
                $"Index '{name}' cannot start with any of the following characters: {InvalidStartCharacters}");
        }
    }

    public static void ThrowIfNameIsForbidden(string name)
    {
        if (ForbiddenNames.Any(name.Equals))
        {
            throw new InvalidIndexNameException($"Index '{name}' cannot be any of the following: {ForbiddenNames}");
        }
    }
    
    public static void ThrowIfNameIsTooLong(string name)
    {
        if (System.Text.Encoding.UTF8.GetBytes(name).Length > MaxLength)
        {
            throw new InvalidIndexNameException($"Index '{name}' cannot be longer than {MaxLength} bytes.");
        }
    }
}