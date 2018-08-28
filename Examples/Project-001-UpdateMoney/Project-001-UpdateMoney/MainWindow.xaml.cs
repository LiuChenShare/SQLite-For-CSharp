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
            try
            {
                using (BankContext2 context = new BankContext2())
                {
                    var info = new VaultInfo();
                    info.Id = Guid.NewGuid();
                    info.Account = "admin";
                    info.Password = "123";
                    info.Name = "管理员";
                    info.Balance = 10000;
                    context.VaultInfo.Add(info);
                    context.SaveChanges();
                    var list = context.VaultInfo.ToList();
                    var result = context.VaultInfo.Where(x => x.Id == info.Id).SingleOrDefault();

                    MessageBoxResult mes = MessageBox.Show(list.Count().ToString(), "这是标题", MessageBoxButton.YesNo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
