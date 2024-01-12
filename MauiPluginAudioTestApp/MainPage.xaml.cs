using Plugin.Maui.Audio;

namespace MauiPluginAudioTestApp;

public partial class MainPage : ContentPage
{
    private IAudioManager _audioManager;
    private IAudioRecorder _audioRecorder;
    private IAudioPlayer _audioPlayer = null;
    //private IAudioSource _audio;

    string _localDataFolderPath = FileSystem.AppDataDirectory;

    public MainPage()
    {
        InitializeComponent();

        _audioManager = AudioManager.Current;
    }

    //public MainPage(IAudioManager audioManager)
    //{
    //    InitializeComponent();
    //    _audioManager = audioManager;
    //}

    private async void PlayVoice(object sender, EventArgs e)
    {
        //_audioManager = AudioManager.Current;
        _audioPlayer = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("mysound.wav"));
        _audioPlayer.Play();
    }

    private async void PlaySong(object sender, EventArgs e)
    {
        //_audioManager = AudioManager.Current;
        _audioPlayer = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("ukelele.mp3"));
        _audioPlayer.Play();
    }

    private async void PlayBeep(object sender, EventArgs e)
    {
        //_audioManager = AudioManager.Current;
        _audioPlayer = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("beep_beep.wav"));
        _audioPlayer.Play();
    }

    private void OnPauseClicked(object sender, EventArgs e)
    {
        _audioPlayer.Pause();
    }

    private async void Record(object sender, EventArgs e)
    {
        var granted = await CheckPermissions();
        if (!granted) return;

        //_audioManager = AudioManager.Current;
        _audioRecorder = _audioManager.CreateRecorder(); // TODO: All audio files will play until this line is executed!
        //await _audioRecorder.StartAsync(Path.Combine(_localDataFolderPath,"test.wav"));
        //RecordButton.IsEnabled = false;
        //StopButton.IsEnabled = true;
    }

    private async void StopRecording(object sender, EventArgs e)
    {
        await _audioRecorder.StopAsync();
        RecordButton.IsEnabled = true;
        StopButton.IsEnabled = false;
        _audioRecorder = null;
        //_audioManager = null;
    }

    private async void PlayRecording(object sender, EventArgs e)
    {
        try
        {
            string filePath = Path.Combine(_localDataFolderPath, "test.wav");
            if (File.Exists(filePath))
            {
                _audioPlayer = _audioManager.CreatePlayer(filePath);
                _audioPlayer.Play();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task<bool> CheckPermissions()
    {
        var microphoneStatus = await Permissions.CheckStatusAsync<Permissions.Microphone>();

        if (microphoneStatus != PermissionStatus.Granted)
        {
            microphoneStatus = await Permissions.RequestAsync<Permissions.Microphone>();
        }

        if (microphoneStatus == PermissionStatus.Denied)
        {
            await DisplayAlert("Notice", "In order to record audio, microphone access is required.", "OK");
            return false;
        }

        return true;
    }
}

