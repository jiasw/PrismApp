using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Scottplot.Views.ScottplotDemo
{
    /// <summary>
    /// SimpleDemo.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleDemo : UserControl
    {

        private readonly Random _random = new Random();
        private readonly double[] _dataX;
        private readonly double[] _dataY;
        private int _pointCount = 100;
        public SimpleDemo()
        {
            InitializeComponent();
            _dataX = new double[_pointCount];
            _dataY = new double[_pointCount];
            this.Loaded+=SimpleDemo_Loaded;
            

        }

        private void SimpleDemo_Loaded(object sender, RoutedEventArgs e)
        {
            

            // 初始化 X 数据
            for (int i = 0; i < _pointCount; i++)
            {
                _dataX[i] = i;
            }

            // 设置定时器
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // 每秒触发一次
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            
            // 实时更新 Y 数据
            for (int i = 0; i < _pointCount - 1; i++)
            {
                _dataY[i] = _dataY[i + 1]; // 把数据往前移动
            }
            _dataY[_pointCount - 1] = _random.NextDouble(); // 生成新的随机数据

            // 绘制图表
            WpfPlot1.Plot.Clear(); // 清除之前的图形
            WpfPlot1.Plot.Add.Scatter(_dataX, _dataY); // 添加新的数据
            WpfPlot1.Refresh(); // 刷新图表
        }
    }
}
