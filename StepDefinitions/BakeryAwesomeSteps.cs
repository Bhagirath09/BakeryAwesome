namespace BakeryAwesome.StepDefinitions;

[Binding]
[Scope(Tag = "Bakeryawesome")]
public class BakeryAwesomeSteps
{    
    private readonly ScenarioContext _scenarioContext;
    private readonly ApiClient _apiClient;
    private readonly RequestConfiguration _requestConfiguration;
    private readonly ResponseConfiguration _responseConfiguration;
    private readonly BakeryAwesomeResource _bakeryAwesomeResource;

    public BakeryAwesomeSteps(ScenarioContext scenarioContext)
    {
        _apiClient = new ApiClient();
        _requestConfiguration = new RequestConfiguration();
        _responseConfiguration = new ResponseConfiguration();
        _bakeryAwesomeResource = new BakeryAwesomeResource();
        _scenarioContext = scenarioContext;
    }

#region valid scenario for endpoint

    [When(@"I call BakeryAwesome endpoint")]
    public void WhenICallBakeryAwesomeEndpoint()
    {        
        var client = _apiClient.GetClient();
        var request = _requestConfiguration.CreateRequest(_bakeryAwesomeResource.Endpoint, Method.Get);
        _scenarioContext.Set<RestResponse>(client.Execute(request));     
    }

    [Then(@"I should see cake order details in response")]
    public void ThenIShouldSeeCakeOrderDetailsInResponse()
    {
        var response = _scenarioContext.Get<RestResponse>();
        response.IsSuccessful.Should().BeTrue();
        response.ContentType.Should().Be("application/json");

        var content = _responseConfiguration.GetListContent<BakeryAwesomeResponse>(response);
        content.Should().NotBeNullOrEmpty();
        content.Count.Should().BeGreaterThan(0);

        JsonHelper.IsJsonSchemaValid<BakeryAwesomeResponse>(JsonConvert.SerializeObject(content.FirstOrDefault())).Should().BeTrue();

        content.Should().Contain(x => x.CreatedAt < DateTimeOffset.Now);
        content.Should().Contain(x => x.CakeName != null);
        content.Should().Contain(x => x.Price != null);
        content.Should().Contain(x => x.ClientEmail != null);
        content.Should().Contain(x => x.Id != null);
    }

#endregion valid scenario for endpoint

#region valid scenario for endpoint with pathparam

    [When(@"I call BakeryAwesome endpoint with pathparam")]
    public void WhenICallBakeryAwesomeEndpointWithPathparam()
    {
        var client = _apiClient.GetClient();
        var request = _requestConfiguration.CreateRequest($"{_bakeryAwesomeResource.Endpoint}/{_bakeryAwesomeResource.PathParamOne}", Method.Get);
        _scenarioContext.Set<RestResponse>(client.Execute(request));
    }       

    [Then(@"I should see cake order details as per pathparam")]
    public void ThenIShouldSeeCakeOrderDetailsAsPerPathparam()
    {
        var response = _scenarioContext.Get<RestResponse>();
        response.IsSuccessful.Should().BeTrue();
        response.ContentType.Should().Be("application/json");

        var content = _responseConfiguration.GetContent<BakeryAwesomeResponse>(response);

        JsonHelper.IsJsonSchemaValid<BakeryAwesomeResponse>(JsonConvert.SerializeObject(content)).Should().BeTrue();

        content.CreatedAt.Should().BeBefore(DateTimeOffset.Now);
        content.CakeName.Should().NotBeNull();
        content.Price.Should().NotBeNull();
        content.ClientEmail.Should().NotBeNull();
        content.Id.Should().NotBeNull();
    }

#endregion valid scenario for endpoint with pathparam

#region invalid scenario for endpoint

    [When(@"I send request to BakeryAwesome endpoint with (.*)")]
    public void WhenISendRequestToBakeryAwesomeEndpointWith(string endpoint)
    {
        var client = _apiClient.GetClient();
        var request = _requestConfiguration.CreateRequest(DataHelper.GetBakeryAwesomeTestData(endpoint), Method.Get);
        _scenarioContext.Set<RestResponse>(client.Execute(request));
    }

#endregion invalid scenario for endpoint

#region common step to assert error code for endpoint and endpoint with pathparam

    [Then(@"I should see error code (.*) in response")]
    public void ThenIShouldSeeErrorCodeInResponse(int statusCode)
    {
        var response = _scenarioContext.Get<RestResponse>();
        response.IsSuccessful.Should().BeFalse();            
        ((int)response.StatusCode).Equals(statusCode).Should().BeTrue();
    }

#endregion common step to assert error code for endpoint and endpoint with pathparam

#region invalid scenario for endpoint with pathparam

    [When(@"I make call to BakeryAwesome endpoint with (.*)")]
    public void WhenIMakeCallToBakeryAwesomeEndpointWith(string pathParam)
    {
        var client = _apiClient.GetClient();
        var request = _requestConfiguration.CreateRequest($"{_bakeryAwesomeResource.Endpoint}/{DataHelper.GetBakeryAwesomeTestData(pathParam)}", Method.Get);
        _scenarioContext.Set<RestResponse>(client.Execute(request));
    }

#endregion invalid scenario for endpoint with pathparam

}