using System.ComponentModel;

[Description("STREAM SETTINGS")]
public class StreamSettingsBlock
{
    [Description("Available Video Modes")]
    public string? AvailableVideoModes { get; set; }//TODO: Make this a List<string> (or List<VideoModes> this will be more work to maintain though. Plus I dont know if these are customizible or static) (its actual value is a CSV of video modes)

    [Description("Video Mode")]
    public string? CurrentVideoMode { get; set; }//TODO: Make this a whatever T Type AvailableVideoModes uses

    [Description("Current Platform")]
    public string? CurrentPlatform { get; set; }//TODO: Possibly make this a class. It would be interesting though cause the value is actually a string but represents one of the avalible platforms (which could be represented as a class)

    [Description("Current Server")]
    public string? CurrentServer { get; set; }

    [Description("Current Quality Level")]
    public string? CurrentQualityLevel { get; set; }

    [Description("Stream Key")]
    public string? StreamKey { get; set; }

    [Description("Available Default Platforms")]
    public string? AvailableDefaultPlatforms { get; set; }//TODO: Make this a list (of either string or a platform class). It is actually a CSV of platforms

    [Description("Available Custom Platforms")]
    public string? AvailableCustomPlatforms { get; set; }//TODO: Make this a list (of either string or a platform class). It is actually a CSV of platforms

    [Description("Available Servers")]
    public string? AvailableServer { get; set; }//TODO: make this a List<string>. It is actually a CSV of servers

    [Description("Available Quality Levels")]
    public string? AvailableQualityLevels { get; set; }//TODO: make this a List<string>. It is actually a CSV of quality levels
}