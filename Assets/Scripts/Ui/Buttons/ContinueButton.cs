namespace Snake.App
{
    public sealed class ContinueButton : AppStateButton
    {
        protected override void OnCLick()
        {
            AppState.Continue();
        }
    }
}
