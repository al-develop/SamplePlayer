# SamplePlayer
A small WPF and MVVM Application to run samples (short music files) to check, what they sound like before actually using them in a song.

First you need to open the folder, where your samples are located. This folder can also contain subfolders with more samples.
Alternativly, you can enter the path directly into the TextBox and press "Enter".
Then you can run a sample by clicking on it. 

The Dialogs to select a root folder is implemented by using Ooki.Dialogs.
The Mvvm Framewokr used is DevExpress.Mvvm.
The Audio Player is provided by the System.Windows.Media.MediaPlayer class from the .NET Framework (PresentationCore DLL).
The Watermark TextBox is from the Xceed WPF Toolkit.
