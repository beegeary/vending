# vending
Vending Machine Kata (Console Application)

Simple vending machine to accept payment for three products and dispense as payments are accepted. I built the application with a simple plan: create VendingMachine class to hold the display of text with some values dropped in on the fly, containing the current state of values (under the main "Run" method). This class also has a ConvertCoin method to turn coin weights into money amounts.

Then a BalanceSheet class, loaded by the above VendingMachine class, to hold and process all inventory and money amounts. Has several fields to hold the current amounts as the machine is in operation. Most important is a SelectItem() method that checks a couple of conditions (is money enough? do products exist?) and then adjusts values as it "dispenses" products.

Interaction with the application is just a matter of tapping single keys on the keyboard as per instructions on the bottom half of the displayed text.

Some areas that could be developed further than I have here:

* the cash balance inside the machine is just a decimal amount, does not reflect the actual coins that were dropped in; a real world machine would have to deal with dispensing specific coins as available, for change returning

* no responses are given when the user tries to select a SOLD OUT product or tries to select when not enough money has been inserted; this is perhaps accurate to many older vending machines but not newer ones

* no display is made of the total cash balance inside the machine, though it's a factor in whether or not exact change is required for payment

* there is so far no concern for the user's own account: keeping track of initial ability to pay or adding change returned back to the account

Building the Application:

Application source files are at https://github.com/beegeary/vending. 

Download project and unzip. Under your download folder, the solution file will be in \vending-master\VendingConsole\. Use your preferred build tool to download dependencies and build. With MSBuild for example, command will look like:

msbuild.exe <path>\vending-master\VendingConsole\vendingconsole.sln /p:Configuration=Debug /p:Platform="Any CPU"

...with the resulting application file at <path>\vending-master\VendingConsole\VendingTests\bin\Release\VendingConsole.exe

Tests can be run in Visual Studio, Test Explorer, or if you prefer to run tests (vendingtests.dll) from command line, vstest.console.exe can be executed like this:

vstest.console.exe "<path>\vending-master\VendingConsole\VendingTests\bin\Debug\vendingtests.dll" /UseVsixExtensions:true
