using NUnit.Framework;
using Moq;
using TwoSense.Core;
using System;

namespace TwoSense.Tests
{
    [TestFixture]
    public class MaxTypingSpeedPerMinuteObserverTests
    {
        private Mock<ITimerService> _timerServiceMock;
        private MaxTypingSpeedPerMinuteObserver _observer;

        [SetUp]
        public void SetUp()
        {
            _timerServiceMock = new Mock<ITimerService>();
            _observer = new MaxTypingSpeedPerMinuteObserver(_timerServiceMock.Object);
        }

        [Test]
        public void Observe_ShouldIncreaseSpeed_WhenKeysAreObserved()
        {
            // Arrange
            var now = DateTime.Now;
            _timerServiceMock.SetupSequence(ts => ts.Now())
                             .Returns(now)
                             .Returns(now.AddSeconds(30))
                             .Returns(now.AddSeconds(45));

             // Act
            _observer.Observe('a');
            var speed1 = _observer.Speed;
            _observer.Observe('b');
            var speed2 = _observer.Speed;
            _observer.Observe('c');
            var speed3 = _observer.Speed;

             // Assert
            Assert.AreEqual(1, speed1);
            Assert.AreEqual(2, speed2);
            Assert.AreEqual(3, speed3);
        }

        [Test]
        public void Observe_ShouldNotIncreaseSpeed_WhenNoKeysAreObservedWithinOneMinute()
        {
            // Arrange
            var now = DateTime.Now;
            _timerServiceMock.SetupSequence(ts => ts.Now())
                             .Returns(now)
                             .Returns(now.AddMinutes(2));

             // Act
           _observer.Observe('a');
           var speed1 = _observer.Speed;
            _observer.Observe('b');
           var speed2 = _observer.Speed;

             // Assert
            Assert.AreEqual(1, speed1);
            Assert.AreEqual(1, speed2);
        }

        [Test]
        public void Reset_ShouldResetSpeed()
        {
            // Arrange
            var now = DateTime.Now;
            _timerServiceMock.SetupSequence(ts => ts.Now())
                             .Returns(now)
                             .Returns(now.AddSeconds(30))
                             .Returns(now.AddSeconds(45));

            _observer.Observe('a');
            _observer.Observe('b');
            _observer.Observe('c');

            // Act
            _observer.Reset();

            // Assert
            Assert.AreEqual(0, _observer.Speed);
        }
    }
}
