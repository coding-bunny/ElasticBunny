using CodingBunny.ElasticBunny.Interfaces;

namespace CodingBunny.ElasticBunny.Types;

/// <summary>
/// Concrete implementation of the <see cref="IConnectionSettings"/> for the HTTP Client.
/// This class contains all information needed to actually connect to an ElasticSearch cluster, as well as control
/// how the HTTP Client acts.
/// </summary>
public class ConnectionSettings : IConnectionSettings
{
    /// <inheritdoc cref="IConnectionSettings.Url"/>
    public Uri Url { get; set; }
}