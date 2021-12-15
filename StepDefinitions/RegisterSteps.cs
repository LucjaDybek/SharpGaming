using Atata;
using IFlow.Testing.Pages;
using IFlow.Testing.Utils.DataFactory;
using OpenQA.Selenium;
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
                .AcceptCookies().Click()
                .EmailInput.Set(User.Email) 
                .UserNameInput.Set(User.UserName)
                .PasswordInput.Set(User.Password)
                .TermsAgreementCheckBox.Should.BeEnabled()
                .TermsAgreementCheckBox.Click()
                .ContinueButton.Should.BeEnabled()
                .IsSucces("RegistrationPage.AccountSection.password")
                .ContinueButton.Click();
        }

        [When(@"Personal data")]
        public void WhenPersonalData()
        {
            On<RegisterPage>()
                .FirstNameInput.Set(User.FirstName)
                .LastNameInput.Set(User.LastName)
                .BirthDayInput.Set(UserConsts.RandomDay()[0])
                .BirthMonthInput.Set(UserConsts.RandomDay()[1])
                .BirthYearInput.Set(UserConsts.RandomDay()[2])
                .TitleButton.Click()
                .ContinueButton.Should.BeVisible()
                .ClickContinueButton();
        }

        [When(@"Security data")]
        public void WhenSecurityData()
        {
            On<RegisterPage>()               
                .PhoneInput.Set(User.PhoneNumber)
                .QuestionList.Set(StringTestsConsts.SecurityQuestionMomName)
                .QuestionAnswearInput.Set(User.LastName)
                .IsSucces("RegistrationPage.Dropdown.desktop-securityQuestion")
                .ContinueButton.Script.Click();
        }

        [When(@"Address data")]
        public void WhenAddressData()
        {
            On<RegisterPage>()
                .OutsideUKButton.Click()
                .CountryList.Set(StringTestsConsts.CountryName)
                .AddressLineInput.Set(User.Address)
                .CityInput.Set(User.Address)
                .ContinueButton.Should.BeVisible()
                .ContinueButton.Click();
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
