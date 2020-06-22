using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using WindowsInput.Native;
using WindowsInput;
using Microsoft.Win32;
using System.Windows.Interop;
using System.Runtime.InteropServices;
namespace Twitch_Tool_by_sntl_Yeet
{
    
    public partial class MainWindow : Window 
    {
        //hotkey
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int HOTKEY_ID = 9000;

        //Modifiers:
        private const uint MOD_NONE = 0x0000; //(none)
        private const uint MOD_ALT = 0x0001; //ALT
        private const uint MOD_CONTROL = 0x0002; //CTRL
        private const uint MOD_SHIFT = 0x0004; //SHIFT
        private const uint MOD_WIN = 0x0008; //WINDOWS
        //CAPS LOCK:
        private const uint VK_CAPITAL = 0x70;
        List<string> paths = new List<string>();
        Boolean CanRun = false;
        InputSimulator Simulator = new InputSimulator();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        

    //global hotkey
        private IntPtr _windowHandle;
        private HwndSource _source;
        protected override void OnSourceInitialized(EventArgs e)
        {
            callLoadingScreen();


            base.OnSourceInitialized(e);

            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source.AddHook(HwndHook);

            RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_CONTROL, VK_CAPITAL); //CTRL + CAPS_LOCK

            
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            int vkey = (((int)lParam >> 16) & 0xFFFF);
                            if (vkey == VK_CAPITAL)
                            {
                                //code execution:
                                CanRun = false;
                                Stop();

                            }
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        protected override void OnClosed(EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            UnregisterHotKey(_windowHandle, HOTKEY_ID);
            base.OnClosed(e);
        }
        
        private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        {
            CanRun = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == true)
            {
                
                foreach (String item in openFileDialog.FileNames)
                {
                    lbFiles.Items.Add(item);
                    paths.Add(item);
                }
            }
        }
        private void startBot_Click(object sender, RoutedEventArgs e)
        {
            
            countdown();
            
        }
        private async void countdown()
        {
            CanRun = false;
            startBot.Content = "Starting";
            await Task.Delay(1000);
            startBot.Content = "5";
            await Task.Delay(1000);
            startBot.Content = "4";
            await Task.Delay(1000);
            startBot.Content = "3";
            await Task.Delay(1000);
            startBot.Content = "2";
            await Task.Delay(1000);
            startBot.Content = "1";
            await Task.Delay(1000);
            startBot.Content = "Lets Go!";
            CanRun = true;
            run();
        }

        private async void run()
        {
            
            foreach (String item in paths) { 

                string[] lines = File.ReadAllLines(item);

                 for (int i = 0; i < lines.Length; i++)
                 {
                    if (CanRun)
                    {
                        Simulator.Keyboard.TextEntry("/ban " + lines[i]);
                        Simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                        await Task.Delay(300);
                    }
                    else {
                    break;
                    }
                }
            }
            startBot.Content = "Done!";
            CanRun = false;
            await Task.Delay(500);
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();

        }
        private async void Stop()
        {
            startBot.Content = "Stopped!";
            CanRun = false;
            await Task.Delay(1000);
            startBot.Content = "Start";
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

            if (lbFiles.SelectedItems.Count != 0)
            {
                while (lbFiles.SelectedIndex != -1)
                {
                    paths.RemoveAt(lbFiles.SelectedIndex);
                    lbFiles.Items.RemoveAt(lbFiles.SelectedIndex);
                    
                }
            }

        }

        public void showApp()
        {
            btnOpenFile.Visibility = Visibility.Visible;
            startBot.Visibility = Visibility.Visible;
            lbFiles.Visibility = Visibility.Visible;
            removeSelected.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
        }
        public void hideApp()
        {
            btnOpenFile.Visibility = Visibility.Hidden;
            startBot.Visibility = Visibility.Hidden;
            lbFiles.Visibility = Visibility.Hidden;
            removeSelected.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
        }
        public void showLoading()
        {
            LoadingBarImage.Visibility = Visibility.Visible;
            LoadingBarLabel.Visibility = Visibility.Visible;
            LoadingBarRectangle.Visibility = Visibility.Visible;
        }
        public void hideLoading()
        {
            LoadingBarImage.Visibility = Visibility.Hidden;
            LoadingBarLabel.Visibility = Visibility.Hidden;
            LoadingBarRectangle.Visibility = Visibility.Hidden;
        }

        public async void loadingScreen()
        {
            hideApp();
            showLoading();
            LoadingBarRectangle.Width = 1;
            await Task.Delay(100);
            LoadingBarRectangle.Width = 69;
            await Task.Delay(500);
            LoadingBarRectangle.Width = 154;
            await Task.Delay(300);
            LoadingBarRectangle.Width = 200;
            await Task.Delay(700);
            LoadingBarRectangle.Width = 239;
            await Task.Delay(500);
            hideLoading();
            showApp();
        }
        public void callLoadingScreen()
        {
            loadingScreen();
        }
    }
}

