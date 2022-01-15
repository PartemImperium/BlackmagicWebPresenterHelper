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

    [Fact]
    public void DeserializePreamble() 
    {
        // Arrange
        var payload = PreamblePaylod;
        var serializer = CreateWebPresenterSerializer();

        // Act
        var result = serializer.Deserialize<object>(payload);

        // Assert

    }

    private const string PreamblePaylod = 
@"PROTOCOL PREAMBLE:
Version: 1.0

IDENTITY:
Model: Web Presenter HD
Label: Blackmagic Web Presenter HD
Unique ID: AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

VERSION:
Product ID: BE73
Hardware Version: 0100
Software Version: 653BF387
Software Release: 2.1.1

NETWORK:
Interface Count: 2
Default Interface: 0
Static DNS Servers: 8.8.8.8, 8.8.4.4
Current DNS Servers: 10.0.1.1, 8.8.4.4

NETWORK INTERFACE 0:
Name: Cadence GigE Ethernet MAC
Priority: 0
MAC Address: 00:00:00:00:00:00
Dynamic IP: true
Current Addresses: 10.0.14.184/255.255.192.0
Current Gateway: 10.0.1.1
Static Addresses: 10.0.0.2/255.255.255.0
Static Gateway: 10.0.0.1

NETWORK INTERFACE 1:
Name: USB Ethernet
Priority: 0
MAC Address: 00:00:00:00:00:00
Dynamic IP: true
Current Addresses: 0.0.0.0/255.255.0.0
Current Gateway: 0.0.0.0
Static Addresses: 10.0.0.2/255.255.255.0
Static Gateway: 10.0.0.1

UI SETTINGS:
Available Locales: en_US.UTF-8, zh_CN.UTF-8, ja_JP.UTF-8, ko_KR.UTF-8, es_ES.UTF-8, de_DE.UTF-8, fr_FR.UTF-8, ru_RU.UTF-8, it_IT.UTF-8, pt_BR.UTF-8, tr_TR.UTF-8
Current Locale: en_US.UTF-8
Available Audio Meters: PPM -18dB, PPM -20dB, VU -18dB, VU -20dB
Current Audio Meter: VU -20dB

STREAM SETTINGS:
Available Video Modes: Auto, 1080p23.98, 1080p24, 1080p25, 1080p29.97, 1080p30, 1080p50, 1080p59.94, 1080p60, 720p25, 720p30, 720p50, 720p60
Video Mode: Auto
Current Platform: Facebook
Current Server: Default
Current Quality Level: Streaming High
Stream Key: 
Available Default Platforms: Facebook, Twitch, YouTube, Twitter / Periscope, Restream.IO
Available Custom Platforms: 
Available Servers: Default
Available Quality Levels: HyperDeck High, HyperDeck Medium, HyperDeck Low, Streaming High, Streaming Medium, Streaming Low

STREAM XML:
Files: 

STREAM STATE:
Status: Idle
Bitrate: 128153
Duration: 00:00:00:00

END PRELUDE:

";

    ///<summary>Create the serializer here even though it has no parameters in the constructor so that if they are ever added in the future they can be added as optional params here and the spots in this file do not need to change (unless they need the new parameter)</summary>
    private static WebPresenterSerializer CreateWebPresenterSerializer() => new();
}
