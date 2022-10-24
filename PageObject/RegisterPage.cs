using OpenQA.Selenium;
using System;
using FluentAssertions;

namespace JustTestAssignment.PageObject
{
    public class RegisterPage:BasePage
    {
        IWebDriver _driver;
        private By loginInput = By.Name("username");
        private By firstNameInput = By.Id("firstName");
        private By lastNameInput = By.XPath("//label[text()='Last Name']/following::input");
        private By passwordInput = By.XPath("//label[text()='Password']/following::input");
        private By confirmPasswordInput = By.XPath("//label[text()='Confirm Password']/following::input");
        private By registerButton = By.XPath("//button[text()='Register']");
        private By successMessage = By.XPath("//div[@class='result alert alert-success']");
        private By errorMessage = By.XPath("//div[@class='result alert alert-danger']");

        private string previousLogin = null;
        public RegisterPage(IWebDriver driver):base(driver)
        {
            _driver = driver;
        }

        public void FillFields(string login,string firstName, string lastName,string password,string confirmPassword)
        {
            if (login.Contains("random"))
            {
                Random randomNumber = new Random();
                login = "randomLoginName" + randomNumber.Next(9999);
                previousLogin = login;
            }else if (login.Contains("previous"))
            {
                login = previousLogin;
            }
            _driver.FindElement(loginInput).SendKeys(login);
            _driver.FindElement(firstNameInput).SendKeys(firstName);
            _driver.FindElement(lastNameInput).SendKeys(lastName);
            _driver.FindElement(passwordInput).SendKeys(password);
            _driver.FindElement(confirmPasswordInput).SendKeys(confirmPassword);
        }


        public void ClickRegister()
        {
            _driver.FindElement(registerButton).Click();
        }

        public void VerifySuccessMessageIsDisplayed()
        {
            string successMessageText = _driver.FindElement(successMessage).Text;
            successMessageText.Should().Contain("Registration is successful");
        }

        public void VerifyLoginExistsErrorMessageIsDisplayed()
        {
            string errorMessageText = _driver.FindElement(errorMessage).Text;
            errorMessageText.Should().Contain("User already exists");
        }

        public void VerifyPasswordDoesNotConfirmWithPolicyErrorIsDisplayed()
        {
            string errorMessageText = _driver.FindElement(errorMessage).Text;
            errorMessageText.Should().Contain("Password did not conform with policy");
            
        }
    }
}
