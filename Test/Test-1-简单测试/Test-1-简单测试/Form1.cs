using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_1_简单测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (RetailContext context = new RetailContext())
                {
                    context.Persons.Add(new Person { Id = Guid.NewGuid(), Name = "wolfy1" });
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (RetailContext context = new RetailContext())
                {
                    var a = context.Persons.Where(x => x.Id != Guid.Empty).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (RetailContext context = new RetailContext())
                {
                    var a = context.B1.Where(x => x.Id != 0).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (RetailContext context = new RetailContext())
                {
                    Encoding utf8 = Encoding.UTF8;
                    var info = new b1();
                    //var utf8String = utf8.GetBytes(textBox1.Text);
                    //info.Value = utf8String;
                    info.Value = textBox1.Text;
                    context.B1.Add(info);
                    context.SaveChanges();
                    var result = context.B1.Where(x => x.Id == info.Id).SingleOrDefault();
                    //if (result != null)
                    //{
                    //    result.ValueString = Encoding.UTF8.GetString(result.Value);
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
