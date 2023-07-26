Feature: Email signup in MailSlurp sample website

Create a 
	- MailSlurp email address
	- receive a confirm code
	- Verify the account
	- Login to MailSlurp and see a happy dog

@signup
Scenario: User sign up and email verification
	Given an user visits the MailSlurp demo web site
	And has a test email address
	When the user signs up
	Then the receive a confirmation code by email that can verify their account


