namespace BakeryAwesome.Utilities;
public class RequestConfiguration
{
    private RestRequest request;

    public RestRequest CreateRequest(string resource, Method method)
    {
        return request = new RestRequest(resource, method);
    }
    public RestRequest AddRequestPathParameter(string name, string value)
    {
        return request.AddParameter(name, value);
    }

    public RestRequest AddRequestBodyParameter(string? name, object value, ParameterType type)
    {
        return request.AddParameter(name, value, type);
    }

    public RestRequest AddRequestQueryStringParameter(string name, string value)
    {
        return request.AddQueryParameter(name, value);
    }

    public RestRequest AddRequestHeader(string name, string value)
    {
        return request.AddHeader(name, value);
    }

    public RestRequest AddRequestBody(string body, string contentType)
    {
        return request.AddStringBody(body, contentType);
    }
}