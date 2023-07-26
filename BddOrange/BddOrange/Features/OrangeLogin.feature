Feature: OrangeLogin

A short summary of the feature

@login
@ingore
Scenario: login orange and make some operate
	Given go to url "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login"
	When we use username and password to login
	Then go to success url


