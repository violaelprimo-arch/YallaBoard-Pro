using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Ink;

namespace YallaBoard.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetDefaultPen();
        }

        private void SetDefaultPen()
        {
            MainBoard.EditingMode = InkCanvasEditingMode.Ink;
            MainBoard.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString("#071952");
            MainBoard.DefaultDrawingAttributes.Width = 5;
            MainBoard.DefaultDrawingAttributes.Height = 5;
            MainBoard.DefaultDrawingAttributes.FitToCurve = true; // تنعيم الخط التلقائي
            MainBoard.DefaultDrawingAttributes.IsHighlighter = false;
        }

        // --- وظائف شريط الأدوات ---

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string colorHex)
            {
                MainBoard.EditingMode = InkCanvasEditingMode.Ink;
                MainBoard.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorHex);
                MainBoard.DefaultDrawingAttributes.IsHighlighter = false;
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
            MainBoard.DefaultDrawingAttributes.IsHighlighter = false;
        }

        private void HighlighterMode_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.EditingMode = InkCanvasEditingMode.Ink;
            MainBoard.DefaultDrawingAttributes.IsHighlighter = true;
            MainBoard.DefaultDrawingAttributes.Width = 25; // سُمك أكبر للتظليل
            MainBoard.DefaultDrawingAttributes.Height = 25;
            MainBoard.DefaultDrawingAttributes.Color = Color.FromArgb(128, 255, 235, 59); // أصفر شفاف
        }

        private void EraserMode_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.EditingMode = InkCanvasEditingMode.EraseByPoint; // الممحاة الدقيقة
        }

        private void ClearBoard_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.Strokes.Clear();
        }

        // --- وظائف النافذة الاحترافية ---

        private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // السماح بسحب النافذة من الشريط العلوي
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
