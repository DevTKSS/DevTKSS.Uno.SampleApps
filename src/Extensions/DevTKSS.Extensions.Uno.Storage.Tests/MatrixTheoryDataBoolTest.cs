using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Shouldly;

namespace DevTKSS.Extensions.Uno.Storage.Tests.Helpers;

public class MatrixTheoryDataBoolTest
{

    [Fact]
    public void Constructor_WithSingleElement_GeneratesTwoRows_WithBothBooleanValuesPresent()
    {
        // Arrange
        var data = new[] { 42 };

        // Act
        var matrix = new MatrixTheoryDataBool<int>(data);

        // Assert
        matrix.Count.ShouldBe(2);
        foreach (var row in matrix)
        {
            row.Data.Item1.ShouldBe(42);
            row.Data.Item2.ShouldBeOneOf(true, false);
        }
    }

    [Theory]
    [InlineData(["A", "B", "C"])]
    [InlineData(["A", "B", "C", "D", "E"])]
    public void Constructor_WithMultipleElements_GeneratesAllCombinations(params string[] data)
    {
        // Arrange - nothing to arrange

        // Act
        var matrix = new MatrixTheoryDataBool<string>(data);

        // Assert
        matrix.Count.ShouldBeEquivalentTo(data.Length * 2);
    
    }
}