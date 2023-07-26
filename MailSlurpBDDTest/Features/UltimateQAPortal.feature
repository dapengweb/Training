Feature: UltimateQAPortal

This web portal has many test components that can be used for learning Specflow with Selenium BDD Test framework

@elementByItsId
Scenario: Retrieve Element by Id and sending click event
	Given I opened Chrome Web browser
	When  navigate to "https://www.ultimateqa.com/simple-html-elements-for-automation";
	Then it should take me to the success web page
	And Its title should be "Button success - Ultimate QA"

@elementByItsClassName
Scenario: Retrieve Button Element by its className and sending click event
	Given I opened Chrome Web browser
	And  navigate to "https://www.ultimateqa.com/simple-html-elements-for-automation";
	And I click the button with className "buttonClass"
	Then it should take me to the success web page with url "https://ultimateqa.com/button-success?"
	And Its title should be "Button success - Ultimate QA"

@elementByItsName
Scenario: Retrieve Button Element by its Name and sending click event
	Given I opened Chrome Web browser
	And  navigate to "https://www.ultimateqa.com/simple-html-elements-for-automation";
	And I click the button with Name "button1"
	Then it should take me to the success web page with url "https://ultimateqa.com/button-success/?button1="
	And Its title should be "Button success - Ultimate QA"

@elementByLinkText
Scenario: Retrieve anchor Element by its link text and sending click event
	Given I opened Chrome Web browser
	And  navigate to "https://www.ultimateqa.com/simple-html-elements-for-automation";
	And I click the anchor link that has a text "Click me using this link text!"
	Then it should take me to the success web page with url "https://ultimateqa.com/link-success/"
	And Its title should be "Link success - Ultimate QA"


@elementByType
Scenario: Select a value from drop down list and retrieve its value
	Given I opened Chrome Web browser
	And  navigate to "https://www.ultimateqa.com/simple-html-elements-for-automation";
	When I select a valuea "Opel" from the drop down
	Then it should shown the "Opel" option in the top of the drop down list
