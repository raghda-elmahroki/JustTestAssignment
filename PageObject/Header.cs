using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustTestAssignment.PageObject
{
    public class Header
    {
        IWebDriver _driver;
        private By registerButton = By.XPath("//a[text()='Register']");
        private By loginButton = By.XPath("//button[text()='Login']");
        private By loginInput = By.XPath("//input[@name='login']");
        private By passwordInput = By.XPath("//input[@name='password']");
        

        public Header(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToRegisterPage()
        {
            _driver.FindElement(registerButton).Click();
        }
    }
}
