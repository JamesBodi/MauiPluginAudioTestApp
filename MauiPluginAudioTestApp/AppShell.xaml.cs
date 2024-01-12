namespace MauiPluginAudioTestApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                DisplayAlert("AppShell Error", ex.Message, "OK");
            }
        }
    }
}