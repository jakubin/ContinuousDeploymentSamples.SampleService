Feature: Notes

Scenario: Initially there are no notes
	When I request list of notes
	Then I receive no notes

Scenario: Adding note
	When I add note "Hello world"
	And I request list of notes
	Then I receive the following notes:
	| Content     |
	| Hello world |