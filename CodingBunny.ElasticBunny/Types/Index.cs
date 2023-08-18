using System.Text.Json.Serialization;

namespace CodingBunny.ElasticBunny.Types;

/// <summary>
/// This class represents the base of the ElasticSearch index, and is used by the framework to enforce a few
/// standards and constraints. Users of the framework should derive from this class, and implement their own
/// Index representation to be serialized to JSON and sent to ElasticSearch.
/// </summary>
public abstract class Index
{
    /// <summary>
    /// Creates a new instance of the <see cref="Index"/> class.
    /// </summary>
    /// <param name="name">The <see cref="IndexName"/> of the ElasticSearch Index.</param>
    protected Index(IndexName name)
    {
        Name = name;
    }
    
    /// <summary>
    /// Gets the <see cref="IndexName"/> of the ElasticSearch Index.
    /// </summary>
    [JsonIgnore]
    public IndexName Name { get; }
}
