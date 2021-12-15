using Atata;
using IFlow.Testing.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SharpGaming.Pages
{
    using _ = RegisterPage;
    [Url(RegisterUrl)]
    public class RegisterPage : BasePage<_>
    {
        private const string RegisterUrl = "/registration";

        [FindByCss("[data-actionable = 'Header.CookieBanner.accept_cookies']")]
        [WaitUntilEnabled]
        public Button<_> AcceptCookiesButton { get; set; }

        [FindById("RegistrationPage.AccountSection.email")]
        [WaitUntilEnabled]
        public TextInput<_> EmailInput { get; set; }

        [FindById("RegistrationPage.AccountSection.username")]
        public TextInput<_> UserNameInput { get; set; }

        [FindById("RegistrationPage.AccountSection.password")]
        public PasswordInput<_> PasswordInput { get; set; }

        [FindById("agree_terms-checkbox", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public CheckBox<_> TermsAgreementCheckBox { get; set; }
        
        [FindByCss("[data-actionable ^= 'RegistrationPage.NavigationButtonsPage'][data-actionable $= '.Continue']", Visibility = Visibility.Any)]
        public Button<_> ContinueButton { get; set; }


        public RegisterPage ClickContinueButton()
        {
            var element = driver.FindElement(By.CssSelector("[data-actionable ^= 'RegistrationPage.NavigationButtonsPage'][data-actionable $= '.Continue']"));

            Actions act = new Actions(driver);
            act.MoveToElement(element, 0, 10).Click().Build().Perform();
            return this;
        }

        [FindById("RegistrationPage.PersonalSection.first_name")]
        public TextInput<_> FirstNameInput { get; set; }

        [FindById("RegistrationPage.PersonalSection.last_name")]
        public TextInput<_> LastNameInput { get; set; }

        [FindById("RegistrationPage.DateOfBirthInput.day")]
        [WaitUntilEnabled]
        public NumberInput<_> BirthDayInput { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.DateOfBirthInput.month']")]
        [WaitUntilEnabled]
        public NumberInput<_> BirthMonthInput { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.DateOfBirthInput.year']")]
        [WaitUntilEnabled]
        public NumberInput<_> BirthYearInput { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.TelephoneNumberInput.telephone.floatingHelp']", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public TelInput<_> PhoneInput { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.Dropdown.desktop-securityQuestion']", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public Select<_> QuestionList { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.ContactSection.desktop_security_answer']")]
        public TextInput<_> QuestionAnswearInput { get; set; }

        [FindByCss("[data-actionable = 'InputLabel.outsidetheuk?']")]
        public Button<_> OutsideUKButton { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.Dropdown.country']", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public Select<_> CountryList { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.AddressEditor.line1']")]
        public TextInput<_> AddressLineInput { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.AddressEditor.city']")]
        public TextInput<_> CityInput { get; set; }

        [FindById("firstParty-No Marketing-checkbox", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public CheckBox<_> FirstNoMarketingCheck { get; set; }

        [FindById("thirdParty-No Marketing-checkbox", Visibility = Visibility.Any)]
        [ClickUsingActions]
        public CheckBox<_> ThirdNoMarketingCheck { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.NavigationButtonsPage5.Register']")]
        [ClickUsingActions]
        public Button<_> RegisterButton { get; set; }

        [FindByCss("[data-actionable = 'RegistrationPage.RegisterHeader.desktop.title']")]
        public H3<_> RegisterInfo { get; set; }
    }
}
