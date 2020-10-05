Feature: TM
	Login, Create, Edit, or Delete TM record
	
Background: 
	Given I login to the TurnUp
	And I navigate to the TM

Scenario Outline: T0 Verify multiple TM creation
	When I create entries using code: '<code>' and price: '<price>'
	Then I am able to verify with code: '<code>'
 	Examples: 
	| code           | price |
	| 20201004224101 | 10    |
	| 20201004224102 | 20    |

#Scenario: Verify usage of data table 
#	When I created entries using values from table :
#	| code			 | price |
#	| 20201004224101 | 10	 |
#	| 20201004224102 | 20	 |

Scenario: T1 Verify the TM is created
	Given I click the create new button
	#And I create entries using code: '<code>' and price: '<price>'
	# 	Examples: 
	#	| code			 | price |
	#	| 20201004224101 | 10	 |
	#	| 20201004224102 | 20	 |
	And I input the details for creating TM
	And I click the save button
	Then I should see the given TM record


#Scenario: T2 Verify the TM is edited
#	Given I click the create new button
#	And I input the details for creating TM
#	And I click the save button
#	And I should see the given TM record
#
#	And I click the edit button
#	And I input the details for edit TM
#	And I click the save button for edit TM
#	Then I should see the given TM record is modified
#
#
#Scenario: T3 Verify the TM is deleted
#	Given I click the create new button
#	And I input the details for creating TM
#	And I click the save button
#	And I should see the given TM record
#
#	And I click the edit button
#	And I input the details for edit TM
#	And I click the save button for edit TM
#	And I should see the given TM record is modified
#
#	And I click the delete button and confirm to delete for deleting TM
#	Then I should see the given TM record deleted
