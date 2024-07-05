using Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace UnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestKeyStrokesCounter()
    {
        var sendEmail = CreateDummy();
        var sendEmailPresenter = new SendEmailPresenter(sendEmail);

        for (int i = 0; i < 10; i++)
        {
            sendEmail.KeyDownAction();
        }

        Assert.IsTrue(sendEmail.KeyStrokes > 0, "Key Strokes did not register");
        Assert.IsTrue(sendEmail.Stopwatch.IsRunning, "Stop watch should have started");
    }

    [TestMethod]
    public void TestSendButtonDisabledWhenNoBoxFilled()
    {
        var sendEmail = CreateDummy();
        var sendEmailPresenter = new SendEmailPresenter(sendEmail);

        sendEmail.TextChangedAction();

        Assert.IsTrue(!sendEmail.IsButtonEnabled, "Send Button should be disabled");
    }

    [TestMethod]
    public void TestSendButtonDisabledWhenOneBoxFilled()
    {
        var sendEmail = CreateDummy();
        var sendEmailPresenter = new SendEmailPresenter(sendEmail);

        sendEmail.ToTextBox = "email";
        sendEmail.TextChangedAction();

        Assert.IsTrue(!sendEmail.IsButtonEnabled, "Send Button should be disabled");
    }

    [TestMethod]
    public void TestSendButtonDisabledWhenTwoBoxFilled()
    {
        var sendEmail = CreateDummy();
        var sendEmailPresenter = new SendEmailPresenter(sendEmail);

        sendEmail.ToTextBox = "email";
        sendEmail.SubjectTextBox = "subject";
        sendEmail.TextChangedAction();

        Assert.IsTrue(!sendEmail.IsButtonEnabled, "Send Button should be disabled");
    }

    [TestMethod]
    public void TestSendButtonEnabledWhenAllBoxFilled()
    {
        var sendEmail = CreateDummy();
        var sendEmailPresenter = new SendEmailPresenter(sendEmail);

        sendEmail.ToTextBox = "email";
        sendEmail.SubjectTextBox = "subject";
        sendEmail.BodyTextBox = "body";
        sendEmail.TextChangedAction();

        Assert.IsTrue(sendEmail.IsButtonEnabled, "Send Button should be enabled");
    }

    [TestMethod]
    public void TestSendButtonWithAnger()
    {
        var sendEmail = CreateDummy();
        var sendEmailPresenter = new SendEmailPresenter(sendEmail);

        for (int i = 0; i < 200; i++)
        {
            sendEmail.KeyDownAction();
        }

        sendEmail.Stopwatch.StartOffset = TimeSpan.FromSeconds(5);

        sendEmail.ToTextBox = "email";
        sendEmail.SubjectTextBox = "Subject";
        sendEmail.BodyTextBox = "Body";

        sendEmail.SendButtonAction();

        Assert.IsTrue(sendEmail.AngerTimer.Enabled, "Anger Timer Should be enabled");
        Assert.IsTrue(!sendEmail.IsButtonEnabled, "Send Button should be disabled");
        Assert.AreEqual(sendEmail.ShowMessage, "You cannot send the email at this time, try again later.", "Message should display 'You cannot send the email at this time, try again later.'");
    }

    [TestMethod]
    public void TestSendButtonWithoutAnger()
    {
        var sendEmail = CreateDummy();
        var sendEmailPresenter = new SendEmailPresenter(sendEmail);

        for (int i = 0; i < 10; i++)
        {
            sendEmail.KeyDownAction();
        }

        sendEmail.Stopwatch.StartOffset = TimeSpan.FromSeconds(10);

        sendEmail.ToTextBox = "email";
        sendEmail.SubjectTextBox = "Subject";
        sendEmail.BodyTextBox = "Body";

        sendEmail.SendButtonAction();

        Assert.IsTrue(!sendEmail.AngerTimer.Enabled, "Anger Timer Should be disabled");
        Assert.AreEqual(sendEmail.ShowMessage, "Sent!", "Message Should display Sent!");
    }

    private DummySendEmail CreateDummy(TimeSpan timeSpan)
    =>
      new DummySendEmail()
      {
          Stopwatch = new CustomStopwatch(timeSpan),
          AngerTimer = new System.Timers.Timer(10000)
      };

    private DummySendEmail CreateDummy()
    =>
      new DummySendEmail()
      {
          Stopwatch = new CustomStopwatch(),
          AngerTimer = new System.Timers.Timer(10000)
      };
}
