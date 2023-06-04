using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TravelBlogWebApp.AutomatedTests
{
    [TestClass]
    public class PostPageTests
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
        public void Administrator_CanAccessPostPage()
        {
            // Arrange
            var baseUrl = "http://localhost:5000"; // Update with the URL of your application
            var loginUrl = $"{baseUrl}/Account/Login"; // Update with the login URL
            var username = "admin";
            var password = "password";

            // Login as Administrator
            driver.Navigate().GoToUrl(loginUrl);
            driver.FindElement(By.Id("Input_Username")).SendKeys(username);
            driver.FindElement(By.Id("Input_Password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            // Act
            driver.Navigate().GoToUrl($"{baseUrl}/Post"); // Update with the URL of the post page

            // Assert
            Assert.IsTrue(driver.Title.Contains("Post"));

            // Verify the presence of Create New button
            var createNewButton = driver.FindElement(By.LinkText("Create New"));
            Assert.IsNotNull(createNewButton);

            // Verify the presence of at least one post card
            var postCards = driver.FindElements(By.ClassName("card"));
            Assert.IsTrue(postCards.Count > 0);

            // Perform some actions
            var firstPostCard = postCards[0];
            var editButton = firstPostCard.FindElement(By.LinkText("Edit"));
            var deleteButton = firstPostCard.FindElement(By.LinkText("Delete"));
            var detailsButton = firstPostCard.FindElement(By.LinkText("Details"));

            // Perform additional assertions or actions as needed
        }
    }
}