using System.ComponentModel;

[Description("IDENTITY")]
public class IdentityBlock
{
    public string? Model { get; set; }

    public string? Label { get; set; }

    [Description("Unique ID")]
    public string? UniqueId { get; set; }//TODO: Change type to match actual of Hexadecimal ID
}