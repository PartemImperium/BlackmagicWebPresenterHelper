using System.ComponentModel;

[Description("STREAM STATE")]
public class StreamStateBlock
{
    public string? Status { get; set; }//TODO: Make this a Enum {Idle, Connecting, Streaming, Interrupted}

    public string? Action { get; set; }//TODO: Make this a Enum {Start, Stop}

    public string? Duration { get; set; }//TODO: Make this a TimeSpan. It is actually a string in DD:HH:MM:SS format

    public int? Bitrate { get; set; }
}