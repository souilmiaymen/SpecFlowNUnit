Feature: Login
	Login to EA Demo application

@mytag
Scenario: Perform Login of EA Application Site
	#steps
	Given I launch the application
	And I click login link
	And I enter the following details
		| UserName | Password |
		| admin    | password |
	And I click login button
	Then I should see Employee details link

	@mytag
Scenario: Perform Login of EA Application Site With Wrong Password
	#steps
	Given I launch the application
	And I click login link
	And I enter the following details
		| UserName | Password |
		| admin    | password1 |
	And I click login button
	Then I should see Login Invalid Text