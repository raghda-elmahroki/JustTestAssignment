using JustTestAssignment.Configuration;
using OpenQA.Selenium;
using System;
using FluentAssertions;
using TechTalk.SpecFlow;
using JustTestAssignment.PageObject;

namespace JustTestAssignment.Steps
{
    [Binding]
    public sealed class RegistrationStepDefinition
    {

        private readonly IWebDriver _driver;
        private readonly ConfigReader _configReader;
        private HomePage homePage;
        private RegisterPage registerPage;
        

        public RegistrationStepDefinition(IWebDriver driver ,ConfigReader configReader )
        {
            this._driver = driver;
            this._configReader = configReader;
            homePage = new HomePage(driver);
            registerPage = new RegisterPage(driver);
        }

        
        [Given(@"User is on Home Page")]
        public void GivenUserIsOnHomePage()
        {
            _driver.Navigate().GoToUrl(_configReader.GetRegisterURL());
        }

        [Given(@"User navigates to Register Page")]
        public void UserNavigatesToRegisterPage()
        {
            homePage.NavigateToRegisterPage();
                
        }


        [When(@"User fills registration fields ""(.*)"",""(.*)"",""(.*)"",""(.*)"" and ""(.*)""")]
        public void WhenUserFillsRegistrationFields(string login, string firstName, string lastName, string password, string confirmPassword)
        {
            registerPage.FillFields(login, firstName, lastName, password, confirmPassword);
            
        }

        [When(@"User fills registration fields with invalid passwords ""(.*)"",""(.*)"",""(.*)"",(.*) and (.*)")]
        public void WhenUserFillsRegistrationFieldsWithInvalidPasswords(string login, string firstName, string lastName, string password, string confirmPassword)
        {
            registerPage.FillFields(login, firstName, lastName, password, confirmPassword);
        }

        [When(@"click Register Button")]
        public void WhenClickRegisterButton()
        {
            registerPage.ClickRegister();
        }

        [Then(@"successfull registration message is displayed")]
        public void ThenSuccessfullRegistrationMessageIsDisplayed()
        {
            registerPage.VerifySuccessMessageIsDisplayed();
            
        }

        [Then(@"Login used before error message is displayed")]
        public void ThenLoginUsedBeforeErrorMessageIsDisplayed()
        {
            registerPage.VerifyLoginExistsErrorMessageIsDisplayed();
        }


        [Then(@"error message is displayed password unaccpetable")]
        public void ThenErrorMessageIsDisplayedPasswordUnaccpetable()
        {
            registerPage.VerifyPasswordDoesNotConfirmWithPolicyErrorIsDisplayed();
        }


    }
}
