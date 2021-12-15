using Atata;
using IFlow.Testing.StepDefinitions;
using SharpGaming.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SharpGaming.StepDefinitions
{
    [Binding]
    public sealed class LottoSteps : BaseSteps
    {
        [Given(@"User enters to the Results page")]
        public void GivenUserEntersToTheResultsPage()
        {
            Go.To<LottoPage>()
                .ResultsButton.Click();
           
        }

        [When(@"User picks the date (.*) days ago and show results")]
        public void WhenUserPicksTheDate7DaysAgoAndShowResults(string days)
        {
            On<LottoPage>()
                .DateFromButton.Click()
                .PickDateInCalendar(int.Parse(days))
                .ViewResultsButton.Click()
                .Wait(5);
        }

        [Then(@"Results section only show results from (.*) days")]
        public void ThenResultsSectionOnlyShowResultsFromDays(string days)
        {
            On<LottoPage>()
                .AreResultDatesCorrect(int.Parse(days));
        }
    }
}
