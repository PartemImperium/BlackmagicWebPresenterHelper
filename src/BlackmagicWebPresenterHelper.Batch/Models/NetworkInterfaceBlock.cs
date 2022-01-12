using System.ComponentModel;

[Description("NETWORK INTERFACE {INTERACE NUMBER}")]//TODO: Figure out how to handle variable info in section header....
public class NetworkInterfaceBlock
{
    [Description("Name")]
    public string? Name { get; set; }

    [Description("Priority")]//TODO: Change to unsighed int
    public int? Priority { get; set; }

    [Description("MAC Address")]
    public string? MacAddress { get; set; }//TODO: Make this a MacAddress (might need to create a class)

    //TODO: Add xmldoc coment describing true - DHCP enabled false - Static IP
    [Description("Dynamic IP")]
    public bool? IsDynamicIp { get; set; }//TODO: Make this a List<IP> (its actual value is a CSV of IPv4 addresses)

    [Description("Current Addresses")]
    public string? CurrentAddresses { get; set; }//TODO: Make this a IP(with subnetmask) (might need to create a class)

    [Description("Current Gateway")]
    public string? CurrentGateway { get; set; }//TODO: Make this a IP

    [Description("Static Addresses")]
    public string? StaticAddress { get; set; }//TODO: Make this a IP(with subnetmask) (might need to create a class)

    [Description("Static Gateway")]
    public string? StaticGateway { get; set; }//TODO: Make this a IP

}