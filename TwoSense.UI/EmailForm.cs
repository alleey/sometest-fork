using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace TwoSense.UI;

public partial class EmailForm : Form
{
    private readonly IEmailViewModel _viewModel;
    private readonly IAlertService _alertService;

    public EmailForm(IEmailViewModel viewModel, IAlertService alertService)
    {
        _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        _alertService = alertService ?? throw new ArgumentNullException(nameof(alertService));

        InitializeComponent();
        InitializeDataBindings();

        _viewModel.PropertyChanged += ViewModel_PropertyChanged;
    }

    private void InitializeDataBindings()
    {
        ToTextBox.DataBindings.Add("Text", _viewModel, "To", false, DataSourceUpdateMode.OnPropertyChanged);
        SubjectTextBox.DataBindings.Add("Text", _viewModel, "Subject", false, DataSourceUpdateMode.OnPropertyChanged);
        BodyTextBox.DataBindings.Add("Text", _viewModel, "Message", false, DataSourceUpdateMode.OnPropertyChanged);
        SendButton.DataBindings.Add("Enabled", _viewModel, "IsSendButtonEnabled", false, DataSourceUpdateMode.OnPropertyChanged);

        // Attach event handlers
        SendButton.Click += (sender, e) => _viewModel.OnSendEmailClicked();
        BodyTextBox.TextChanged += (sender, e) => _viewModel.OnKeyPressed();
    }


    private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(EmailViewModel.ValidationResult))
        {
            if (_viewModel.ValidationResult.HasErrors)
                _alertService.ShowError(string.Join("\n", _viewModel.ValidationResult.Messages));
            else
                _alertService.ShowSuccess("Sent!");
            _viewModel.Reset();
        }
    }
}
