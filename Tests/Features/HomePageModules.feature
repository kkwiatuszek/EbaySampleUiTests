Feature: HomePageModules
	In order to have user friendly interface
	As a product owner
	I want ebay home page to show different modules in content


Background: 
	Given I have navigated to home page of ebay

@done
Scenario Outline: HomePageModules - Menu with tabs display correct categories
	Then menu tab should show correct <categories>
	Examples: 
	| categories      |
	| Fashion		  |
	| Home & Garden	  |
	| Electronics	  |
	| Sports & Leisure |
	| Collectables	  |
	| Health & Beauty |
	| Motors          |
	| More            |

@done
Scenario: HomePageModules - Category tab in menu has a drop down list with subcategories
	When I hover "Collectables" category
	Then list of subcategories is displayed

@done
Scenario: HomePageModules - Clicking on category tab redirects to correct page
	When I click "Electronics" category
	Then page redirects to  "Electronics" category page

@test
Scenario: HomePageModules - Banner carousel's arrow navigates to different image on the left
	When I click left arrow on carousel
	Then image changes

Scenario: HomePageModules - Banner carousel's arrow navigates to different image on the right
	When I click right arrow on carousel
	Then image changes