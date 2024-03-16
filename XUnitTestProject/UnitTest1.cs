using SampleWebApp;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            HealthCheckController controller = new HealthCheckController();
            string _sResult = controller.HealthCheckStatus();
            Assert.Equal("SUCCESS", _sResult);
        }
    }
}