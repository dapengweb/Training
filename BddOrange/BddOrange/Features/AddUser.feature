Feature: AddUser

A short summary of the feature

@addnewuser
Scenario:Create new admin user in Orange HRM
Given I have successfully logged in as Administrator in Orange HRM website
When I click on Admin menu and Add new Admin user
And filled up the necessary fields
Then I should be able to create a new admin user