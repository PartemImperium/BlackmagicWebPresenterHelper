using System.Net.Sockets;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var config = new AppConfig();

TcpClient client = new TcpClient(config.ServerHost, config.ServerPort);

var streamSettings = new StreamSettingsBlock()
{
    StreamKey = "1234 test stream key",
};

var serializer = new WebPresenterSerializer();

var message = serializer.Serialize(streamSettings);

// Translate the passed message into ASCII and store it as a Byte array.
Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

// Get a client stream for reading and writing.
//  Stream stream = client.GetStream();

NetworkStream stream = client.GetStream();

// Send the message to the connected TcpServer.
stream.Write(data, 0, data.Length);

Console.WriteLine("Sent: {0}", message);

// Receive the TcpServer.response.

// Buffer to store the response bytes.
data = new Byte[4096];

// String to store the response ASCII representation.
string responseData = String.Empty;

// Read the first batch of the TcpServer response bytes.
Int32 bytes = stream.Read(data, 0, data.Length);
responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
Console.WriteLine("Received: {0}", responseData);

// Close everything.
stream.Close();
client.Close();