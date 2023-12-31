﻿using CodingBunny.ElasticBunny.Types;

namespace CodingBunny.ElasticBunny;

/// <summary>
/// This interface forms the main functional contract that clients need to adhere to inside the framework.
/// Every client is expected to offer this functionality, which maps more or less to the functionality provided
/// by ElasticSearch itself over their REST API.
/// </summary>
public interface IElasticClient
{
    public bool IndexExists(IndexName name);

    public Task<bool> IndexExistsAsync(IndexName name);
    
}