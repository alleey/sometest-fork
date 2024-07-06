namespace TwoSense.UI;
partial class EmailForm : Form
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.ToLabel = new System.Windows.Forms.Label();
        this.SubjectLabel = new System.Windows.Forms.Label();
        this.ToTextBox = new System.Windows.Forms.TextBox();
        this.SubjectTextBox = new System.Windows.Forms.TextBox();
        this.SendButton = new System.Windows.Forms.Button();
        this.BodyTextBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        //
        // ToLabel
        //
        this.ToLabel.AutoSize = true;
        this.ToLabel.Location = new System.Drawing.Point(30, 30);
        this.ToLabel.Name = "ToLabel";
        this.ToLabel.Size = new System.Drawing.Size(22, 15);
        this.ToLabel.TabIndex = 0;
        this.ToLabel.Text = "To:";
        //
        // SubjectLabel
        //
        this.SubjectLabel.AutoSize = true;
        this.SubjectLabel.Location = new System.Drawing.Point(30, 60);
        this.SubjectLabel.Name = "SubjectLabel";
        this.SubjectLabel.Size = new System.Drawing.Size(49, 15);
        this.SubjectLabel.TabIndex = 1;
        this.SubjectLabel.Text = "Subject:";
        //
        // ToTextBox
        //
        this.ToTextBox.Location = new System.Drawing.Point(88, 27);
        this.ToTextBox.Name = "ToTextBox";
        this.ToTextBox.Size = new System.Drawing.Size(601, 23);
        this.ToTextBox.TabIndex = 2;
        //
        // SubjectTextBox
        //
        this.SubjectTextBox.Location = new System.Drawing.Point(88, 56);
        this.SubjectTextBox.Name = "SubjectTextBox";
        this.SubjectTextBox.Size = new System.Drawing.Size(601, 23);
        this.SubjectTextBox.TabIndex = 3;
        //
        // SendButton
        //
        this.SendButton.Enabled = false;
        this.SendButton.Location = new System.Drawing.Point(695, 26);
        this.SendButton.Name = "SendButton";
        this.SendButton.Size = new System.Drawing.Size(93, 53);
        this.SendButton.TabIndex = 4;
        this.SendButton.Text = "Send";
        this.SendButton.UseVisualStyleBackColor = true;
        //
        // BodyTextBox
        //
        this.BodyTextBox.Location = new System.Drawing.Point(88, 85);
        this.BodyTextBox.Multiline = true;
        this.BodyTextBox.Name = "BodyTextBox";
        this.BodyTextBox.Size = new System.Drawing.Size(700, 353);
        this.BodyTextBox.TabIndex = 5;
        //
        // SendEmail
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.BodyTextBox);
        this.Controls.Add(this.SendButton);
        this.Controls.Add(this.SubjectTextBox);
        this.Controls.Add(this.ToTextBox);
        this.Controls.Add(this.SubjectLabel);
        this.Controls.Add(this.ToLabel);
        this.KeyPreview = true;
        this.Name = "SendEmail";
        this.Text = "Send Email";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private Label ToLabel;
    private Label SubjectLabel;
    private TextBox ToTextBox;
    private TextBox SubjectTextBox;
    private Button SendButton;
    private TextBox BodyTextBox;

    #endregion
}
