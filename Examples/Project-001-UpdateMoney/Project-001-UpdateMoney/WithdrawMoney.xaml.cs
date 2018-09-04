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
    /// WithdrawMoney.xaml 的交互逻辑
    /// </summary>
    public partial class WithdrawMoney : Window
    {
        public WithdrawMoney()
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
                    var recordinfo = new RecordInfo
                    {
                        Id = Guid.NewGuid(),
                        AccountId = vaultinfo.Id,
                        Amount = Convert.ToDouble(textbox1.Text),
                        Remark = "取钱",
                        CreateTime = DateTime.Now
                    };
                    recordinfo.Balance = vaultinfo.Balance - recordinfo.Amount;
                    if (recordinfo.Balance < 0)
                    {
                        throw new Exception("余额不足！");
                    }
                    vaultinfo.Balance = recordinfo.Balance;
                    //添加
                    context.RecordInfo.Add(recordinfo);
                    //更新
                    context.VaultInfo.Attach(vaultinfo);
                    context.Entry(vaultinfo).State = System.Data.Entity.EntityState.Modified;
                    //存储到数据库
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult mes2 = MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK);
                //throw new Exception(ex.Message);
            }

            MessageBoxResult mes3 = MessageBox.Show("操作成功", "提示", MessageBoxButton.OK);
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
