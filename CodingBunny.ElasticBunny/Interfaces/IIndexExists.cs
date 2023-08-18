using Index = CodingBunny.ElasticBunny.Types.Index;

namespace CodingBunny.ElasticBunny.Interfaces;

/// <summary>
/// This interface provides the functionality to determine whether an <see cref="Index"/> actually exists
/// inside the ElasticSearch cluster.
/// </summary>
public interface IIndexExists
{
    /// <summary>
    /// Returns <c>true</c> if the <see cref="Index"/> exists inside the ElasticSearch cluster, <c>false</c> otherwise.
    /// </summary>
    /// <param name="name">The <see cref="Index"/> to verify in the ElasticSearch cluster.</param>
    /// <returns>A <see cref="bool"/> representing the logical outcome of the check.</returns>
    public bool Exists(Index name);

    /// <summary>
    /// Performs an asynchronous operation to determine whether the <see cref="Index"/> exists inside
    /// the ElasticSearch cluster and returns the result.
    /// </summary>
    /// <param name="name">The <see cref="Index"/> to verify in the ElasticSearch cluster.</param>
    /// <returns>A <see cref="Task"/> with the <see cref="bool"/> result of the check.</returns>
    public Task<bool> ExistsAsync(Index name);
}