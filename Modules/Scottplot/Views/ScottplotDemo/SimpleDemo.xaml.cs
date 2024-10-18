using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace Scottplot.Views.ScottplotDemo
{
    /// <summary>
    /// SimpleDemo.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleDemo : UserControl
    {

        
        private readonly Random rand;
        private double[] xs, ys;
        private int count = 0;
        public SimpleDemo()
        {
            InitializeComponent();

            
                rand = new Random();
                xs = new double[100];
                ys = new double[100];
            ScottPlot.Plot myPlot = new();
            myPlot = WpfPlot1.Plot.Add.Scatter(xs, ys);
                FormsPlot1.Refresh();

                // 设置定时器每隔一段时间更新数据
                System.Timers.Timer timer = new System.Timers.Timer(100); // 100毫秒更新一次
                timer.Elapsed += TimerElapsed;
                timer.Start();
            
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // 更新数据
            if (count < 100)
            {
                xs[count] = count; // X 轴值
                ys[count] = rand.NextDouble(); // Y 轴随机值
                count++;
            }
            else
            {
                // 移动窗口
                for (int i = 0; i < 99; i++)
                {
                    xs[i] = xs[i + 1];
                    ys[i] = ys[i + 1];
                }
                xs[99] = count; // 添加新的X值
                ys[99] = rand.NextDouble(); // 添加新的Y值
            }
           
            // 刷新图表
            WpfPlot1.Invoke(new Action(() => FormsPlot1.Refresh()));
        }
    }
}
