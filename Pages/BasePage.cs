using Atata;
using static Atata.TriggerEvents;
namespace IFlow.Testing.Pages
{
    [Screenshot(AfterAnyAction)]
    public abstract class BasePage<TOwner> : Page<TOwner>
        where TOwner : BasePage<TOwner>
    {
        protected OpenQA.Selenium.Remote.RemoteWebDriver driver = AtataContext.Current.Driver;
    }
}