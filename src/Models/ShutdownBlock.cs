using System.ComponentModel;

[Description("SHUTDOWN")]
public class ShutdownBlock
{
    public string? Action { get; set; }//TODO: Make this a Enum {Reboot, Factory Reset}
}