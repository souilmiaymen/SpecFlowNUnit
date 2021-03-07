using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowNUnitDemo.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowNUnitDemo.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        LoginPage loginPage;
        private DriverHelper _driverHelper;
        public LoginSteps (DriverHelper driverHelper)
        {
            _driverHelper=driverHelper;
            loginPage = new LoginPage(_driverHelper.Driver);
        }
        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication ()
        {
            _driverHelper.Driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        }

        [Given(@"I click login link")]
        public void GivenIClickLoginLink ()
        {
            loginPage.ClickLogin();
        }

        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails (Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.login(data.UserName, data.Password);
        }

        [Given(@"I click login button")]
        public void GivenIClickLoginButton ()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should see Employee details link")]
        public void ThenIShouldSeeEmployeeDetailsLink ()
        {
            Assert.That(loginPage.IsEmplyeeDetailsExist(), Is.True);
        }

        [Then(@"I should see Login Invalid Text")]
        public void ThenIshouldseeLoginInvalidText ()
        {
            Assert.That(loginPage.IsInvalidLoginTextExist(), Is.True);
        }

    }
}
