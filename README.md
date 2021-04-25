# MMT Tech Test

The solution contains a .NET core solution with 3 projects inside:

* Core - code to handle low level selenium webdriver driver/api functions
* e2e gui tests - test project which uses xbehave and xunit for BDD/Gherkin type scenarios
* page objects - standard page object model you'd use with any e2e gui based testing framework

## Remarks/Observations on the tech test itself

* The scenarios in the test are breaking some fundamental rules in Gherkin - use of the word "I" for example?
* The way they're written is also anti-pattern - the test steps are now hard coded to the UI?
* If the UI changes the tests steps effectively could become invalid?
* It's best to write a user story which describes behavior *not* UI elements - you'd have to go back
and rewrite the test steps now if the UI changes. It also means that behaviours could be tested underneath
the UI depending on how the application has been architected - much better than having to rely on the UI.

## How to use
* You'll need the relevent .net core SDKs etc on your machine
* clone and open the sln file in your .net IDE of choice
* alternatively just execute "dotnet test" from within the "test\e2e\GuiTests_e2e" directory
* change the appsettings config file with the relevant strings to change the browser being used to execute the tests, this would be done in a CI/CD pipeline ideally

## Limitations
* solution was built on a windows machine, no safari browser support unfortunately
* haven't implemented the scenarios which are around accessibilty - it could have been achieved using the sendkeys functions from the webdriver API, would strongly recommend against writing automated tests like this however
* seems to be a bug with the current gecko driver for firefox, runs very slowly - didn't have time to investigate unfortunately
* didn't have time to implement any lighthouse automation via chrome
