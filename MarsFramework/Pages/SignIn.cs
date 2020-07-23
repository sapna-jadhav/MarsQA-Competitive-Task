using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
     class SignIn
    {
        public SignIn()
        {

			PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
		}

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[@class='item']")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public  void LoginSteps()
        {
			//Populate the Excel Sheet
			Global.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
			GlobalDefinitions.NavigateUrl();
			//Click on SignIn Button
			SignIntab.Click();
			//Read username and password from excel
			Email.SendKeys(ExcelLib.ReadData(2, "Username"));
			Password.SendKeys(ExcelLib.ReadData(2, "Password"));
			//Click on Login Button
			LoginBtn.Click();

        }
    }
}