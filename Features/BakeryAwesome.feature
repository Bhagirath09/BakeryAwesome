Feature: BakeryAwesome

As a user I should be able to get Cake order details 

@Bakeryawesome
Scenario: Valid - Get all Cake orders - BakeryAwesome
	When I call BakeryAwesome endpoint 
	Then I should see cake order details in response

@Bakeryawesome
Scenario Outline: Invalid - Verify error code 404 with invalid endpoints  - BakeryAwesome
	When I send request to BakeryAwesome endpoint with <invalidEndpoint> 
	Then I should see error code 404 in response
	Examples: 
	| invalidEndpoint         |
	| EndpointWithMissingChar |
	| EndpointWithExtraChar   |

@Bakeryawesome @BakeryawesomePathparam
Scenario: Valid - Get Cake order details - BakeryAwesome with pathparam
	When I call BakeryAwesome endpoint with pathparam 
	Then I should see cake order details as per pathparam 

@Bakeryawesome @BakeryawesomePathparam
Scenario Outline: Invalid - Verify error code 500 with invalid path parameter  - BakeryAwesome with pathparam
	When I make call to BakeryAwesome endpoint with <invalidPathParam>
	Then I should see error code 500 in response
	Examples: 
	| invalidPathParam           |
	| InvalidPathParamOneHundred |