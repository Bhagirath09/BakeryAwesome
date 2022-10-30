namespace BakeryAwesome.Utilities;
public class ApiClient
{
    public RestClient GetClient()
    {
        var client = new RestClient(ConfigurationManager.AppSettings["baseUrl"]);
        return client;
    }
}