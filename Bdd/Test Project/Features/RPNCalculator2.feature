Feature: RPNCalculator2

@Addition
Scenario Outline: Simple addition
	Given the rpn math expression input is <input>
	When thie evaluate method is invoked
	Then this expected result is <expectedoutput>
	Examples:
		| input       | expectedoutput |
		| "250 100 +" | "350.0"        |
		| "10 20 +"   | "30.0"         |
		| "10 -20 +"  | "-10.0"        |
		| "10 2 +"    | "12.0"         |

@Substraction
Scenario Outline: Simple substraction
	Given the rpn math expression input is <input>
	When thie evaluate method is invoked
	Then this expected result is <expectedoutput>
	Examples:
		| input        | expectedoutput |
		| "250 100 -"  | "150.0"        |
		| "10 20 -"    | "-10.0"        |
		| "2500 100 -" | "2400.0"       |
		| "10 2 -"     | "8.0"          |


@Multiplication
Scenario Outline: Simple multiplication
	Given the rpn math expression input is <input>
	When thie evaluate method is invoked
	Then this expected result is <expectedoutput>
	Examples:
		| input      | expectedoutput |
		| "25 10 *"  | "250.0"        |
		| "10 20 *"  | "200.0"        |
		| "25 100 *" | "2500.0"       |
		| "10 2 *"   | "20.0"         |

@Division
Scenario Outline: Simple division
	Given the rpn math expression input is <input>
	When thie evaluate method is invoked
	Then this expected result is <expectedoutput>
	Examples:
		| input      | expectedoutput |
		| "250 10 /" | "25.0"         |
		| "20 10 /"  | "2.0"          |
		| "25 10 /"  | "2.5"          |
		| "10 2 /"   | "5.0"          |

@ComplexRPNExpression
Scenario Outline: Complex RPN Math expression that involves many math operators
	Given the rpn math expression input is <input>
	When thie evaluate method is invoked
	Then this expected result is <expectedoutput>
	Examples:
		| input                           | expectedoutput |
		| "3 4 * 5 6 * +"                 | "42.0"         |
		| "10 6 9 3 + -11 * / * 17 + 5 +" | "21.545454"    |

@InvalidRPNMathExpression
Scenario Outline: Invalid RPN Math Expression
	Given the rpn math expression input is <input>
	When thie evaluate method is invoked
	Then it should throw Exception with message <expectedoutput>
	Examples:
		| input           | expectedoutput           |
		| "3 4 @ 5 6 * +" | "Invalid RPN Expression" |
		| "3 + 4"         | "Invalid RPN Expression" |
		| "3 - 4"         | "Invalid RPN" |