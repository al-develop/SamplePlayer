using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SamplePlayer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = (MainWindowViewModel)this.DataContext;
            vm.SelectRootFunction = new Func<string>(SelectRoot);
        }

        private string SelectRoot()
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            dialog.Description = "Select the root folder for the samples";
            dialog.UseDescriptionForTitle = true;
            bool? selection = dialog.ShowDialog();
            if (selection == true)
                return dialog.SelectedPath;
            return "";
        }

    }
}
