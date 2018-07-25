## .Net Core ASP MVC testing
### Purpose
To my surprise and horror, many of my favorite testing tools have not yet (shock!) been updated with .Net Core library versions!

Thankfully, NUnit3. I also like NSubstitute, but it's still early-days on the Core version. I may pitch in soon. In the meantime, good chance to see what Moq has been up to! 

In this example, I wanted to use the dotnet CLI mostly to set things up then write the missing tests for the default HomeController which, IMNHOP, should really be part of the default templates - after all, we (Microsoft? do want to promote TDD don't we? Hmmm?

The project source under test is from the 'ASP.NET Core with React.js' template, but that's not important in this example - as long as it's an ASP.NET Core web project.

### Setup, Powershell stuff 
1. Make sure you have the NUnit3 templates (one time thing):

Checkout the docs https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit

- dotnet new -i NUnit3.DotNetNew.Template

2. Create projects for web and test and initial reference (dependency) to web project under test:
- dotnet new web -o nodesvc
- dotnet new nunit -o nodesvc.test
- dotnet new sln
- dotnet sln add .\nodesvc\nodesvc.csproj
- dotnet sln add .\nodesvc.test\nodesvc.test.csproj
- cd  .\nodesvc.test
- dotnet add reference ..\nodesvc\nodesvc.csproj

3. See example tests in UnitTest1.cs

Note: VS2017 shows warnings in the test Dependencies folder view for the Project reference - it seems to be a bug that's being worked on, but doesn't affect the running of tests. May not be a problem at the time this is being read.

4. Run tests - just for fun - using dotnet command
- cd .\nodesvc.test
- dotnet test

Woot! All 3 tests pass. Yay.

Note: The tests themselves are fairly unremarkable, except it was interesting for me to use Moq - especially on the weird default "Error" action - just to see if it was testable in its as-is condition. Answer: yes, but...  




 