namespace CodingBunny.ElasticBunny.Interfaces;

/// <summary>
/// This interface forms the functional contract to which all connection settings must adhere.
/// This allows us to swap implementations for various clients and/or behaviors, depending on the need
/// of the user.
/// </summary>
public interface IConnectionSettings
{
    /// <summary>
    /// The <see cref="Uri"/> of the ElasticSearch instance.
    /// </summary>
    public Uri Url { get; set; }
}
