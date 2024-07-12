using NUnit.Framework;
using Moq;
using TwoSense.Core;

namespace TwoSense.Tests
{
    [TestFixture]
    public class TypingSpeedEmailValidatorTests
    {
        private Mock<ITypingSpeedObserver> _speedObserverMock;
        private TypingSpeedEmailValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _speedObserverMock = new Mock<ITypingSpeedObserver>();
            _validator = new TypingSpeedEmailValidator(_speedObserverMock.Object);
        }

        [Test]
        public void Validate_ShouldReturnSuccess_WhenSpeedIsBelowThreshold()
        {
            // Arrange
            var message = new EmailMessage("to", "message");
            _speedObserverMock.SetupGet(obs => obs.Speed).Returns(300);

            // Act
            var result = _validator.Validate(message);

            // Assert
            Assert.IsFalse(result.HasErrors);
            Assert.IsEmpty(result.Messages);
        }

        [Test]
        public void Validate_ShouldReturnFailed_WhenSpeedExceedsThreshold()
        {
            // Arrange
            var message = new EmailMessage("to", "message");
            _speedObserverMock.SetupGet(obs => obs.Speed).Returns(450);

            // Act
            var result = _validator.Validate(message);

            // Assert
            Assert.IsTrue(result.HasErrors);
            Assert.Contains("Typing speed exceeds 400 keys per minute. Potential anger detected.", result.Messages);
        }
    }
}
