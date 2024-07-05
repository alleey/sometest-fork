using Abstractions;
using System.Diagnostics;

namespace TwoSense.Test;
public partial class SendEmail : Form, ISendEmail
{

    public SendEmail()
    {
        InitializeComponent();
        Presenter = new SendEmailPresenter(this);
        Stopwatch = new CustomStopwatch();
        AngerTimer = new System.Timers.Timer(INTEVAL);
    }

    #region Private Properties
    private SendEmailPresenter Presenter;
    private CustomStopwatch Stopwatch;
    private System.Timers.Timer AngerTimer;
    private int KeyStrokes = 0;
    private string ShowMessage;
    private const int INTEVAL = 60000;
    #endregion

    #region Public Properties
    string ISendEmail.ToTextBox { get => this.ToTextBox.Text; set => this.ToTextBox.Text = value; }
    string ISendEmail.SubjectTextBox { get => this.SubjectTextBox.Text; set => this.SubjectTextBox.Text = value; }
    string ISendEmail.BodyTextBox { get => this.BodyTextBox.Text; set => this.BodyTextBox.Text = value; }
    bool ISendEmail.IsButtonEnabled { get => this.SendButton.Enabled; set {
            if (this.SendButton.InvokeRequired)
                this.SendButton.Invoke(new MethodInvoker(delegate { this.SendButton.Enabled = value; }));
            else
                this.SendButton.Enabled = value;
        } }
    string ISendEmail.ShowMessage { get => this.ShowMessage; set {
            this.ShowMessage = value;
            MessageBox.Show(value); 
        } }
    CustomStopwatch ISendEmail.Stopwatch { get => this.Stopwatch; set => this.Stopwatch = value; }
    int ISendEmail.KeyStrokes { get => this.KeyStrokes; set => this.KeyStrokes = value; }
    System.Timers.Timer ISendEmail.AngerTimer { get => this.AngerTimer; set => this.AngerTimer = value; }

    public event EventHandler? SendButtonEvent;
    public event EventHandler? KeyDownEvent;
    public event EventHandler? TextChangedEvent;
    #endregion

    #region Events
    private void SendButton_Click(object sender, EventArgs e)
    {
        SendButtonEvent?.Invoke(this, EventArgs.Empty);
    }

    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        KeyDownEvent?.Invoke(this, KeyEventArgs.Empty);
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        TextChangedEvent?.Invoke(this, KeyEventArgs.Empty);
    }
    #endregion
}
