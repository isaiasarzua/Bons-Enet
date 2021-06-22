using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            o.Title = "Select the game's exe file or shortcut file";
            o.Filter = "Executable or Shortcut (*.exe, *.lnk) | *.exe";
            o.DereferenceLinks = true;
            if ((bool)o.ShowDialog() && o.DereferenceLinks == true)
            {
                Debug.WriteLine("o.SafeFileName: " + o.SafeFileName);
                Debug.WriteLine("o.FileName: " + o.FileName);
                //Debug.WriteLine("Path.GetDirectoryName(o.SafeFileName): " + Path.GetDirectoryName(o.SafeFileName));
                //Debug.WriteLine("Path.GetDirectoryName(o.FileName): " + Path.GetDirectoryName(o.FileName));

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @o.FileName;

                Process.Start(startInfo);
            }
        }
    }
}