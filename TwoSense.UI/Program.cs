using Microsoft.Extensions.DependencyInjection;
using TwoSense.Core;

namespace TwoSense.UI;
public static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var mainForm = serviceProvider.GetRequiredService<EmailForm>();
            Application.Run(mainForm);
        }
    }

    static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IEmailViewModel, EmailViewModel>();

        services.AddSingleton<ITypingSpeedObserver, MaxTypingSpeedPerMinuteObserver>();
        services.AddSingleton<IEmailValidator, TypingSpeedEmailValidator>();
        services.AddSingleton<ITimerService, DefaultTimerService>();
        services.AddSingleton<IAlertService, AlertService>();

        // Register main form
        services.AddTransient<EmailForm>();
    }}
