using CodingBunny.ElasticBunny.Exceptions;

namespace CodingBunny.ElasticBunny.Types;

/// <summary>
/// This class represents the ElasticSearch Index name as a strong-type in the code base.
/// The class has a few additional helper methods to guarantee that the name is actually correct and adheres to the
/// requirements of ElasticSearch as well.
/// </summary>
public sealed class IndexName : IEquatable<IndexName>, IComparable<IndexName>, IComparable
{
    private readonly string _value;

    /// <summary>
    /// Creates a new instance of the <see cref="IndexName"/> with the given <see cref="string"/> value.
    /// </summary>
    /// <param name="name">The name of the ElasticSearch Index.</param>
    /// <exception cref="InvalidIndexNameException">
    /// Thrown when the provided <paramref name="name"/> is considered invalid.
    /// </exception>
    public IndexName(string name)
    {
        _value = ValidateName(name);
    }

    /// <summary>
    /// Validates the given <see cref="string"/> name against the requirements set forth by ElasticSearch in their
    /// API documentation. If any of the checks fail, an <see cref="InvalidIndexNameException"/> is thrown.
    /// </summary>
    /// <param name="name">The <see cref="string"/> to validate.</param>
    /// <returns>Then validated <see cref="string"/>.</returns>
    /// <exception cref="InvalidIndexNameException">Thrown when the provided <paramref name="name"/> is invalid.</exception>
    /// <remarks>See https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-create-index.html#indices-create-api-path-params</remarks>
    private string ValidateName(string name)
    {
        InvalidIndexNameException.ThrowIfNullOrWhitespace(name);
        InvalidIndexNameException.ThrowIfUpperCase(name);
        InvalidIndexNameException.ThrowIfContainsInvalidCharacters(name);
        InvalidIndexNameException.ThrowIfStartsWithInvalidCharacters(name);
        InvalidIndexNameException.ThrowIfNameIsForbidden(name);
        InvalidIndexNameException.ThrowIfNameIsTooLong(name);

        return name;
    }

    /// <summary>
    /// Checks against another <see cref="IndexName"/> for equality.
    /// </summary>
    /// <param name="other">The other <see cref="IndexName"/> to check against.</param>
    /// <returns><c>true</c> if both instances are considered equal; otherwise <c>false</c>.</returns>
    public bool Equals(IndexName? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _value == other._value;
    }

    /// <summary>
    /// Checks against another <see cref="object"/> for equality.
    /// </summary>
    /// <param name="obj">The other <see cref="object"/> to check against.</param>
    /// <returns><c>true</c> if both objects are considered equal; otherwise <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is IndexName other && Equals(other);
    }

    /// <summary>
    /// Returns the unique hash code of the <see cref="IndexName"/> instance.
    /// </summary>
    /// <returns>An <see cref="int"/> representing the hash code.</returns>
    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    /// <summary>
    /// Performs a logical comparison against another object.
    /// </summary>
    /// <param name="obj">The <see cref="object"/> to compare against.</param>
    /// <returns>An <see cref="int"/> representing the logical result of the comparison.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided <see cref="object"/> is not an <see cref="IndexName"/>.
    /// </exception>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return string.Compare(_value, null, StringComparison.Ordinal);
        }
        
        if ((IndexName)obj is null)
        {
            throw new ArgumentException("Object is not an IndexName");
        }

        return CompareTo((IndexName)obj);
    }

    /// <summary>
    /// Performs a logical comparison against another <see cref="IndexName"/>.
    /// </summary>
    /// <param name="other">The <see cref="IndexName"/> to compare against.</param>
    /// <returns>An <see cref="int"/> representing the logical result of the comparison.</returns>
    public int CompareTo(IndexName? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        
        return ReferenceEquals(null, other) ? 1 : string.Compare(_value, other._value, StringComparison.Ordinal);
    }

    /// <summary>
    /// Returns a <see cref="string"/> representation of the <see cref="IndexName"/>
    /// </summary>
    /// <returns>A <see cref="string"/> representing the <see cref="IndexName"/>.</returns>
    public override string ToString()
    {
        return _value;
    }

    /// <summary>
    /// Implements the implicit <c>(string)</c> cast operator for the <see cref="IndexName"/>.
    /// </summary>
    /// <param name="name">The <see cref="IndexName"/> to cast into a <see cref="string"/>.</param>
    /// <returns>The <see cref="string"/> representation of the <see cref="IndexName"/>.</returns>
    public static implicit operator string(IndexName name) => name.ToString();

    /// <summary>
    /// Implements the explicit <c>(IndexName)</c> cast operator for the <see cref="string"/>.
    /// </summary>
    /// <param name="name">Then <see cref="string"/> to cast into an <see cref="IndexName"/>.</param>
    /// <returns>The <see cref="IndexName"/> created with the provided <see cref="string"/>.</returns>
    /// <exception cref="InvalidIndexNameException">
    ///     Throw when the <see cref="string"/> is not a valid <see cref="IndexName"/>.
    /// </exception>
    public static explicit operator IndexName(string name) => new IndexName(name);
}