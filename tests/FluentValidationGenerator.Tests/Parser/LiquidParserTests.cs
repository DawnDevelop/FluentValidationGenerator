using FluentAssertions;
using FluentValidationGenerator.Parser;
using Moq;
using NUnit.Framework;
using System;
using System.Reflection;

namespace FluentValidationGenerator.Tests.Parser;

[TestFixture]
public class LiquidParserTests
{


    [Test]
    public void ShouldReturnEmbeddedResourceTemplate()
    {
        LiquidParser.GetEmbeddedTemplate().Should().NotBeEmpty();
    }

    [Test]
    public void ShouldHaveParsedDictionaryTemplate()
    {
        LiquidParser.ParseAllTemplatesFromAssembly(typeof(LiquidParserTests).Assembly).Should().NotBeEmpty();
    }
}
