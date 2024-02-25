using Moq;
using Weather.Common.Constant;
using Weather.Domain.Navigation;
using Weather.Services;

namespace Weather.Tests.Services
{
    [TestFixture]
    public class ApplicationInitializerTests
    {
        private Mock<INavigationService> _navigationServiceMock;


        [SetUp]
        public void SetUp()
        {
            _navigationServiceMock = new Mock<INavigationService>();
        }
        private ApplicationInitializer CreateInitializer()
        {
            return new ApplicationInitializer(_navigationServiceMock.Object);
        }

        [TestCase(nameof(ViewNames.MainPage))]
        public void StartApplication_ShouldNavigateOnTheCorrectPage_BasedOnAppSettings(
            string expectedViewName)
        {
            var appInitializer = CreateInitializer();

            appInitializer.StartApplication();

            _navigationServiceMock.Verify(m => m.PushAsync(expectedViewName));
        }
    }
}

