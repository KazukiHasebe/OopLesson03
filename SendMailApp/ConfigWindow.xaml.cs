using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMailApp
{
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();

        }

        private void btDefault_Click(object sender, RoutedEventArgs e)
        {
            Config cf = (Config.GetInstance()).getDefaultStatus();

            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            cbSsl.IsChecked = cf.Ssl;
        }

        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            Config.GetInstance().UpdateStatus(
                tbSmtp.Text,
                tbSender.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false ); //更新処理を呼び出す
        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbSmtp.Text == "" || tbPort.Text == "" || tbPassWord.Password == "" ||
                tbSender.Text == "" || tbUserName.Text == "")
            {
                AlertMessage();
            }
            else
            {
                btApply_Click(sender, e);   //更新処理を呼び出す
                this.Close();
            }
        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            if (DataCheck())
            {
                AlertMessage();
            }
            else if (ComparisionData())
            {
                SaveMessage(sender, e);
            }
            else
            {
                this.Close();
            }
            
        }

        //設定画面
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config cf = (Config.GetInstance()).getStatus();

            tbSmtp.Text = cf.Smtp;
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            tbPort.Text = cf.Port.ToString();
            cbSsl.IsChecked = cf.Ssl;
        }

        private bool DataCheck()
        {
            if (tbSmtp.Text == "" || tbPort.Text == "" || tbPassWord.Password == "" ||
                tbSender.Text == "" || tbUserName.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AlertMessage()
        {
            System.Windows.Forms.MessageBox.Show
                    ("すべての項目を入力してください。", "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private bool ComparisionData()
        {
            Config cf = Config.GetInstance();
            if (cf.Smtp != tbSmtp.Text || cf.MailAddress != tbSender.Text || 
                cf.PassWord != tbPassWord.Password || cf.Port != int.Parse(tbPort.Text) ||
                cf.MailAddress != tbUserName.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveMessage(object sender, RoutedEventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("ファイルを上書きしますか？","質問",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                btApply_Click(sender, e);
                this.Close();
            }
            else if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                this.Close();
            }
        }
    }
}
