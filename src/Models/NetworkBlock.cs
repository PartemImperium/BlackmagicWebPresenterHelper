using System.ComponentModel;

[Description("NETWORK")]
public class NetworkBlock
{
    [Description("Interface Count")]
    public int? InterfaceCount { get; set; }

    [Description("Default Interface")]
    public int? DefaultInterface { get; set; }

    [Description("Static DNS Servers")]
    public string? StaticDnsServers { get; set; }//TODO: Make this a List<IP> (its actual value is a CSV of IPv4 addresses)

    [Description("Current DNS Servers")]
    public string? CurrentDnsServers { get; set; }//TODO: Make this a List<IP> (its actual value is a CSV of IPv4 addresses)
}