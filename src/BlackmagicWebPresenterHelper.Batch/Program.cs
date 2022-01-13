var config = new AppConfig();

var serializer = new WebPresenterSerializer();

using var webPresenterCleint = new WebPresenterClient(config, serializer);

await new Worker(webPresenterCleint).ExecuteAsync();