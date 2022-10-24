using BoDi;
using JustTestAssignment.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;



namespace JustTestAssignment.Hooks
{
    [Binding]
    public sealed class WebHooks
    {
        private ConfigReader _configReader = new ConfigReader();
        private string _tempBrowser = "chrome";

        private IObjectContainer container;
        public WebHooks(IObjectContainer container)
        {
            this.container = container;
        }
        

        [BeforeScenario]
        public void BeforeScenario()
        {
           // string registerURL=_configReader.GetRegisterURL();
            container.RegisterInstanceAs<ConfigReader>(_configReader);
            IWebDriver driver;
            switch (_tempBrowser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
            container.RegisterInstanceAs<IWebDriver>(driver) ;

        }



        [AfterScenario]
        public void AfterScenario()
        {
            var driver = container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
