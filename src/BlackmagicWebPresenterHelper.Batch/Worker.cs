public class Worker
{
    private WebPresenterClient WebPresenterCleint { get; }

    public Worker(WebPresenterClient webPresenterCleint)
    {
        WebPresenterCleint = webPresenterCleint;
    }


    public async Task ExecuteAsync()
    {
        WebPresenterCleint.Initialize();

        var streamSettings = new StreamSettingsBlock()
        {
            StreamKey = "1234 test stream key",
        };

        await WebPresenterCleint.SendMessageAsync<StreamSettingsBlock,StreamSettingsBlock>(streamSettings);
    }
}