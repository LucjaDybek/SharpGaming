Feature: Lotto filtering results
		As a User, I want to filter Lotto results by date

Scenario: Filtering results for last 7 days
Given User enters to the Results page
When User picks the date -7 days ago and show results
Then Results section only show results from -7 days
