using Project_001_UpdateMoney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_001_UpdateMoney
{
    /// <summary>
    /// SaveMoney.xaml 的交互逻辑
    /// </summary>
    public partial class SaveMoney : Window
    {
        public SaveMoney()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            if (string.IsNullOrEmpty(textbox1.Text) || !re.IsMatch(textbox1.Text))
            {
                MessageBoxResult mes = MessageBox.Show("请输入数字", "错误", MessageBoxButton.OK);
            }

            try
            {
                using (BankContext2 context = new BankContext2())
                {
                    var vaultinfo = context.VaultInfo.Where(x => x.Account == "admin").FirstOrDefault();
                    if (vaultinfo == null)
                    {
                        vaultinfo = new VaultInfo
                        {
                            Id = Guid.NewGuid(),
                            Account = "admin",
                            Password = "123",
                            Name = "管理员",
                            Balance = 10000
                        };
                        context.VaultInfo.Add(vaultinfo);
                        context.SaveChanges();
                    }
                    var recordinfo = new RecordInfo();
                    recordinfo.Id = Guid.NewGuid();
                    recordinfo.AccountId = vaultinfo.Id;
                    recordinfo.Amount = Convert.ToDouble(textbox1.Text);
                    recordinfo.Balance = vaultinfo.Balance - recordinfo.Amount;
                    recordinfo.Remark = "存钱";
                    recordinfo.CreateTime = DateTime.Now;
                    context.RecordInfo.Add(recordinfo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult mes = MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK);
                //throw new Exception(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
