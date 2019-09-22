using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DevExpress.Mvvm;

namespace SamplePlayer.Controls
{
    public class SampleControlViewModel : ViewModelBase
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        

        private string _fileSource;
        private string _sampleName;
        private string _shortFilePath;

        public string ShortFilePath
        {
            get { return _shortFilePath; }
            set { SetProperty(ref _shortFilePath, value, () => ShortFilePath); }
        }
        public string SampleName
        {
            get { return _sampleName; }
            set { SetProperty(ref _sampleName, value, () => SampleName); }
        }
        public string FileSource
        {
            get { return _fileSource; }
            set { SetProperty(ref _fileSource, value, () => FileSource); }
        }

        public DelegateCommand PlaySampleCommand { get; set; }

        public SampleControlViewModel()
        {
            PlaySampleCommand = new DelegateCommand(PlaySample);
        }

        public void PlaySample()
        {
            if (String.IsNullOrEmpty(FileSource))
                return;

            mediaPlayer.Open(new Uri(FileSource));
            mediaPlayer.Play();
        }
    }
}
