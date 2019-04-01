using Huanent.Printer.Models;
using PrintCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
namespace PrintTest
{

    public partial class MainForm : Form
    {
       

        private int BeforePrintCheck()
        {
            DialogResult dr;
            if (num1.Value==0 && num2.Value == 0 && num3.Value == 0 && num4.Value == 0 && num5.Value == 0) {
                dr = MessageBox.Show("至少需要一项物品数量不为0", "错误");
                return 1;
            }
            if (Title1.Text == "") {
                dr = MessageBox.Show("标题不能为空", "错误");
                return 1;
            }
            if ((num1.Value != 0&&item1.Text=="")|| (num2.Value != 0 && item2.Text == "") || (num3.Value != 0 && item3.Text == "") || (num4.Value != 0 && item4.Text == "") || (num5.Value != 0 && item5.Text == "")) {
                dr = MessageBox.Show("数量不为0的物品必须填写名称", "错误");
                return 1;
            }
            return 0;

        }
        /// <summary>
        /// 从xml中读取列排序 ，并设置界面列顺序
        /// </summary>
        private void LoadXML()
        {
            DialogResult dr;
            XmlDocument doc = new XmlDocument();
            string fileName = @"./Save.xml";
            //判断文件是否存在
            if (!System.IO.File.Exists(fileName))
            {
                dr = MessageBox.Show("配置文件不存在", "错误");
                return;
            }
            doc.Load(fileName);

            XDocument xmldoc = XDocument.Load(fileName);
            var xtitle = xmldoc.Descendants("Title");
            foreach (var a in xtitle)

            {
                Title1.Text = a.Value+"";
            }
            var xuser = xmldoc.Descendants("User");
            foreach (var a in xuser)

            {
                User.Text = a.Value + "";
            }
            var xend = xmldoc.Descendants("End");
            foreach (var a in xend)

            {
                EndText.Text = a.Value + "";
            }
            var xitem1 = xmldoc.Descendants("Item1");
            foreach (var a in xitem1)
            {
                item1.Text = a.Attribute("name").Value + "";
                up1.Value = int.Parse(a.Attribute("up").Value);
                num1.Value = int.Parse(a.Attribute("num").Value);

            }

            var xitem2 = xmldoc.Descendants("Item2");
            foreach (var a in xitem2)
            {
                item2.Text = a.Attribute("name").Value + "";
                up2.Value = int.Parse(a.Attribute("up").Value);
                num2.Value = int.Parse(a.Attribute("num").Value);

            }

            var xitem3 = xmldoc.Descendants("Item3");
            foreach (var a in xitem3)
            {
                item3.Text = a.Attribute("name").Value + "";
                up3.Value = int.Parse(a.Attribute("up").Value);
                num3.Value = int.Parse(a.Attribute("num").Value);

            }

            var xitem4 = xmldoc.Descendants("Item4");
            foreach (var a in xitem4)
            {
                item4.Text = a.Attribute("name").Value + "";
                up4.Value = int.Parse(a.Attribute("up").Value);
                num4.Value = int.Parse(a.Attribute("num").Value);

            }

            var xitem5 = xmldoc.Descendants("Item5");
            foreach (var a in xitem5)
            {
                item5.Text = a.Attribute("name").Value + "";
                up5.Value = int.Parse(a.Attribute("up").Value);
                num5.Value = int.Parse(a.Attribute("num").Value);

            }


            price1.Text = (up1.Value * num1.Value).ToString();
            price2.Text = (up2.Value * num2.Value).ToString();
            price3.Text = (up3.Value * num3.Value).ToString();
            price4.Text = (up4.Value * num4.Value).ToString();
            price5.Text = (up5.Value * num5.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();

        }

        private void SaveXML() {
            //创建XmlDocument对象xmlDoc  
            XmlDocument xmlDoc = new XmlDocument();
            //创建并添加ColumnsSort结点  
            XmlElement root = xmlDoc.CreateElement("Main");
            XmlElement title = xmlDoc.CreateElement("Title");
            title.InnerText = Title1.Text;
            root.AppendChild(title);

            XmlElement username = xmlDoc.CreateElement("User");
            username.InnerText = User.Text;
            root.AppendChild(username);

            XmlElement Xitem1 = xmlDoc.CreateElement("Item1");
            Xitem1.SetAttribute("name", item1.Text);
            Xitem1.SetAttribute("up", up1.Text);
            Xitem1.SetAttribute("num", num1.Text);
            root.AppendChild(Xitem1);

            XmlElement Xitem2 = xmlDoc.CreateElement("Item2");
            Xitem2.SetAttribute("name", item2.Text);
            Xitem2.SetAttribute("up", up2.Text);
            Xitem2.SetAttribute("num", num2.Text);
            root.AppendChild(Xitem2);

            XmlElement Xitem3 = xmlDoc.CreateElement("Item3");
            Xitem3.SetAttribute("name", item3.Text);
            Xitem3.SetAttribute("up", up3.Text);
            Xitem3.SetAttribute("num", num3.Text);
            root.AppendChild(Xitem3);

            XmlElement Xitem4 = xmlDoc.CreateElement("Item4");
            Xitem4.SetAttribute("name", item4.Text);
            Xitem4.SetAttribute("up", up4.Text);
            Xitem4.SetAttribute("num", num4.Text);
            root.AppendChild(Xitem4);
            
            XmlElement Xitem5 = xmlDoc.CreateElement("Item5");
            Xitem5.SetAttribute("name", item5.Text);
            Xitem5.SetAttribute("up", up5.Text);
            Xitem5.SetAttribute("num", num5.Text);
            root.AppendChild(Xitem5);

            XmlElement Xendtext = xmlDoc.CreateElement("End");
            Xendtext.InnerText = EndText.Text;
            root.AppendChild(Xendtext);
            xmlDoc.AppendChild(root);

            //通过Save()方法保存数据到XML文件UserList.XML中  @"../Release/file/ColumnsSort.xml"
            xmlDoc.Save(@"./Save.xml");   // 保存文件

        }


        private void up1_ValueChanged(object sender, EventArgs e)
        {
            price1.Text = (up1.Value * num1.Value).ToString();
            tp.Text = (int.Parse(price1.Text)+ int.Parse(price2.Text)+ int.Parse(price3.Text)+ int.Parse(price4.Text)+ int.Parse(price5.Text)).ToString();
        }

        private void up2_ValueChanged(object sender, EventArgs e)
        {
            price2.Text = (up2.Value * num2.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }

        private void up3_ValueChanged(object sender, EventArgs e)
        {
            price3.Text = (up3.Value * num3.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }

        private void up4_ValueChanged(object sender, EventArgs e)
        {
            price4.Text = (up4.Value * num4.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }
        private void up5_ValueChanged(object sender, EventArgs e)
        {
            price5.Text = (up5.Value * num5.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }
        private void num1_ValueChanged(object sender, EventArgs e)
        {
            price1.Text = (up1.Value * num1.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }

        private void num2_ValueChanged(object sender, EventArgs e)
        {
            price2.Text = (up2.Value * num2.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }

        private void num3_ValueChanged(object sender, EventArgs e)
        {
            price3.Text = (up3.Value * num3.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }

        private void num4_ValueChanged(object sender, EventArgs e)
        {
            price4.Text = (up4.Value * num4.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }

        private void num5_ValueChanged(object sender, EventArgs e)
        {
            price5.Text = (up5.Value * num5.Value).ToString();
            tp.Text = (int.Parse(price1.Text) + int.Parse(price2.Text) + int.Parse(price3.Text) + int.Parse(price4.Text) + int.Parse(price5.Text)).ToString();
        }






        public MainForm()
        {
            InitializeComponent();
            label14.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BeforePrintCheck() == 0) {
                stert_Print();
            }
            
        }

        public void stert_Print() {
            int item = 0;
            var printer = PrinterFactory.GetPrinter("XP-58", PaperWidth.Paper58mm);
            PrintQueueHelper.GetPrintQueueName();
            printer.NewRow();
            printer.NewRow();
            printer.PrintText(Title1.Text, FontSize.Huge, StringAlignment.Center);
            printer.NewRow();
            printer.NewRow();

            if (User.Text != "") {
                printer.NewRow();
                printer.PrintText(User.Text);
                printer.NewRow();
            }
            
            printer.PrintLine();
            printer.NewRow();
            printer.PrintText("商品");
            printer.PrintText("单价", offset: 0.35f);
            printer.PrintText("数量", offset: 0.65f);
            printer.PrintText("总价", stringAlignment: StringAlignment.Far);
            printer.NewRow();
            printer.PrintLine();

            if (num1.Value != 0) {
                printer.NewRow();
                printer.PrintText(item1.Text, width: 0.35f);
                printer.PrintText(up1.Value.ToString(), width: 0.2f, offset: 0.35f);
                printer.PrintText(num1.Value.ToString(), width: 0.2f, offset: 0.65F);
                printer.PrintText(price1.Text, stringAlignment: StringAlignment.Far);
                printer.NewRow();
                item++;
            }

            if (num2.Value != 0)
            {
                printer.NewRow();
                printer.PrintText(item2.Text, width: 0.35f);
                printer.PrintText(up2.Value.ToString(), width: 0.2f, offset: 0.35f);
                printer.PrintText(num2.Value.ToString(), width: 0.2f, offset: 0.65F);
                printer.PrintText(price2.Text, stringAlignment: StringAlignment.Far);
                printer.NewRow();
                item++;
            }
            if (num3.Value != 0)
            {
                printer.NewRow();
                printer.PrintText(item3.Text, width: 0.35f);
                printer.PrintText(up3.Value.ToString(), width: 0.2f, offset: 0.35f);
                printer.PrintText(num3.Value.ToString(), width: 0.2f, offset: 0.65F);
                printer.PrintText(price3.Text, stringAlignment: StringAlignment.Far);
                printer.NewRow();
                item++;
            }
            if (num4.Value != 0)
            {
                printer.NewRow();
                printer.PrintText(item4.Text, width: 0.35f);
                printer.PrintText(up4.Value.ToString(), width: 0.2f, offset: 0.35f);
                printer.PrintText(num4.Value.ToString(), width: 0.2f, offset: 0.65F);
                printer.PrintText(price4.Text, stringAlignment: StringAlignment.Far);
                printer.NewRow();
                item++;
            }
            if (num5.Value != 0)
            {
                printer.NewRow();
                printer.PrintText(item5.Text, width: 0.35f);
                printer.PrintText(up5.Value.ToString(), width: 0.2f, offset: 0.35f);
                printer.PrintText(num5.Value.ToString(), width: 0.2f, offset: 0.65F);
                printer.PrintText(price5.Text, stringAlignment: StringAlignment.Far);
                printer.NewRow();
                item++;
            }

            while ( item < 5)
            {
                printer.NewRow();
                printer.NewRow();
                printer.NewRow();
                printer.NewRow();
                item++;
            }


            printer.PrintLine();
            printer.NewRow();
            printer.PrintText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), stringAlignment: StringAlignment.Near);
            printer.NewRow();
            printer.PrintText(EndText.Text, stringAlignment: StringAlignment.Near);
            printer.PrintText("合计: "+tp.Text, stringAlignment: StringAlignment.Far);
            printer.NewRow();
            printer.Finish();

            RawPrinterHelper.SendStringToPrinter("XP-58", Convert.ToString((char)29) + "V" + (char)1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (BeforePrintCheck() == 0)
            {
                SaveXML();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadXML();
        }
    }


}
