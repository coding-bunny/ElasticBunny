using System;
using System.Collections.Generic;
using System.Linq;
using CodingBunny.ElasticBunny.Exceptions;
using CodingBunny.ElasticBunny.Types;
using FluentAssertions;
using Xunit;

namespace CodingBunny.ElasticBunny.Tests.Types;

public class IndexNameTests
{
    [Fact]
    public void ConstructorThrowsOnNull()
    {
        var ctx = () => new IndexName(null!);

        ctx.Should().Throw<InvalidIndexNameException>().WithMessage("Index name cannot be null or empty.");
    }
    
    [Fact]
    public void ConstructorThrowsOnEmptyString()
    {
        var ctx = () => new IndexName("");

        ctx.Should().Throw<InvalidIndexNameException>().WithMessage("Index name cannot be null or empty.");
    }
    
    [Fact]
    public void ConstructorThrowsOnWhitespace()
    {
        var ctx = () => new IndexName(" ");

        ctx.Should().Throw<InvalidIndexNameException>().WithMessage("Index name cannot be null or empty.");
    }
    
    [Theory]
    [InlineData("UPPERCASE")]
    [InlineData("indexName")]
    [InlineData("IndexName")]
    [InlineData("indexNamE")]
    public void ConstructorThrowsOnUpperCase(string name)
    {
        var ctx = () => new IndexName(name);

        ctx.Should().Throw<InvalidIndexNameException>().WithMessage($"Index '{name}' cannot contain uppercase letters.");
    }

    [Theory]
    [InlineData("index\\name")]
    [InlineData("index/name")]
    [InlineData("index-name*")]
    [InlineData("index-name?")]
    [InlineData("<index-name>")]
    [InlineData("index|name")]
    [InlineData("index,name")]
    [InlineData("#index-name")]
    [InlineData("index:name")]
    public void ConstructorThrowsOnInvalidCharacters(string name)
    {
        var ctx = () => new IndexName(name);

        ctx.Should().Throw<InvalidIndexNameException>().WithMessage(
            $"Index '{name}' cannot contain any of the following characters: {InvalidIndexNameException.InvalidCharacters}");
    }

    [Theory]
    [InlineData("-index-name")]
    [InlineData("_index-name")]
    [InlineData("+index-name")]
    public void ConstructorThrowsOnInvalidStartingCharacters(string name)
    {
        var ctx = () => new IndexName(name);

        ctx.Should().Throw<InvalidIndexNameException>().WithMessage(
            $"Index '{name}' cannot start with any of the following characters: {InvalidIndexNameException.InvalidStartCharacters}");
    }
    
    [Theory]
    [InlineData(".")]
    [InlineData("..")]
    public void ConstructorThrowsOnForbiddenNames(string name)
    {
        var ctx = () => new IndexName(name);

        ctx.Should().Throw<InvalidIndexNameException>().WithMessage(
            $"Index '{name}' cannot be any of the following: {InvalidIndexNameException.ForbiddenNames}");
    }

    [Fact]
    public void ConstructorThrowsOnTooLongBytesNames()
    {
        Random random = new Random();
        byte[] bytes = new byte[256];
        random.NextBytes(bytes);
        
        var name = System.Text.Encoding.UTF8.GetString(bytes).ToLower();
        var chars = new List<char>(InvalidIndexNameException.InvalidCharacters);
        
        chars.AddRange(InvalidIndexNameException.InvalidStartCharacters);

        foreach (char c in chars)
        {
            name = name.Replace(c, '-');
        }
        
        var ctx = () => new IndexName(name);

        ctx.Should().Throw<InvalidIndexNameException>()
            .WithMessage($"Index '{name}' cannot be longer than {InvalidIndexNameException.MaxLength} bytes.");
    }
}