using CodingBunny.ElasticBunny.Interfaces;
using CodingBunny.ElasticBunny.Types;
using Index = CodingBunny.ElasticBunny.Types.Index;

namespace CodingBunny.ElasticBunny;

/// <summary>
/// Concrete implementation of the <see cref="IElasticClient"/> interface, providing a default implementation using the
/// <c>System.Net.Http</c> and <c>System.Text.Json</c> libraries of the .NET Framework. 
/// </summary>
public class ElasticClient : IElasticClient, IDisposable
{
    /// <summary>
    /// The <see cref="IConnectionSettings"/> to control the HTTP Client to communicate with ElasticSearch
    /// </summary>
    private readonly IConnectionSettings _connectionSettings;
    
    private readonly HttpClient _httpClient = new();

    /// <summary>
    /// Flag to track whether the object has been disposed or not.
    /// </summary>
    private volatile bool _disposed;
    
    /// <summary>
    /// Creates a new instance of the <see cref="ElasticClient"/> class with the default settings applied.
    /// </summary>
    public ElasticClient() : this(new ConnectionSettings())
    { }
    
    /// <summary>
    /// Creates a new instance of the <see cref="ElasticClient"/> class with the provided <see cref="IConnectionSettings"/>.
    /// </summary>
    /// <param name="connectionSettings">The <see cref="IConnectionSettings"/> for the HTTP Client.</param>
    public ElasticClient(IConnectionSettings connectionSettings)
    {
        _connectionSettings = connectionSettings;
    }
    
    /// <inheritdoc cref="IIndexExists.Exists"/>
    public bool Exists(Index name)
    {
        return false;
    }
    
    /// <inheritdoc cref="IIndexExists.ExistsAsync"/>
    public Task<bool> ExistsAsync(Index name)
    {
        return new Task<bool>(() => false);
    }

    /// <summary>
    /// Disposes the object, releasing all resources claimed by the instance.
    /// </summary>
    public void Dispose()
    {
        if (_disposed) return;
        
        _httpClient.Dispose();
        _disposed = true;
    }

    /// <summary>
    /// Raises an <see cref="ObjectDisposedException"/> if the object has been disposed.
    /// </summary>
    /// <exception cref="ObjectDisposedException">Thrown when the object has been disposed.</exception>
    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException("ElasticClient instance has been disposed.");
        }
    }
}
