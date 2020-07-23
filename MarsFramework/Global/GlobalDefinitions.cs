using Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace MarsFramework.Global
{
    class GlobalDefinitions
    {
        //Initialise the browser
        public static IWebDriver driver { get; set; }

		//public void Initialize()
		//{
		//	//Defining the browser
		//	driver = new ChromeDriver();
		//	Wait();

		//	//Maximise the window
		//	driver.Manage().Window.Maximize();
		//}
		#region WaitforElement 

		public static void Wait()
        {
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

		}
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
#pragma warning disable CS0618 // Type or member is obsolete
			return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
#pragma warning restore CS0618 // Type or member is obsolete
		}
		#endregion
		public static string BaseUrl
		{
			get { return ConstantHelpers.Url; }
		}
		public static void NavigateUrl()
		{
			driver.Navigate().GoToUrl(BaseUrl);
		}

		

        #region screenshots
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (Base.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }
        #endregion
    }
}
