using DiplomaProject.UI.Framework.WebDriver;
using Microsoft.Extensions.Configuration;

namespace DiplomaProject.UI.Framework;

public static class Properties
{
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true).Build();

    public static readonly BrowserName Browser = Enum.Parse<BrowserName>(Configuration["Common:Browser"], true);
    public static readonly string OrangeHrmUrl = Configuration["Common:BaseUrl"];
    public static readonly string Login = Configuration["Common:Authorisation:Login"];
    public static readonly string Password = Configuration["Common:Authorisation:Password"];
}