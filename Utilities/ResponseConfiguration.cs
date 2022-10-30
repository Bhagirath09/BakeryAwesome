namespace BakeryAwesome.Utilities;
public class ResponseConfiguration
{
    public List<CONTENT> GetListContent<CONTENT>(RestResponse response)
    {
        var content = response.Content;
        List<CONTENT>? contentObject = JsonConvert.DeserializeObject<List<CONTENT>>(content);
        return contentObject;
    }

    public CONTENT GetContent<CONTENT>(RestResponse response)
    {
        var content = response.Content;
        CONTENT? contentObject = JsonConvert.DeserializeObject<CONTENT>(content);
        return contentObject;
    }
}