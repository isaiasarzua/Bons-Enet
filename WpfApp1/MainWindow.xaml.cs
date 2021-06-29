using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Threading;
using SharpDX.XInput;

namespace Bons_Enet
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        DispatcherTimer _timer = new DispatcherTimer();
        private string _leftAxis;
        private string _rightAxis;
        private string _buttons;
        private Controller _controller;
        private NotifyIcon notifyIcon;

        public MainWindow()
        {
            DataContext = this;
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
            InitializeComponent();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            _timer.Tick += _timer_Tick;


            // NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("../../../Resources/MainIcon.ico");
            notifyIcon.Visible = true;
            notifyIcon.Text = "Downloading Resident Evil Budakai - 1.12/kbs - ETA: 1h44m"; // Use this when not playing a game and downloading
            notifyIcon.Text = "Currently playing Mortal Kombat 10"; // Use this when playing a game
            notifyIcon.Text = "Ready to play"; // Default

            notifyIcon.ContextMenuStrip = new ContextMenuStrip();

            // Add items directly to contextmenu
            notifyIcon.ContextMenuStrip.Items.Add("Quit Application", null, new EventHandler((obj, args) => Close()));
            notifyIcon.MouseClick += notifyIcon_MouseClick;

            // Ballontip
            notifyIcon.BalloonTipTitle = "Resident Evil 0 Download Complete"; // Use this when "auto install" is set to false
            notifyIcon.BalloonTipText = "Click to install"; // Use this when "auto install" is set to false. Clicking this prompt will start the installation
            notifyIcon.BalloonTipClicked += notifyIconBalloon_Click;
            notifyIcon.ShowBalloonTip(3);



            //Start testing HTTPClient
            HTTPClient httpClient = new HTTPClient();
            //httpClient.SendPost();
        }

        #region NotifyIcon
        private void notifyIconBalloon_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Show();
        }
        #endregion

        void _timer_Tick(object sender, EventArgs e)
        {
            DisplayControllerInformation();
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            ContextMenu NotifyIconMenu = (ContextMenu)this.FindResource("NotifyIconMenu");
            if (NotifyIconMenu.IsOpen == true)
                NotifyIconMenu.IsOpen = false;
            base.OnLostFocus(e);
        }

        // Minimize to system tray when application is minimized.
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();

            base.OnStateChanged(e);
        }

        // Minimize to system tray when application is closed.
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    // setting cancel to true will cancel the close request
        //    // so the application is not closed
        //    e.Cancel = true;

        //    this.Hide();

        //    base.OnClosing(e);
        //}



        void DisplayControllerInformation()
        {
            var state = _controller.GetState();
            LeftAxis = string.Format("X: {0} Y: {1}", state.Gamepad.LeftThumbX, state.Gamepad.LeftThumbY);
            RightAxis = string.Format("X: {0} Y: {1}", state.Gamepad.RightThumbX, state.Gamepad.RightThumbX);
            //Buttons = string.Format("A: {0} B: {1} X: {2} Y: {3}", state.Gamepad.Buttons.ToString(), state.Gamepad.LeftThumbY);
            Buttons = string.Format("{0}", state.Gamepad.Buttons);

        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            _controller = null;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller(UserIndex.One);
            if (_controller.IsConnected)
            {
                _timer.Start();
                return;
            }
            System.Windows.MessageBox.Show("Game Controller is not connected ... you know ;)");
        }

        private void CloseCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            //if (MessageBox.Show("Close?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            Close();
        }


        #region Properties

        public string LeftAxis
        {
            get
            {
                return _leftAxis;
            }
            set
            {
                if (value == _leftAxis) return;
                _leftAxis = value;
                OnPropertyChanged();
            }
        }

        public string RightAxis
        {
            get
            {
                return _rightAxis;
            }
            set
            {
                if (value == _rightAxis) return;
                _rightAxis = value;
                OnPropertyChanged();
            }
        }

        public string Buttons
        {
            get
            {
                return _buttons;
            }
            set
            {
                if (value == _buttons) return;
                _buttons = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}