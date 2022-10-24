using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustTestAssignment.PageObject
{
    public class BasePage
    {
        IWebDriver _driver;
        protected Header pageHeader;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            pageHeader = new Header(driver);
        }

        public void NavigateToRegisterPage()
        {
            pageHeader.NavigateToRegisterPage();
        }
    }
}
