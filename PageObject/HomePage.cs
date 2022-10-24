using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustTestAssignment.PageObject
{
    public class HomePage :BasePage
    {

        public HomePage(IWebDriver driver):base(driver)
        {
          
        }

        public void NavigateToRegisterPage()
        {
            pageHeader.NavigateToRegisterPage();
        }
    }
}
