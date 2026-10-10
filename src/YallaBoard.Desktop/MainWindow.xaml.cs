using System.Windows;
using System.Windows.Input;

namespace YallaBoard.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // --- وظائف إغلاق النوافذ (Panels) ---
        
        private void TogglePages_Click(object sender, RoutedEventArgs e)
        {
            PagesPanel.Visibility = PagesPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ToggleTools_Click(object sender, RoutedEventArgs e)
        {
            ToolsPanel.Visibility = ToolsPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ToggleLibrary_Click(object sender, RoutedEventArgs e)
        {
            LibraryPanel.Visibility = LibraryPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void TogglePenSettings_Click(object sender, RoutedEventArgs e)
        {
            PenSettingsPanel.Visibility = PenSettingsPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ToggleTimer_Click(object sender, RoutedEventArgs e)
        {
            TimerPanel.Visibility = TimerPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        // --- التحكم الأساسي في النافذة ---

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
