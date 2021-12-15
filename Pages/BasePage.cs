using Atata;
using OpenQA.Selenium.Support.UI;
using System;
using static Atata.TriggerEvents;
namespace IFlow.Testing.Pages
{
    [Screenshot(AfterAnyAction)]
    public abstract class BasePage<TOwner> : Page<TOwner>
        where TOwner : BasePage<TOwner>
    {
        protected static OpenQA.Selenium.Remote.RemoteWebDriver driver = AtataContext.Current.Driver;
        protected WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }
}