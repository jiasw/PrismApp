using HelixToolkit.Wpf;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowModule.Views
{
    /// <summary>
    /// ViewB.xaml 的交互逻辑
    /// </summary>
    public partial class ViewB : UserControl
    {
        public ViewB()
        {
            InitializeComponent();
            LoadModel("3dModel/bugatti.obj");
        }


        private void LoadModel(string filePath)
        {
            // 使用 HelixToolkit 加载模型
            var importer = new ModelImporter();
            try
            {
                // 导入模型
                var model = importer.Load(filePath);
                var modelVisual = new ModelVisual3D { Content = model };
                viewport3D.Children.Add(modelVisual); // 将模型添加到视口中
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载模型失败: {ex.Message}");
            }
        }
    }
}
