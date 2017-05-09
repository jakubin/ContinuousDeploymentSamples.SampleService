﻿Feature: Notes

Scenario: Adding and getting single note
	When I add note "My first note"
	And I request last added note
	Then I receive note "My first note"

Scenario: Delete note
	When I add note "My note"
	And I delete last added note
	And I request last added note
	Then the note is not found