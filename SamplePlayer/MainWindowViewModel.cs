﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using SamplePlayer.Controls;

namespace SamplePlayer
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _root;
        private ObservableCollection<SampleControlViewModel> _sampleControls;
        private SampleControlViewModel _currentSample;

        public SampleControlViewModel CurrentSample
        {
            get { return _currentSample; }
            set { SetProperty(ref _currentSample, value, () => CurrentSample); CurrentSample.PlaySample(); }
        }
        public ObservableCollection<SampleControlViewModel> SampleControls
        {
            get { return _sampleControls; }
            set { SetProperty(ref _sampleControls, value, () => SampleControls); }
        }
        public string Root
        {
            get { return _root; }
            set { SetProperty(ref _root, value, () => Root); }
        }

        public Func<string> SelectRootFunction { get; set; }
        public DelegateCommand SelectRootCommand { get; set; }

        public MainWindowViewModel()
        {
            SelectRootCommand = new DelegateCommand(SelectRoot);
            SampleControls = new ObservableCollection<SampleControlViewModel>();
        }

        private void SelectRoot()
        {
            string root = SelectRootFunction.Invoke();
            if (String.IsNullOrEmpty(root))
                return;

            this.Root = root;
            LoadControls();
        }

        private void LoadControls()
        {
            SampleControls = new ObservableCollection<SampleControlViewModel>();
            string[] files = Directory.GetFiles(Root, "*.wav", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                var info = new FileInfo(f);

                var sample = new SampleControlViewModel();
                sample.FileSource = f;
                sample.SampleName = info.Name;
                sample.ShortFilePath = GetShortFilePath(info.FullName);
                this.SampleControls.Add(sample);
            }
        }

        private string GetShortFilePath(string fullname)
        {
            IEnumerable<string> f = fullname.Split('\\').Reverse().Take(2).Reverse();
            string r = string.Join("\\", f.ToArray());
            return r;

        }
    }
}