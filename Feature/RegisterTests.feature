Feature: Registration process
	As an unregistered user 
	I want to create new account 

Scenario: Registration with correct set of data 
	Given Unregister user creates an account
	When User provides login data
	And Personal data
	And Security data
	And Address data
	And Confirms registration
    Then An account is created successfully

	