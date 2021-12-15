﻿using FluentAssertions;
using IFlow.Testing.Utils.Api;
using SharpGaming.Pages;
using SharpGaming.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace IFlow.Testing.StepDefinitions
{
    [Binding]
    public sealed class GamesApiSteps : BaseSteps
    {
        private dynamic responseData;
        private List<int> responseCountries;

        [When(@"User check health service status information by Api")]
        public async Task WhenUserCheckHealthServiceStatusInformationByApi()
        {
            responseData = await GamesApi.GetHealthData();
        }

        [Then(@"Health service status is correct")]
        public void ThenHealthServiceStatusIsCorrect()
        {
            ((string)responseData.service).Equals(StringConsts.ResponseStatusOK).Should().BeTrue();
        }

        [When(@"User check country information")]
        public async Task WhenUserCheckCountryInformationInLanguageByApi(Table language)
        {
            responseCountries = new List<int>();
            var languageList = LottoPage.TableToList(language);
            foreach (var item in languageList)
            {
                responseData = await GamesApi.GetCountryData(item);
                responseCountries.Add(responseData.countries.Count);
            }
        }

        [Then(@"Number of countries is correct")]
        public void ThenNumberOfCountriesIsCorrect()
        {
            for (int i = 0; i < responseCountries.Count; i++)
            {
                for (int j = responseCountries.Count - 1; j > 0; j--)
                {
                    if (i != j)
                    {
                        responseCountries[i].Should().Equals(responseCountries[j]);
                    }
                }
            }
        }
    }
}
