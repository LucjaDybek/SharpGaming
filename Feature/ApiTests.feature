Feature: ApiTests
	As a user, I want to check 
	health informations 

Scenario: User wants to check health information status by API
	When User check health service status information by Api
	Then Health service status is correct

Scenario: User wants to check country information with language by API
	When User check country information
		| language |
		| en       |
		| es       |
		| pl       |
 
	Then Number of countries is correct
