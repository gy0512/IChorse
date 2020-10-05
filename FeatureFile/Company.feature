Feature: Company
	Login, Create, Edit, or Delete Company record
	
Background: 
	Given I login to the TurnUp for Company
	And I navigate to the Company

Scenario: T1 Verify the Company is created
	Given I click the create new button for Company
	And I input the details for creating Company
	And I click the save button for creating Company
	Then I should see the given Company record

Scenario: T2 Verify the Company is edited
	Given I click the create new button for Company
	And I input the details for creating Company
	And I click the save button for creating Company
	And I should see the given Company record

	And I click the edit button for edit Company
	And I input the details for edit Company
	And I click the save button for edit Company
	Then I should see the given Company record is modified

Scenario: T3 Verify the Company is deleted
	Given I click the create new button for Company
	And I input the details for creating Company
	And I click the save button for creating Company
	And I should see the given Company record

	And I click the edit button for edit Company
	And I input the details for edit Company
	And I click the save button for edit Company
	And I should see the given Company record is modified

	And I click the delete button and confirm to delete for deleting Company
	Then I should see the given Company record deleted