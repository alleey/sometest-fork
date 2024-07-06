using NUnit.Framework;
using Moq;
using System.ComponentModel;
using TwoSense.UI;
using TwoSense.Core;
using System.Windows.Forms;

namespace TwoSense.Tests
{
    [TestFixture]
    public class EmailFormTests
    {
        private Mock<IEmailViewModel> _viewModelMock;
        private Mock<IAlertService> _alertServiceMock;
        private EmailForm _emailForm;

        [SetUp]
        public void SetUp()
        {
            _viewModelMock = new Mock<IEmailViewModel>();
            _alertServiceMock = new Mock<IAlertService>();
            _emailForm = new EmailForm(_viewModelMock.Object, _alertServiceMock.Object);

            // Simulate form load
            _emailForm.Show();
        }

        [TearDown]
        public void TearDown()
        {
            _emailForm.Close();
            _emailForm.Dispose();
        }

        [Test]
        public void ViewModel_PropertyChanged_ShouldShowError_WhenValidationResultHasErrors()
        {
            // Arrange
            var validationResult = ValidationResult.Failed("Error message");
            _viewModelMock.SetupGet(vm => vm.ValidationResult).Returns(validationResult);

            // Act
            _viewModelMock.Raise(vm => vm.PropertyChanged += null, new PropertyChangedEventArgs(nameof(IEmailViewModel.ValidationResult)));

            // Assert
            _alertServiceMock.Verify(a => a.ShowError(It.Is<string>(s => s.Contains("Error message"))), Times.Once);
        }

        [Test]
        public void ViewModel_PropertyChanged_ShouldShowSuccess_WhenValidationResultHasNoErrors()
        {
            // Arrange
            var validationResult = ValidationResult.Success();
            _viewModelMock.SetupGet(vm => vm.ValidationResult).Returns(validationResult);

            // Act
            _viewModelMock.Raise(vm => vm.PropertyChanged += null, new PropertyChangedEventArgs(nameof(IEmailViewModel.ValidationResult)));

            // Assert
            _alertServiceMock.Verify(a => a.ShowSuccess("Sent!"), Times.Once);
        }
    }
}
