using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
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

namespace SendMailApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        SmtpClient sc = new SmtpClient();

        public MainWindow()
        {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        //設定画面表示
        private static void ConfigWindowShow()
        {
            ConfigWindow configWindow = new ConfigWindow(); //設定画面のインスタンスを生成
            configWindow.ShowDialog();  //表示
        }

        //送信完了イベント
        private void Sc_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("送信はキャンセルされました。");
            }
            else
            {
                MessageBox.Show(e.Error?.Message ?? "送信完了！");
            }
        }

        //メール送信処理
        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Config cf = Config.GetInstance();
                MailMessage msg = new MailMessage(cf.MailAddress, tbTo.Text, tbTitle.Text, tbBody.Text);

                if (tbCc.Text != "")
                {
                    msg.CC.Add(tbCc.Text);
                }
                if (tbBcc.Text != "")
                {
                    msg.Bcc.Add(tbBcc.Text);
                }

                sc.Host = cf.Smtp; //SMTPサーバの設定
                sc.Port = cf.Port;
                sc.EnableSsl = cf.Ssl;
                sc.Credentials = new NetworkCredential(cf.MailAddress, cf.PassWord);

                //sc.Send(msg);   //送信
                sc.SendMailAsync(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //送信キャンセル処理
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            if (sc != null)
            {
                sc.SendAsyncCancel();
            }
        }

        //設定ボタンイベントハンドラ
        private void btConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindowShow();
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Config.GetInstance().DeSerialise();
            }
            catch (FileNotFoundException)
            {
                ConfigWindowShow(); //ファイルが存在しないので設定画面を先に表示
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Config.GetInstance().Serialise();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
