using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowModule.Views
{
    public class VisualHost : UIElement
    {
        public Visual Visual { get; set; }

        protected override int VisualChildrenCount
        {
            get { return Visual != null ? 1 : 0; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return Visual;
        }
    }

    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            
            InitializeComponent();
            _drawingVisual = new DrawingVisual();
            _dataPoints = new List<double>();
            _random = new Random();
            DrawInitialLines();
            MyCanvas.Children.Add(new VisualHost() { Visual = _drawingVisual });
        }
        private DrawingVisual _drawingVisual;
        private List<double> _dataPoints;
        private Random _random;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            Timer timer = new Timer();
            timer.Interval=1000;
            timer.Elapsed += (s, e) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    //double newDataPoint = _random.Next(1, 50);
                    //_dataPoints.Add(newDataPoint);
                    //DrawLines();
                });

            };
            timer.Start();

            double newDataPoint = _random.Next(1, 50);
            _dataPoints.Add(newDataPoint);
            DrawLines();
        }


        private void DrawInitialLines()
        {
            using (DrawingContext drawingContext = _drawingVisual.RenderOpen())
            {
                // 绘制坐标系
                Pen axisPen = new Pen(Brushes.Black, 1);
                drawingContext.DrawLine(axisPen, new Point(50, 250), new Point(550, 250)); // X 轴
                drawingContext.DrawLine(axisPen, new Point(50, 250), new Point(50, 50)); // Y 轴
            }
        }

        private void DrawLines()
        {
            using (DrawingContext drawingContext = _drawingVisual.RenderOpen())
            {
                Pen linePen = new Pen(Brushes.Blue, 2);

                // 绘制所有的折线段
                for (int i = 0; i < _dataPoints.Count - 1; i++)
                {
                    Point startPoint = new Point(50 + i * 70, 250 - _dataPoints[i] * 5); // X轴位置和Y轴高度
                    Point endPoint = new Point(50 + (i + 1) * 70, 250 - _dataPoints[i + 1] * 5);
                    drawingContext.DrawLine(linePen, startPoint, endPoint);
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double newDataPoint = _random.Next(1, 50);
            _dataPoints.Add(newDataPoint);
            DrawLines();
        }
    }
}
