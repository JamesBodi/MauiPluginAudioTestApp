using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace MauiPluginAudioTestApp
{
    [Activity(
        Label = "MauiPluginAudioTestApp",
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        /// <summary>
        /// Callback for the result from requesting permissions. This method
        /// is invoked for every call on <code>requestPermissions(android.app.Activity, String[], int)</code>.
        /// </summary>
        /// <param name="requestCode">The request code passed in <code>requestPermissions(android.app.Activity, String[], int)</code></param>
        /// <param name="permissions">The requested permissions. Never null.</param>
        /// <param name="grantResults">The grant results for the corresponding permissions which is either <code>PackageManager.PERMISSION_GRANTED</code> or <code>PackageManager.PERMISSION_DENIED</code>. Never null.</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            // Forward the results of the permission request to the Maui platform for further processing.
            // This ensures that any Maui library or feature depending on these permissions can react appropriately.
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}