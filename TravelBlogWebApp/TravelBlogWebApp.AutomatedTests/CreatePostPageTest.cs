using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TravelBlogWebApp.AutomatedTests
{
    [TestClass]
    public class CreatePostPageTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // Initialize the ChromeDriver
            driver = new ChromeDriver();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Quit the driver and close the browser
            driver.Quit();
        }

        [TestMethod]
        public void NonAdmin_CannotAccessCreatePostPage()
        {
            // Arrange
            var baseUrl = "https://localhost:7143"; // Update with the base URL of your application
            var loginUrl = $"{baseUrl}/Identity/Account/Login"; // Update with the login URL
            var nonAdminEmail = "user@user.com";
            var nonAdminPassword = "Parola123!";

            // Login as non-admin user
            driver.Navigate().GoToUrl(loginUrl);
            driver.FindElement(By.Id("Input_Email")).SendKeys(nonAdminEmail);
            driver.FindElement(By.Id("Input_Password")).SendKeys(nonAdminPassword);
            driver.FindElement(By.Id("login-submit")).Click();

          
            // Attempt to access the Post/Create page
            driver.Navigate().GoToUrl($"{baseUrl}/Posts/Create");

            // Assert
            // You can assert that the user is redirected to a different page
            Thread.Sleep(2000);
            Assert.IsFalse(driver.Url.Contains("/Posts/Create"));

            // Or you can assert that an error message indicating unauthorized access is displayed
            var pageTitle = driver.FindElement(By.CssSelector("h1.text-danger")).Text;
            var errorMessage = driver.FindElement(By.CssSelector("p.text-danger")).Text;

            Assert.AreEqual("Access denied", pageTitle);
            Assert.AreEqual("You do not have access to this resource.", errorMessage);
        }
        [TestMethod]
        public void CanCreatePost()
        {
            // Arrange
            var baseUrl = "https://localhost:7143"; // Update with the URL of your application
            var createPostUrl = $"{baseUrl}/Post/Create"; // Update with the URL of the create post page
            var title = "New Post";
            var dateTime = "2023-06-04";
            var likesNumber = "10";
            var blogId = "1"; // Update with the desired blog ID
            var loginUrl = $"{baseUrl}/Identity/Account/Login"; // Update with the login URL
            var email = "admin@admin.com";
            var password = "Parola123!";

            // Login as Administrator
            driver.Navigate().GoToUrl(loginUrl);
            driver.FindElement(By.Id("Input_Email")).SendKeys(email);
            driver.FindElement(By.Id("Input_Password")).SendKeys(password);
            driver.FindElement(By.Id("login-submit")).Click();


            // Act
            driver.Navigate().GoToUrl(createPostUrl);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // Fill in the form fields
            driver.FindElement(By.Id("Title")).SendKeys(title);
            driver.FindElement(By.Id("DateTime")).SendKeys(dateTime);
            driver.FindElement(By.Id("LikesNumber")).SendKeys(likesNumber);

            // Select the BlogId from the dropdown
            var blogIdDropdown = driver.FindElement(By.Id("BlogId"));
            var option = blogIdDropdown.FindElements(By.TagName("option"))[int.Parse(blogId)];
            option.Click();

            // Submit the form
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // Assert
            // Verify if the page redirects to the Post Index page or performs the desired action after creating a post
            Assert.IsTrue(driver.Url.Contains($"{baseUrl}/Post/Index"));

            // Perform additional assertions or actions as needed
        }
    }
}
