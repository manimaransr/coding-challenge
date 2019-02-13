# Coding Challenge 

## Technologies used for development:
ASP.NET Core 2.1 for web api

In-memory Entity Framework Core as a data source

React - UI & Component

Redux - State & Store

MediaQuery - responsive design

XUnit, Moq - Unit testing

enzyme, JSDOM for React UI- unit test case

Global level error handling using asp.net core

## Overview

This is a loan management application. We would be greateful if you create a single page application (SPA) with a list of loans for us.

We know you are busy, and we don't expect you to finish the whole exercise if you don't have enough time, You can submit 
what you have done and tell us what you would have done differently if you had more time, although 
the solution should work and provide the basic functionality. Surely we would appreciate if you could finish the whole exercise.

## Functional Requirements.

* The application starts with the landing page, where the user can see a list of loans (refer to [loan-application-landing-page](/images/1.loan-application-landing-page.png))
* By selecting each loan (ticking the Top Up checkbox) the details of the loan will be expanded as a card, and Payout/Carryover amount for each loan would be shown at the top of the page (refer to [selecting-individual-loans](/images/2.selecting-individual-loans.png))
* As you can see each loan has 4 elements retrieved from the web api, 
    - Balance
    - Interest
    - Early Payment Fee
    - And the Payout/Carryover which is the sum of the above numbers
* User could also have multiple loans retrieved from the web api (refer to [retrieving-multiple-loans](/images/3.retrieving-multiple-loans.png))
* Again selecting each loan (ticking the top up button), would show Payout/Carryover amount at the top (refer to [selecting-individual-loans-when-there-is-multiple-loans](/images/4.selecting-individual-loans-when-there-is-multiple-loans.png))
* Ticking the top up checkbox for multiple loans, would fill the sum of Payout/Carryover amount of all selected loans in the Carryover/Payout Amount at the top of the page (refer to [selecting-multiple-loans](/images/5.selecting-multiple-loans.png))
* Display retrieved loans on the page as expandable cards as shown in the images (refer to [selecting-individual-loans](/images/2.selecting-individual-loans.png)).
* `Apply for Increased Loan Amounts` button should be enabled only when selected balance is more than `0`.
* `Apply for new Loan` button needs to be disabled when 3 or more accounts are available.


## Technical requirements.

*   Push your solution as a github repo, we'd also like to look at your commit history.
*   Push your code as you go (don't push all changes to one commit.)

## UI 

*   Use either `Angular`(`5+`), `ReactJs` or `VueJs`.
*   Should use Container Presentational Component Pattern.
*   Should use single store to maintain application state.
*   Components need to be updated when state changed.
*   Handle service errors and display on screen.
*   Create components wherever required.
*   Components should be unit testable. Unit testing a few components should be enough.
*   Responsive design.
*   You shouldn't use any style libraries.

## WebApi

*	Please create a webapi to retrieve loans.
*	You should use your own data store and don't hardcode loan accounts.
*	Loan records can be manually entered into your data store.
*	Api will be under heavy load in production hence the code should be performant.
*	It is expected to have error/exception handling mechanisms in place
*	It would be great if you use design patterns in your application
*	Components should be unit testable. Unit testing a few components should be enough.



