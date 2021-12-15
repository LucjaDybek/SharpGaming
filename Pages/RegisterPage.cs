using Atata;
using FluentAssertions;
using IFlow.Testing.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SharpGaming.Pages
{
    using _ = RegisterPage;
    [Url(RegisterUrl)]
    public class RegisterPage : BasePage<_>
    {
        public Button<_> AcceptCookies()
        {
            var element = Controls.Create<Button<_>>("AcceptCookiesButton", new FindByCssAttribute("[data-actionable = 'Header.CookieBanner.accept_cookies']"));
            element.Should.BeEnabled();
            return element;
        }

        private const string RegisterUrl = "/registration";

        [FindById("RegistrationPage.AccountSection.email")]
        [WaitUntilEnabled]
        public TextInput<_> EmailInput { get; set; }

        [FindById("RegistrationPage.AccountSection.username")]
        public TextInput<_> UserNameInput { get; set; }

        [FindById("RegistrationPage.AccountSection.password")]
        [ClickUsingActions]
        public PasswordInput<_> PasswordInput { get; set; }

        [FindByXPath("//div[@data-actionable = 'RegistrationPage.TermsAndConditions.agree_terms']//span[1]", Visibility = Visibility.Any)]
        public Clickable<_> TermsAgreementCheckBox { get; set; }

        [FindByCss("[data-actionable ^= 'RegistrationPage.NavigationButtonsPage'][data-actionable $= '.Continue']", Visibility = Visibility.Any)]
        public Button<_> ContinueButton { get; set; }

        [FindById("RegistrationPage.PersonalSection.first_name")]
        public TextInput<_> FirstNameInput { get; set; }

        [FindById("RegistrationPage.PersonalSection.last_name")]
        public TextInput<_> LastNameInput { get; set; }

        [FindById("RegistrationPage.DateOfBirthInput.day")]
        [WaitUntilEnabled]
        public NumberInput<_> BirthDayInput { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.DateOfBirthInput.month", Visibility = Visibility.Any)]
        [WaitUntilEnabled]
        public NumberInput<_> BirthMonthInput { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.DateOfBirthInput.year", Visibility = Visibility.Any)]
        [WaitUntilEnabled]
        [ClickUsingActions]
        public NumberInput<_> BirthYearInput { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.TelephoneNumberInput.telephone.floatingHelp']", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public TelInput<_> PhoneInput { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.Dropdown.desktop-securityQuestion", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public Select<_> QuestionList { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.ContactSection.desktop_security_answer", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public TextInput<_> QuestionAnswearInput { get; set; }

        [FindByAttribute("data-actionable", "InputLabel.outsidetheuk?", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public Button<_> OutsideUKButton { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.RegisterHeader.desktop.title", Visibility = Visibility.Any)]
        public Text<_> RegisterHeadertitle { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.Dropdown.country", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public Select<_> CountryList { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.AddressEditor.line1", Visibility = Visibility.Any)]
        public TextInput<_> AddressLineInput { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.AddressEditor.city", Visibility = Visibility.Any)]
        public TextInput<_> CityInput { get; set; }

        [FindById("firstParty-No Marketing-checkbox", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public CheckBox<_> FirstNoMarketingCheck { get; set; }

        [FindById("thirdParty-No Marketing-checkbox", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public CheckBox<_> ThirdNoMarketingCheck { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.NavigationButtonsPage5.Register")]
        [ClickUsingActions]
        public Button<_> RegisterButton { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.RegisterHeader.desktop.title")]
        public H3<_> RegisterInfo { get; set; }

        [FindByAttribute("data-actionable", "RegistrationPage.PersonalSection.title.Mr")]
        public Button<_> TitleButton { get; set; }

        public _ ClickContinueButton()
        {
            Actions act = new Actions(driver); 
            var element2 = driver.FindElement(By.CssSelector("[data-actionable ^= 'RegistrationPage.NavigationButtonsPage'][data-actionable $= '.Continue']"));

            act.MoveToElement(element2, 0, 10).Click().Build().Perform();

            return this;
        }

        public _ IsSucces(string selector)
        {
            Wait(2);   
            var BackGroundColor =  driver.FindElement(By.CssSelector($"[data-actionable = '{selector}']")).GetCssValue("background-color");
            BackGroundColor.Should().ContainAll("30, 210, 100, 0.1");
            return this;
        }
    }
}
