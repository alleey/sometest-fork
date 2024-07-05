namespace TwoSense.Test;
public static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new SendEmail());
    }
}
