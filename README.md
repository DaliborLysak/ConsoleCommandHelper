# ConsoleCommandHelper
Library for helping processing usual console apps commands as help, about, etc..., through files accessed in your console app. 

Motivation
I do a lot of small console apps for geocaching and personal use and after some time not using them I usually end up reading and learning again what are app console commands. And this is because I always fail struggle to find out time to write readme or help. For that reason I write this helper.

Using:

Make refrence to ConsoleCommandHelper,

and call for example:
var argument = CommandService.Execute(args[0]);

If there is file witch match command it will be used and write to console. Otherwise command is returned.

Known commands and synonyms:

About
-File: About.txt
-Commands: ABOUT,-ABOUT,--ABOUT

Help
-File: Help.txt
-Commands: HELP,-HELP,--HELP,?,-?,--?

Test
-File: Test.txt
-Commands: TEST,-TEST,--TEST

ReadMe
-File: ReadMe.txt
-Commands: README,-README,--README

Licence: MIT

Download as NuGet from https://www.nuget.org/packages/Console.Command.Helper/1.0.0
