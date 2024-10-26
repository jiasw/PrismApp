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
using System.Windows.Threading;

namespace ShowModule.Views
{
    /// <summary>
    /// DrawVisualTest.xaml 的交互逻辑
    /// </summary>
    public partial class DrawVisualTest : UserControl
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
        private const int MaxPoints = 100; // 最大点数
        private const int CanvasHeight = 400;
        private const int CanvasWidth = 600;

        private const int Startx = 80;

        private List<Point> points = new List<Point>();
        private DispatcherTimer timer;
        public DrawVisualTest()
        {
            InitializeComponent();

            // 设置定时器，每秒触发一次
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200) 
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 随机生成一个新的数据点
            Random random = new Random();
            double newY = random.Next(0, (int)(CanvasHeight * 0.8)); // 随机Y值，限定在Canvas高度之内
            double newX = Startx + points.Count * 2; // X值随点数增加而增加

            if (points.Count > MaxPoints)
            {
                points.RemoveAt(0); // 移除最旧的点
                points=points.Select(p => new Point(p.X-2,p.Y)).ToList(); // 平移所有点
            }
            Point newPoint = new Point(newX, CanvasHeight - newY); // X为点的序号，Y为随机值
            points.Add(newPoint);
            DrawLineGraph();
        }

        private void DrawLineGraph()
        {
            MyCanvas.Children.Clear(); // 清空Canvas

            // 创建一个新的 DrawingVisual
            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext drawingContext = visual.RenderOpen())
            {
                Pen linePen = new Pen(Brushes.LightGreen, 2);
                for (int i = 1; i < points.Count; i++)
                {
                    drawingContext.DrawLine(linePen, points[i - 1], points[i]);
                }
            }
            var visualHost = new VisualHost() { Visual = visual };
            // 将visual添加到Canvas中
            MyCanvas.Children.Add(visualHost);

            // 平移Canvas，使折线图看起来是在滚动
            
            Canvas.SetLeft(visualHost, -15);
        }

    }
}
