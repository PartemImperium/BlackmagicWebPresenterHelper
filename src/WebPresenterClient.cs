using System.Net.Sockets;

public class WebPresenterClient : IDisposable
{
    private bool disposedValue;

    private AppConfig Config { get; }
    private TcpClient? ClientConnection { get; set; }
    private NetworkStream? ClientStream { get; set; }
    private WebPresenterSerializer Serializer { get; }
    private bool IsInitialized { get; set; } = false;
    public WebPresenterClient(AppConfig config, WebPresenterSerializer webPresenterSerializer)
    {
        Config = config;
        Serializer = webPresenterSerializer;
    }

    private object initializeLock = new();
    public void Initialize()
    {
        if (!IsInitialized)
        {
            lock (initializeLock)
            {
                if (!IsInitialized)
                {
                    IsInitialized = true;

                    ClientConnection = new(Config.ServerHost, Config.ServerPort);
                    ClientStream = ClientConnection.GetStream();
                }
            }
        }
    }

    private void CheckInitialized()
    {
        if (!IsInitialized || ClientStream == null || ClientConnection == null)
        {//TODO: Make a custom exception type... And make the message better.
            throw new Exception("Yo dawg. Ya gotta initialize first...");
        }
    }

    public async Task<TOuput> SendMessageAsync<TInput, TOuput>(TInput input) where TInput : new()
                                                                             where TOuput : new()
    {
        CheckInitialized();

        var bytes = Serializer.SerializeBytes(input);

        await ClientStream.WriteAsync(bytes, 0, bytes.Length);

        byte[] data = new byte[8196];
        string responseData = string.Empty;

        int numBytes = await ClientStream.ReadAsync(data, 0, data.Length);
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, numBytes);

        //TODO:Deserialize the response and return it.
        Console.WriteLine($"Received: {responseData}");

        return new();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                ClientStream?.Close();
                ClientStream?.Dispose();

                ClientConnection?.Close();
                ClientConnection?.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}