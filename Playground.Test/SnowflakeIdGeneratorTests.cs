using Xunit;

public class SnowflakeIdGeneratorTests
{
    [Fact]
    public void GenerateId_ShouldReturnUniqueIds()
    {
        // Arrange
        var generator = new SnowflakeIdGenerator(1);

        // Act
        long id1 = generator.GenerateId();
        long id2 = generator.GenerateId();

        // Assert
        Assert.NotEqual(id1, id2);
    }

    [Fact]
    public void GenerateId_ShouldNotReturnNegativeIds()
    {
        // Arrange
        var generator = new SnowflakeIdGenerator(1);

        // Act
        long id = generator.GenerateId();

        // Assert
        Assert.True(id >= 0);
    }

    [Fact]
    public void GenerateId_ShouldNotReturnSameIdForConsecutiveCalls()
    {
        // Arrange
        var generator = new SnowflakeIdGenerator(1);

        // Act
        long id1 = generator.GenerateId();
        long id2 = generator.GenerateId();

        // add delay of 2 milliseconds to ensure that the timestamp changes
        Thread.Sleep(2);
        long id3 = generator.GenerateId();

        var diff = id2 - id1;
        var diff2 = id3 - id2;

        // Assert
        Assert.NotEqual(id1, id2);
    }
}
