using Atata;
using FluentAssertions;
using IFlow.Testing.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using TechTalk.SpecFlow;

namespace SharpGaming.Pages
{
    using _ = LottoPage;
    [Url(LottoUrl)]
    public class LottoPage : BasePage<_>
    {
        private const string LottoUrl = "/lotto/irish";

        public _ PickDateInCalendar(int days)
        {
            CultureInfo myCI = CultureInfo.InstalledUICulture;
            var date = DateTime.Now.AddDays(days).ToString("d MMMM yyyy", myCI);

            if (DateTime.Now.AddDays(days).Month != DateTime.Now.AddDays(-14).Month)
            {
                driver.FindElement(By.XPath("//button[contains(@class, 'react-calendar__navigation__next-button')]//div[1]")).Click();
            }
            driver.FindElement(By.XPath($"//abbr[@aria-label = '{date}']")).Click();
            driver.FindElement(By.CssSelector("[data-actionable='Form.Datepicker.Continue']")).Click();
            return this;
        }

        public void AreResultDatesCorrect(int days)
        {
            var results = driver.FindElements(By.CssSelector("[data-actionable ^= 'Lotto.DrawTile-IRISHLOTTERY-']"));

            foreach (var item in results)
            {
                DateTime.Parse(item.FindElement(By.XPath($"div[1]")).Text.Substring(0, 11)).Should().BeOnOrAfter(DateTime.Now.AddDays(days).Date).And.BeOnOrBefore(DateTime.Now.Date);
            }
        }

        public static List<string> TableToList(Table table)
        {
            var list = new List<string>();
            foreach (var row in table.Rows)
            {
                list.Add(row[0]);
            }
            return list;
        }

        [FindByCss("[data-actionable = 'Lotto.SelectLottoBanner.Results']")]
        public Clickable<_> ResultsButton { get; set; }

        [FindByCss("[data-actionable = 'Lotto.ResultsDateFilter.SetDateFrom']")]
        public Clickable<_> DateFromButton { get; set; }

        [FindByCss("[data-actionable = 'LottoApp.ResultsPage.DateFilter.submit']")]
        public Button<_> ViewResultsButton { get; set; }
    }
}
