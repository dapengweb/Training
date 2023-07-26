Feature: RPNCalculator

@Addition
Scenario:Simple addition
	Given the rpn expression input is "150 200 +"
	When the evaluated method is invoked
	Then the expected result is "350.0"