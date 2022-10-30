namespace BakeryAwesome.Helpers;
public static class DataHelper
{
    public static string GetBakeryAwesomeTestData(string testData) 
    {
        switch (testData)
        {
            case "EndpointWithMissingChar":
                return "bakeryawesome";

            case "EndpointWithExtraChar":
                return "bakery-awesome1";

            case "InvalidPathParamOneHundred":
                return "100";

            default: 
                return "";
        }
    }
}