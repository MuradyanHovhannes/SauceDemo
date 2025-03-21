Task Description
This task focuses on testing the login functionality of the Sauce Demo website. The URL under test is:
https://www.saucedemo.com/

You must implement three main use cases (UC-1, UC-2, UC-3) with parallel execution, logging for tests, and data-driven approaches. The three use cases are:

UC-1 Test Login Form with Empty Credentials  
Type any credentials into the Username and Password fields.
Clear the inputs.
Click the Login button.
Verify the error message:
"Username is required"
UC-2 Test Login Form by Passing Username Only
Type any credentials into the Username field.
Enter a Password, then clear the Password field.
Click the Login button.
Verify the error message:
"Password is required"
UC-3 Test Login Form with Valid Credentials
Type valid credentials into the Username field (these are accepted usernames from the site).
Enter the Password which is "secret_sauce".
Click Login.
Validate that the Dashboard title is "Swag Labs".
All tasks (UC-1, UC-2, UC-3) should be supported by your test framework in a single test suite.

Requirements and Technical Details
Test Automation Tool
Selenium WebDriver
Supported Browsers
Microsoft Edge
Mozilla Firefox
Locators
CSS Selectors
Test Runner
xUnit
Parallel Execution
Implement parallel test execution to reduce overall test time.

Data Provider (Parameterization)
Use data providers to feed test data for different scenarios (username/password combinations).

Logging
Add logging to capture important test information (such as test steps, pass/fail results, or debugging messages).
(Optional) Consider using Log4Net for logging.

Optional Design/Testing Patterns
Abstract Factory
Adapter
Bridge
BDD (Behavior-Driven Development)
Assertions
FluentAssertions for readable test validation.
Project Structure (Example)
Below is a general suggestion of how you might structure your project:



ProjectRoot
├── Tests
│   ├── LoginTests.cs         # Contains UC-1, UC-2, UC-3 with xUnit
│   ├── TestData
│   │   └── LoginCredentials.json (example data file for DataProvider)
│   └── ...
├── Pages
│   ├── LoginPage.cs
│   └── DashboardPage.cs
├── Drivers
│   └── WebDriverFactory.cs   # Example for Abstract Factory pattern
├── Logging
│   └── LogConfig.xml         # Example for Log4Net configuration
└── README.md
Getting Started
Clone or download the repository.
Make sure you have the necessary dependencies installed (e.g., Selenium, xUnit, FluentAssertions).
Configure your testing framework to run on both Edge and Firefox.
If you opt to use patterns like Abstract Factory or BDD, set up the required classes or frameworks.
Include your data file for credentials in the test data folder.
Use the data provider to supply valid/invalid username/password combinations to the tests.
Configure logging (if desired) to capture test run details.
How to Run Tests
Open the solution in your preferred IDE.
Choose the test runner (xUnit).
Select both browsers (Edge and Firefox) if your parallel setup can handle multiple browsers simultaneously.
Run all tests.
Check the results and logs for pass/fail status and detailed messages.
Notes
When testing with multiple browsers, ensure you have the correct WebDriver executables for Edge and Firefox.
Parallel execution might require additional setup in your environment or CI/CD pipeline.
Data-driven testing is especially useful for UC-1 and UC-2 when testing various bad or empty credentials.
You can use the BDD approach if you want to structure tests in a more business-friendly way.
Contributing
Fork the project.
Create your feature branch (git checkout -b feature/my-new-feature).
Commit your changes (git commit -am 'Add some feature').
Push to the branch (git push origin feature/my-new-feature).
Create a new Pull Request.
License
The license is not specified; you may add your own or consider using an open source license if it suits your organizational needs.