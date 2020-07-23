using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using System;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void Test()
            {
				//Inititalize();
			
				//SignIn Login = new SignIn();
				//Login.LoginSteps();
				ShareSkill obj = new ShareSkill();
				obj.EnterShareSkill();
				ManageListings List= new ManageListings();
				List.Listings();
				ManageListings delete = new ManageListings();
				delete.DeleteListing();
				
		

			}



        }
    }
}