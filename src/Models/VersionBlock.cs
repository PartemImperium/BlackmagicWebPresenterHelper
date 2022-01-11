using System.ComponentModel;

[Description("VERSION")]
public class VersionBlock
{
    [Description("Product ID")]
    public string? ProductId { get; set; }//TODO: Change type to match actual of Hexadecimal ID

    [Description("Hardware Version")]
    public string? HardwareVersion { get; set; }//TODO: Chagne type to match actual of Hexadecimal version

    [Description("Software Version")]
    public string? SoftwareVersion { get; set; }//TODO: Chagne type to match actual of Hexadecimal version

    [Description("Software Release")]
    public string? SoftwareRelease { get; set; }//TODO: Change type to match actual of Version (1.0)
}