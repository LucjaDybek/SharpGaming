using Atata;
using IFlow.Testing.Pages;
using IFlow.Testing.Utils.DataFactory;
using SharpGaming.Pages;
using SharpGaming.Utils;
using System;
using TechTalk.SpecFlow;

namespace IFlow.Testing.StepDefinitions
{
    [Binding]
    public sealed class RegisterSteps : BaseSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public RegisterSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            SetRandomUser(_scenarioContext);
        }

        [Given(@"Unregister user creates an account")]
        public void GivenUnregisterUserCreatesAnAccount()
        {
            var page = Go.To<MainPage>();
            page.JoinButton.Click();
        }

        [When(@"User provides login data")]
        public void WhenUserProvideDataToRegistrationForm()
        {
            On<RegisterPage>()
                .Wait(3)
                .AcceptCookiesButton.Click()
                .EmailInput.Set(User.Email)
                .UserNameInput.Set(User.FirstName+User.LastName)
                .PasswordInput.Set(User.Password)
                .TermsAgreementCheckBox.Click()
                .Wait(3)
                            //  .ContinueButton.Click();
                            .ClickContinueButton();

        }

        [When(@"Personal data")]
        public void WhenPersonalData()
        {
            //Click on ContinueButton is performed 2 times,
            //because probably this element is covered
            //and the first click takes place below an actual button
            //I wasn't sure how to fix it - tried to click with offset
            //but with no success

            On<RegisterPage>()
                .FirstNameInput.Set(User.FirstName)
                .LastNameInput.Set(User.LastName)
                .BirthDayInput.Set(UserConsts.RandomDay()[0])
                .BirthMonthInput.Set(UserConsts.RandomDay()[1])
                .BirthYearInput.Set(UserConsts.RandomDay()[2])
              .Wait(3)
              // .ContinueButton.Click() 
              //  .ContinueButton.Click();
              .ClickContinueButton();
        }

        [When(@"Security data")]
        public void WhenSecurityData()
        {
            On<RegisterPage>()
                .PhoneInput.Set(User.PhoneNumber)
                .QuestionList.Set(StringConsts.SecurityQuestionMomName)
                .QuestionAnswearInput.Set(User.LastName)
                .Wait(3)
                        .ContinueButton.Click();
                      //.ClickContinueButton();

        }

        [When(@"Address data")]
        public void WhenAddressData()
        {
            On<RegisterPage>()
                .OutsideUKButton.Click()
                .CountryList.Set("United Kingdom")
                .AddressLineInput.Set(User.Address)
                .CityInput.Set(User.Address)
                     //   .ContinueButton.Click();
                      .Wait(3)
                      .ClickContinueButton();

        }

        [When(@"Confirms registration")]
        public void WhenConfirmsRegistration()
        {
            On<RegisterPage>()
                .FirstNoMarketingCheck.Click()
                .ThirdNoMarketingCheck.Click()
                .RegisterButton.Click();
        }

        [Then(@"An account is created successfully")]
        public void ThenAnAccountIsCreatedSuccessfully()
        {
            On<RegisterPage>()
                .RegisterInfo.Should.BeVisible();
        }
    }
}
