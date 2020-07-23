using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Global
{
	class GenericMethods
	{
		public static void CheckLength(int minLength, int maxLength, string inputText, string fieldName)
		{
			try
			{
				Assert.LessOrEqual(inputText.Length, maxLength);
				Assert.GreaterOrEqual(inputText.Length, minLength);
				//CommonFeatures.test.Log(RelevantCodes.ExtentReports.LogStatus.Skip, passMessage);
			}
			catch (Exception ex)
			{
				//CommonFeatures.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, failMessage);
				Console.WriteLine("exception message:" + ex.Message + "Inner exception:" + ex.InnerException);
				Console.WriteLine("The field must be between " + minLength + " - " + maxLength + " alphanumeric characters.");
				Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, fieldName + " must be between " + minLength + " - " + maxLength + " alphanumeric characters.");
				Base.TearDown();
			}

		}
		
		public static void ValidNumeric(string inputField, string fieldName)
		{
			int myInteger;

			bool IsNumeric = int.TryParse(inputField, out myInteger);

			if (IsNumeric == true)
			{
				//ignore
			}
			else
			{
				Console.WriteLine(" The " + fieldName + " should be numeric ");
				Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, " The " + fieldName + " should be numeric ");
				Base.TearDown();
			}
		}

		// page title validation
		public static void ValidateTitle(string expectedTitle, string actualTitle, string successMessage, string failMessage)
		{
			try
			{
				Assert.AreEqual(expectedTitle, actualTitle);
				Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, successMessage);
			}
			catch (Exception)
			{
				Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, failMessage);
			}

		}
		
	}
}

	


