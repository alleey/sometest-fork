namespace TwoSense.UI;

public interface IAlertService {
    void ShowSuccess(string message);
    void ShowError(string message);
}
