Feature: Page registration
As a visitor
I want to be able to register in the website
So that I can vote for a sport car

Background:  
Given User is on Home Page


Scenario: User successfully register a new account
Given User navigates to Register Page
When User fills registration fields "random","FirstNAme","LastName","Aa123456!" and "Aa123456!"
And click Register Button
Then successfull registration message is displayed


Scenario: User is allowed to register only once
Given User navigates to Register Page
When User fills registration fields "random","FirstNAme","LastName","Aa123456!" and "Aa123456!"
And click Register Button
Then successfull registration message is displayed
When User fills registration fields "previous","FirstNAme","LastName","Aa123456!" and "Aa123456!"
And click Register Button
Then Login used before error message is displayed


Scenario Outline: User cannot register with unacceptable password
Given User navigates to Register Page
When User fills registration fields with invalid passwords "login","firstName","lastName",{password} and {password}
And click Register Button
Then error message is displayed password unaccpetable

Examples:
| password |
| abc  |
| abcdefgh  |
| 11111111  |
| abcd1234  |
| Aabcdefg  |
| Abcdefg1  |
| @bcdefg1  |


Scenario: User successfully login with a new account
Given User navigates to Register Page
When User fills registration fields "random","FirstNAme","LastName","Aa123456!" and "Aa123456!"
And click Register Button
Then successfull registration message is displayed
When User login with the new account
Then Landing page is displayed

Scenario Outline: User cannot register with unmatching password
Given User navigates to Register Page
When User fills registration fields with unmatching passwords "login","firstName","lastName",{password} and {password}
And click Register Button
Then error message is displayed password unmatching

Scenario Outline: User cannot register with blank fields
Given User navigates to Register Page
Then Register button is disabled

Scenario: User can clear registration form
Given User navigates to Register Page
When User fills registration fields "random","FirstNAme","LastName","Aa123456!" and "Aa123456!"
And click Cleat Button
Then fields are cleared