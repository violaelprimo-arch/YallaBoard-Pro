using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YallaBoard.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // إعدادات القلم الافتراضية عند فتح البرنامج
            MainBoard.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString("#071952");
            MainBoard.DefaultDrawingAttributes.Width = 5;
            MainBoard.DefaultDrawingAttributes.Height = 5;
            MainBoard.DefaultDrawingAttributes.FitToCurve = true; // تنعيم الخط
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string colorHex)
            {
                MainBoard.EditingMode = InkCanvasEditingMode.Ink; // تفعيل القلم أوتوماتيكياً
                MainBoard.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorHex);
            }
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MainBoard != null)
            {
                MainBoard.DefaultDrawingAttributes.Width = e.NewValue;
                MainBoard.DefaultDrawingAttributes.Height = e.NewValue;
            }
        }

        private void PenMode_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void EraserMode_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.EditingMode = InkCanvasEditingMode.EraseByPoint; // الممحاة التي تمسح جزء من الخط
        }

        private void ClearBoard_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.Strokes.Clear(); // مسح السبورة بالكامل
        }
    }
}
