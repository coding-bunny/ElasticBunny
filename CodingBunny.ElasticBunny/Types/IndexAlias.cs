using System.Text.Json.Serialization;

namespace CodingBunny.ElasticBunny.Types;

public class IndexAlias
{
    /// <summary>
    /// Gets or sets the <see cref="AliasName"/> of the <see cref="IndexAlias"/>.
    /// </summary>
    [JsonIgnore]
    public AliasName Name { get; set; }

    // TODO: Implement Query DSL object
    [JsonPropertyName(FieldNames.Filter)]
    public string Filter { get; set; }

    // TODO: Implement IndexRouting strong-typed object
    /// <summary>
    /// Gets or sets the value used to route indexing operations to a specific shard.
    /// If specified, this overwrites the <see cref="IndexAlias.Routing"/> value for indexing operations.
    /// </summary>
    /// <remarks>This value is optional.</remarks>
    [JsonPropertyName(FieldNames.IndexRouting)]
    public Routing IndexRouting { get; set; }

    /// <summary>
    /// Gets or sets whether the <see cref="IndexAlias"/> is hidden. Defaults to <c>false</c>.
    /// </summary>
    [JsonPropertyName(FieldNames.IsHidden)]
    public bool IsHidden { get; set; }

    /// <summary>
    /// Gets or sets whether the index is the write index for the alias. Defaults to <c>false</c>.
    /// </summary>
    [JsonPropertyName(FieldNames.IsWriteIndex)]
    public bool IsWriteIndex { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Routing"/> used to route indexing and search operations to a specific shard.
    /// </summary>
    /// <remarks>This value is optional.</remarks>
    [JsonPropertyName(FieldNames.Routing)]
    public Routing Routing { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Routing"/> used to route search operations to a specific shard.
    /// If specified, this overwrites the <see cref="IndexAlias.Routing"/> value for search operations.
    /// </summary>
    [JsonPropertyName(FieldNames.SearchRouting)]
    public Routing SearchRouting { get; set; }
}
