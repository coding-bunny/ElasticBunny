using System.Collections;
using System.Text.Json.Serialization;

namespace CodingBunny.ElasticBunny.Types;

/// <summary>
/// This class represents the "aliases" property of the ElasticSearch index, and is used to add alias definitions to
/// the ElasticSearch index upon creation. An index can have multiple aliases, or none at all.
/// </summary>
public sealed class IndexAliases
{
    private readonly IDictionary<string, IndexAlias> _aliases = new Dictionary<string, IndexAlias>();


    public void Add(IndexAlias alias)
    {
        _aliases.Add(alias.Name, alias);
    }

    public void Clear()
    {
        _aliases.Clear();
    }

    public bool Contains(IndexAlias alias)
    {
        return _aliases.ContainsKey(alias.Name);
    }

    public bool Remove(IndexAlias alias)
    {
        return _aliases.Remove(alias.Name);
    }

    public IndexAlias? this[AliasName key]
    {
        get => _aliases[key];
        set => _aliases[key] = value ?? throw new ArgumentNullException(nameof(value));
    }

    public ICollection Keys => (ICollection)_aliases.Keys;

    public ICollection Values => (ICollection)_aliases.Values;

    public int Count => _aliases.Count;
}
