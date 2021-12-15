using Atata;

namespace IFlow.Testing.Pages
{
    using _ = MainPage;
    public class MainPage : BasePage<_>
    {
        [FindByClass("_1mng1hj7")]
        [WaitFor(Until.Visible)]
        public Clickable<_> JoinButton { get; set; }
    }
}
