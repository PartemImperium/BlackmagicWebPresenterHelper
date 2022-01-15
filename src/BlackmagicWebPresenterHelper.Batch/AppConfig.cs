public class AppConfig
{
    public int ServerPort { get; set; } = 9977;
    public string ServerHost { get; set; } = 
    //"127.0.0.1";//TODO: Remove this default value once actual config is working
    "10.1.1.69";
}