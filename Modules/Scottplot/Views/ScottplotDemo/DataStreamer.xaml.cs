﻿using System;
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

namespace ScottplotCase.Views.ScottplotDemo
{
    /// <summary>
    /// DataStreamer.xaml 的交互逻辑
    /// </summary>
    public partial class DataStreamer : UserControl
    {
        public DataStreamer()
        {
            InitializeComponent();
            DataStreamerViewModel vm = new DataStreamerViewModel();
            DataContext = vm;
            init();
        }

        private void init()
        {
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };
            WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            WpfPlot1.Refresh();
        }
    }
}
