Feature: YouTube Search Feature
	As a developer,I want to ensure the YouTube search functionality works end to end.

@tag1
Scenario: When I navigate to YouTube website, I should YouTube page YouTube title
	Given I typed YouTube url "https://www.youtube.com"
	When I navigate to youtube page
	Then the web page title should be "youtube"

@tag1
Scenario: When I navigate to YouTube website and searching a channel
	Given I typed YouTube url "https://www.youtube.com"
	When I navigate to youtube page
	And I search for "jeganathan swaminathan" in the YouTube
	Then the web page title should be "jeganathan swaminathan"

