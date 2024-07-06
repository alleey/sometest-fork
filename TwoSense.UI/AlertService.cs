namespace TwoSense.UI;

public class AlertService : IAlertService {

    public void ShowSuccess(string message) {
        MessageBox.Show(message);
    }

    public void ShowError(string message) {
        MessageBox.Show(message);
    }
}