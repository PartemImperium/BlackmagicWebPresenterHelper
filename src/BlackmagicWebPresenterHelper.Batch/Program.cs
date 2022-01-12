var config = new AppConfig();

var streamSettings = new StreamSettingsBlock()
{
    StreamKey = "1234 test stream key",
};

var serializer = new WebPresenterSerializer();

using var webPresenterCleint = new WebPresenterClient(config, serializer);
webPresenterCleint.Initialize();

await webPresenterCleint.SendMessageAsync<StreamSettingsBlock,StreamSettingsBlock>(streamSettings);
