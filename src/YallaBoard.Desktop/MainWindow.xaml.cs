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
            MainBoard.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString("#FF7A00"); // برتقالي افتراضي
            MainBoard.DefaultDrawingAttributes.Width = 5;
            MainBoard.DefaultDrawingAttributes.Height = 5;
            MainBoard.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
            MainBoard.DefaultDrawingAttributes.IsHighlighter = false;
        }

        // --- نظام الإغلاق الذكي للنوافذ المنبثقة ---
        private void MainBoard_PreviewTouch(object sender, InputEventArgs e)
        {
            // بمجرد لمس السبورة، أغلق إعدادات القلم والممحاة فوراً
            PopupPenSettings.IsOpen = false;
            PopupEraserSettings.IsOpen = false;
        }

        // --- أزرار شريط الأدوات ---
        private void BtnPen_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.EditingMode = InkCanvasEditingMode.Ink;
            MainBoard.DefaultDrawingAttributes.IsHighlighter = false;
            
            // إذا ضغط عليه مرة ثانية يفتح الإعدادات
            if (BtnPen.IsChecked == true)
                PopupPenSettings.IsOpen = true;
        }

        private void BtnEraser_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.EditingMode = InkCanvasEditingMode.EraseByPoint;
            
            if (BtnEraser.IsChecked == true)
                PopupEraserSettings.IsOpen = true;
        }

        private void BtnHighlighter_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.EditingMode = InkCanvasEditingMode.Ink;
            MainBoard.DefaultDrawingAttributes.IsHighlighter = true;
            MainBoard.DefaultDrawingAttributes.Color = Color.FromArgb(128, 0, 180, 216); // أزرق شفاف للتظليل
            MainBoard.DefaultDrawingAttributes.Width = 25;
            MainBoard.DefaultDrawingAttributes.Height = 25;
            MainBoard.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle; // التظليل بسن عريض
        }

        // --- وظائف إعدادات القلم المنبثقة ---
        private void PenThickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MainBoard != null && !MainBoard.DefaultDrawingAttributes.IsHighlighter)
            {
                MainBoard.DefaultDrawingAttributes.Width = e.NewValue;
                MainBoard.DefaultDrawingAttributes.Height = e.NewValue;
            }
        }

        private void PenTipRound_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse; // سن دائري عادي
        }

        private void PenTipChisel_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle; // سن مشطوف (Calligraphy)
            MainBoard.DefaultDrawingAttributes.StylusTipTransform = new Matrix(1, 0.5, 0, 1, 0, 0); // زاوية الميل
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string colorHex)
            {
                MainBoard.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorHex);
            }
        }

        // --- وظائف إعدادات الممحاة ---
        private void EraserSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MainBoard != null)
            {
                MainBoard.EraserShape = new EllipseStylusShape(e.NewValue, e.NewValue);
            }
        }

        private void ClearBoard_Click(object sender, RoutedEventArgs e)
        {
            MainBoard.Strokes.Clear();
        }

        // --- التحكم في النافذة ---
        private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed) DragMove();
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
