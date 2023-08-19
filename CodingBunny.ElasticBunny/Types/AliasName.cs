namespace CodingBunny.ElasticBunny.Types;

/// <summary>
/// This class represents the ElasticSearch Index alias as a strong-type in the code base.
/// </summary>
public sealed class AliasName : IEquatable<AliasName>, IComparable<AliasName>, IComparable
{
    private readonly string _value;

    /// <summary>
    /// Creates a new instance of the <see cref="AliasName"/> with the given <see cref="string"/> value.
    /// </summary>
    /// <param name="name">The alias of the ElasticSearch Index.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is <c>null</c> or empty.</exception>
    public AliasName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        _value = name;
    }

    /// <summary>
    /// Checks against another <see cref="AliasName"/> for equality.
    /// </summary>
    /// <param name="other">The other <see cref="AliasName"/> to check against.</param>
    /// <returns><c>true</c> if both instances are considered equal; otherwise <c>false</c>.</returns>
    public bool Equals(AliasName? other)
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
        return ReferenceEquals(this, obj) || obj is AliasName other && Equals(other);
    }

    /// <summary>
    /// Returns the unique hash code of the <see cref="AliasName"/> instance.
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

        if ((AliasName)obj is null)
        {
            throw new ArgumentException("Object is not an IndexName");
        }

        return CompareTo((AliasName)obj);
    }

    /// <summary>
    /// Performs a logical comparison against another <see cref="AliasName"/>.
    /// </summary>
    /// <param name="other">The <see cref="AliasName"/> to compare against.</param>
    /// <returns>An <see cref="int"/> representing the logical result of the comparison.</returns>
    public int CompareTo(AliasName? other)
    {
        if (ReferenceEquals(this, other)) return 0;

        return ReferenceEquals(null, other) ? 1 : string.Compare(_value, other._value, StringComparison.Ordinal);
    }

    /// <summary>
    /// Returns a <see cref="string"/> representation of the <see cref="AliasName"/>
    /// </summary>
    /// <returns>A <see cref="string"/> representing the <see cref="AliasName"/>.</returns>
    public override string ToString()
    {
        return _value;
    }

    /// <summary>
    /// Implements the implicit <c>(string)</c> cast operator for the <see cref="AliasName"/>.
    /// </summary>
    /// <param name="name">The <see cref="AliasName"/> to cast into a <see cref="string"/>.</param>
    /// <returns>The <see cref="string"/> representation of the <see cref="AliasName"/>.</returns>
    public static implicit operator string(AliasName name) => name.ToString();

    /// <summary>
    /// Implements the explicit <c>(AliasName)</c> cast operator for the <see cref="string"/>.
    /// </summary>
    /// <param name="name">Then <see cref="string"/> to cast into an <see cref="AliasName"/>.</param>
    /// <returns>The <see cref="AliasName"/> created with the provided <see cref="string"/>.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Throw when the <see cref="string"/> is not a valid <see cref="AliasName"/>.
    /// </exception>
    public static explicit operator AliasName(string name) => new AliasName(name);
}
