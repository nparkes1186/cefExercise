namespace cefTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

[TestClass]
public class TestExercise
{
    readonly string website = "https://demowf.aspnetawesome.com/";
    readonly IWebDriver driver = new ChromeDriver();

    [TestMethod]
    public void TestSteps()
    {
        //Go to the website
        driver.Navigate().GoToUrl(website);
        //Accepts the cookies
        driver.FindElement(By.Id("btnCookie")).Click();
        //Confirm the website has loaded by asserting the title is correct
        Assert.AreEqual(driver.FindElement(By.CssSelector("#maincont > h1")).Text, "ASP.net Web-Forms Awesome Controls overview:");
        //Find and select the Date picker
        driver.FindElement(By.Id("ContentPlaceHolder1_Date1")).Click();
        //Change the month
        driver.FindElement(By.CssSelector(".o-mnxt > .o-arw")).Click();
        //Select a date from the month
        driver.FindElement(By.CssSelector("tr:nth-child(4) > .o-day:nth-child(5) > div")).Click();
        //Expand the Combobox
        driver.FindElement(By.CssSelector(".o-slbtn:nth-child(1) > .o-caret")).Click();
        //Select Artichoke
        driver.FindElement(By.CssSelector("div#ContentPlaceHolder1_AllMealsCombo-dropmenu  ul > li:nth-of-type(13)")).Click();
        //Create a web element for the CheckboxList
        IWebElement CheckboxList = driver.FindElement(By.CssSelector("#maincont > div:nth-child(3) > div:nth-child(5) > div:nth-child(2) > div.awe-ajaxcheckboxlist-field.awe-field > div > ul"));
        //Create a list of all <li> elements within the CheckboxList
        IList<IWebElement> checkboxes = CheckboxList.FindElements(By.CssSelector("li"));
        //Loop through each one in turn
        foreach (IWebElement checkbox in checkboxes)
            //Condition to see if the box is checked, expressed as a Bool
            if (Convert.ToBoolean(checkbox.GetAttribute("class").Contains("o-chked") == false))
            {
                //If box is not checked, check it
                checkbox.Click();
            }
        //Confirm the correct Grid is present
        Assert.AreEqual(driver.FindElement(By.CssSelector("#maincont > div:nth-child(6) > h2")).Text, "Grid, search using parent binding ");
        //Find and click to expand the options for number of results
        driver.FindElement(By.CssSelector("#ContentPlaceHolder1_Grid1PageSize-awed > .o-cptn")).Click();
        //Select 100 results per page
        driver.FindElement(By.XPath("//li[text() = '100']")).Click();
        //Assert the 100 results per page is selected
        Assert.AreEqual(driver.FindElement(By.CssSelector("#ContentPlaceHolder1_Grid1PageSize-awed > div.o-cptn")).Text , "page size: 100");
        //Wait for 500 milliseconds to so the page can catch up
        Thread.Sleep(500);
        //Create a web element for the page numbers
        IWebElement PageNumbers = driver.FindElement(By.XPath("//*[@id=\"ContentPlaceHolder1_Grid1\"]/div[4]/div[2]"));
        //Create a list of page numbers
        IList<IWebElement> pages = PageNumbers.FindElements(By.CssSelector("button"));
        //Create an element for the last page number
        IWebElement LastPage = pages.Last();
        //Click the last page number
        LastPage.Click();

    }
}
