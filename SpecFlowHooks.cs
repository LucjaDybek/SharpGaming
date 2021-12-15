using Atata;
using TechTalk.SpecFlow;

namespace IFlow.Testing
{
    [Binding] 
    public sealed class SpecFlowHooks
    {
        [BeforeTestRun]
        public static void StetUpTestRun()
        {

            AtataContext.GlobalConfiguration
                .UseChrome()
                .WithArguments("start-maximized")
                .UseCulture("en-US")
                .UseAllNUnitFeatures()
                .ApplyJsonConfig<AtataConfig>()
                .UseBaseUrl("https://www.oddsking.com/");
          
            AtataContext.GlobalConfiguration.AutoSetUpDriverToUse();
        }

        [BeforeScenario]
        public static void SetUpScenario(ScenarioContext scenarioContext)
        {
            AtataContext.Configure().Build();
        }

        [AfterScenario]
        public static void TearDownScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            AtataContext.Current?.CleanUp();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            NLog.LogManager.Shutdown();
        }
    }
}
