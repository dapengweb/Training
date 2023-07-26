using Moq;
using NUnit;
using MobileLib;

namespace MobileTest
{
    public class Tests
    {
        private Mobile mobile =null;
        private bool actualstatus =false;
        private bool expectedstatus =false;
        private Mock<ICamera> mockedCamera =null;

        [SetUp]
        public void Setup()
        {
            mockedCamera = new Mock<ICamera>();
            //Inversion of Control(IOC)
            mobile = new Mobile(mockedCamera.Object);
        }

        [Test]
        public void testPowerOnWhenCameraOnWorksAsExpected()
        {
            //Setup
            mockedCamera.Setup(camera => camera.ON()).Returns(true);
            actualstatus =mobile.PowerOn();
            expectedstatus =true;
            Assert.AreEqual(expectedstatus, actualstatus);
            mockedCamera.Verify(camera=>camera.ON(),Times.Once());
        }

        [Test]
        public void testPowerOnWhenCameraIsNotWorkingAsExpected()
        {
            mockedCamera.Setup(camera => camera.ON()).Returns(false);
            actualstatus = mobile.PowerOn();
            expectedstatus = false;
            Assert.AreEqual(expectedstatus, actualstatus);
            mockedCamera.Verify(camera => camera.ON(), Times.Once());
        }

        [Test]
        public void testPowerOnWhenCameraHardwareIsNotResponding()
        {
            mockedCamera.Setup(camera => camera.ON()).Throws(new Exception("Camera Hardware not responding"));
            var exceptionObj = Assert.Throws<Exception>(()=>mobile.PowerOn());
            Assert.That(exceptionObj.Message, Is.EqualTo("Camera Hardware not responding"));
            //mockedCamera.Verify(camera => camera.ON()).
        }
    }
}