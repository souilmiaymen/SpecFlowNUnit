using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowNUnitDemo.Pages
{
    public class LoginPage
    {


        private IWebDriver _driver;
        public LoginPage (IWebDriver webDriver)
        {
            _driver=webDriver;
        } 


        public IWebElement lnkLogin => _driver.FindElement(By.LinkText("Login"));
        public IWebElement txtUserName => _driver.FindElement(By.Name("UserName"));
        public IWebElement txtPassword => _driver.FindElement(By.Name("Password"));
        public IWebElement btnLogin => _driver.FindElement(By.CssSelector(".btn-default"));
        public IWebElement lnkEmployeeDetails => _driver.FindElement(By.LinkText("Employee Details"));
        public IWebElement InvalidLoginTxt => _driver.FindElement(By.XPath("//li[contains(text(),'Invalid login attempt.')]"));


        public void ClickLogin () => lnkLogin.Click();

        public void login(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        public void ClickLoginButton() => btnLogin.Submit();

        public bool IsEmplyeeDetailsExist () => lnkEmployeeDetails.Displayed;

        public bool IsInvalidLoginTextExist () => InvalidLoginTxt.Displayed;

    }
}
