
This project was created to demonstrate a major bug in Plugin.Maui.Audio on IOS.

BACKGROUND 
I am working on a mobile app that needs to record and playback audio. I decided to use Plugin.Maui.Audio. This all worked great until I got to testing the app on IOS. PLayback fails on all IOS devices. PLayback does work on IOS simulators. 

TESTING 
I created a new .Net Maui app based on jfversluis project (https://github.com/jfversluis/Plugin.Maui.Audio.git). To my surprise it worked - even on IOS devices! OK, so playback was working, now on to recording audio. 

The recording does work - in a fashion, but playback fails the moment this line is executed:

_audioRecorder = _audioManager.CreateRecorder(); 

Yes, the moment an audio recorder is created, playback no longer works. I cannot see any changes to audioManager or audioPlayer as a result of creating audioRecorder, but there must be some conflict.

If I stop the program and restart it all audio files play, including the one I just recorded. I tried re-initializing audioManager, I tried using DI to inject audioManager, I tried initializing using: 
  _audioRecorder = _audioManager.CreateRecorder(); 
I stepped thru the code in debug, commenting lines to see where things went bad.

In all the videos I've watched and all the sample projects I have reviewed, I have not seen any that record and playback on an IOS device. Was this ever tested?

I very simialr thing happens with MediaElement, which I documented in another issue: 
https://github.com/CommunityToolkit/Maui/issues/1634#issuecomment-1876153420
