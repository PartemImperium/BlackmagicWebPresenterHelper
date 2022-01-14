using Xunit;

namespace BlackmagicWebPresenterHelper.Tests;

public class WebPresenterSerializerTests
{
    [Fact]
    public void SerializerSingleField()
    {
        // Assert
        var serializer = CreateWebPresenterSerializer();
        var streamSettings = new StreamSettingsBlock() 
        {
            StreamKey = "my-super-secret-stream-key",
        };

        // Act
        var result = serializer.Serialize(streamSettings);

        // Arrange
        var expected = 
@"STREAM SETTINGS:
Stream Key: my-super-secret-stream-key

";// Create the expected here instead of directly in the Assert as it requires multiline which looks weird inside a function
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SerializerMultiField()
    {
        // Assert
        var serializer = CreateWebPresenterSerializer();
        var streamSettings = new StreamSettingsBlock() 
        {
            StreamKey = "my-super-secret-stream-key",
            CurrentVideoMode = "1080p59.94",
        };

        // Act
        var result = serializer.Serialize(streamSettings);

        // Arrange
        var expected = 
@"STREAM SETTINGS:
Video Mode: 1080p59.94
Stream Key: my-super-secret-stream-key

";// Create the expected here instead of directly in the Assert as it requires multiline which looks weird inside a function
        Assert.Equal(expected, result);
    }

    ///<summary>Create the serializer here even though it has no parameters in the constructor so that if they are ever added in the future they can be added as optional params here and the spots in this file do not need to change (unless they need the new parameter)</summary>
    private static WebPresenterSerializer CreateWebPresenterSerializer() => new();
}
