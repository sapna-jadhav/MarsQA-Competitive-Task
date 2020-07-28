using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using AutoItX3Lib;
using System.Threading;
using System.IO;

namespace MarsFramework.Pages
{
      class ShareSkill
    {
		
        public ShareSkill()
        {

			PageFactory.InitElements(GlobalDefinitions.driver, this);

		}

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[@class='ReactTags__tags']/div[@class='ReactTags__selected']/div[@class='ReactTags__tagInput']/input[1]")]
        private IWebElement TxtTags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//div[6]//div[2]//div[1]//div[2]//div[1]//input[1]")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }
		
		//Click on Upload Work Sample
		[FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
		private IWebElement WorkSample { get; set; }

		//Click on Active/Hidden option
		[FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

		public void EnterShareSkill()
		{
			GlobalDefinitions.Wait();
			ShareSkillButton.Click();
			//Checking the right page
			Assert.AreEqual("ServiceListing", GlobalDefinitions.driver.Title);
			Base.test = Base.extent.StartTest("On Share Skill page");
			//Populate the Excel Sheet
			Global.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
				
				Title.SendKeys(ExcelLib.ReadData(2, "Title"));
				GenericMethods.CheckLength(4, 100, ExcelLib.ReadData(2, "Title"), "Title");
				Description.SendKeys(ExcelLib.ReadData(2, "Description"));
				GenericMethods.CheckLength(4, 600, ExcelLib.ReadData(2, "Description"), "Description");
				CategoryDropDown.SendKeys(ExcelLib.ReadData(2, "Category"));
				SubCategoryDropDown.SendKeys(ExcelLib.ReadData(2, "SubCategory"));

				TxtTags.SendKeys(ExcelLib.ReadData(2, "Tags"));
				TxtTags.SendKeys(Keys.Enter);
				IWebElement ServiceTypeOptions = GlobalDefinitions.driver.FindElement(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));
				ServiceTypeOptions.Click();

				IWebElement LocationTypeOption = GlobalDefinitions.driver.FindElement(By.XPath("//div[6]//div[2]//div[1]//div[1]//div[1]//input[1]"));
				LocationTypeOption.Click();
				
				StartDateDropDown.SendKeys(ExcelLib.ReadData(2, "Startdate"));
				EndDateDropDown.SendKeys(ExcelLib.ReadData(2, "Enddate"));
				for (int i = 2; i < 9; i++)
				{
				

					for (int j = 2; j < 9; j++)
					{
						IWebElement StartTime = GlobalDefinitions.driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input"));
						IWebElement EndTime = GlobalDefinitions.driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input"));
						if (i == 2 && j == 2)
						{
							GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(@class,'twelve wide column')]//div[2]//div[1]//div[1]//input[1]")).Click();
							StartTime.SendKeys("0230PM");
							StartTime.SendKeys(Keys.Tab);
							EndTime.SendKeys("3052PM");
						}
						if (i == 3 && j == 3)
						{
							GlobalDefinitions.driver.FindElement(By.XPath("//div[3]//div[1]//div[1]//input[1]")).Click();
							StartTime.SendKeys("0530PM");
							EndTime.SendKeys("0856PM");
						}

					}
				}

				IWebElement credit = GlobalDefinitions.driver.FindElement(By.XPath("//div[8]//div[2]//div[1]//div[2]//div[1]//input[1]"));

				//Checking if the radio is selected or not
				if (!SkillTradeOption.Selected)
				{
					SkillTradeOption.Click();

				}
				Boolean status = GlobalDefinitions.driver.FindElement(By.XPath("//input[@type='radio']")).Selected;

				if (status)
				{
					Console.WriteLine("Checkbox is checked");
				}
				else
				{
					Console.WriteLine("Checkbox is unchecked");
				}
				
				SkillExchange.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
				SkillExchange.SendKeys(Keys.Enter);
			//File Upload using AutoIt
				WorkSample.Click();

				AutoItX3 autoIt = new AutoItX3();

				autoIt.WinWait("Open", "File Upload", 1);

				autoIt.WinActivate("Open", "File Upload");


				autoIt.ControlFocus("Open", "File Upload", "[CLASS:Edit; INSTANCE:1]");

				autoIt.Send(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")) + "\\Test.txt");
			
				autoIt.Send("{ENTER}");
				autoIt.Sleep(1000);


			IWebElement ActiveOption = GlobalDefinitions.driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));
			ActiveOption.Click();
			GlobalDefinitions.Wait();
			Save.Click();
			GlobalDefinitions.Wait();
			
			Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skills Added Successfully");
				string searchInput1 = GlobalDefinitions.driver.FindElement(By.XPath("//tbody//tr[1]//td[2]")).Text;
				Assert.AreEqual(searchInput1, "Programming & Tech");
				string searchInput2 = GlobalDefinitions.driver.FindElement(By.XPath("//tbody//tr[1]//td[3]")).Text;
				Assert.AreEqual(searchInput2, "Selenium");
				string searchInput3 = GlobalDefinitions.driver.FindElement(By.XPath("//tbody//tr[1]//td[5]")).Text;
				Assert.AreEqual(searchInput3, "Hourly");
			}
		
		//internal void EditShareSkill()
		//{

		//}
	}
}
