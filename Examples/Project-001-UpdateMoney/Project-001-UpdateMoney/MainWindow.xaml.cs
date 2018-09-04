using Project_001_UpdateMoney.Data;
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

namespace Project_001_UpdateMoney
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationWindow window = new NavigationWindow();
            //window.Source = new Uri("SaveMoney.xaml", UriKind.Relative);
            //window.ShowDialog();

            SaveMoney isw = new SaveMoney();//这是新窗口的类
            //isw.Title = "给新页面命名";//这里可以给新窗口重新命名
            //isw.Show();//无模式，弹出！
            isw.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WithdrawMoney isw = new WithdrawMoney();
            isw.ShowDialog();
        }





        private string ConvertGuid(Guid gd)
        {
            string sgd = gd.ToString().ToUpper();
            string sVar = "";
            int i;

            foreach (string sv in new string[] {
        sgd.Substring(0, 8), sgd.Substring(9, 4), sgd.Substring(14, 4) })
            {
                for (i = sv.Length - 2; i >= 0; i -= 2)
                {
                    sVar += sv.Substring(i, 2);
                }
            }

            sgd = sgd.Substring(19).Replace("-", "");
            for (i = 0; i < 8; i++)
            {
                sVar += sgd.Substring(2 * i, 2);
            }

            return sVar;
        }
    }
}
