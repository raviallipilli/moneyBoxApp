# Moneybox Money Withdrawal

The solution contains a .NET core library (Moneybox.App) which is structured into the following 3 folders:

* Domain - this contains the domain models for a user and an account, and a notification service.
* Features - this contains two operations, one which is implemented (transfer money) and another which isn't (withdraw money)
* DataAccess - this contains a repository for retrieving and saving an account (and the nested user it belongs to)


## Solution and Results 

-> I spent just about a day and half , understanding the task itself took me some time.
-> Used github to upload my project.
-> Solution will compile and run any time.
-> No refactoring has been made to service and account repository.
-> Used Nunit test for testing the methods, they are written slightly in a longer way but can be done in even better and simple way, the reason being I had problem with converion of decimal to double as well as Guid to string so written seperate code for test methods.

