using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using ConnectionCenter;

namespace CityPlanning
{
    public partial class frmStartConnectionConfig : DevExpress.XtraEditors.XtraForm
    {
        //INI配置文件
        private string FTPSection = "FTP";
        private string FTPIP = "ip";
        private string FTPUser = "user";
        private string FTPPsd = "pass";
        private string FTPCatalog = "catalog";

        private string DBSection = "Database";
        private string DBIP = "ip";
        private string DBCatalog = "catalog";
        private string DBUser = "user";
        private string DBPsd = "pass";

        private string UserSection = "User";
        private string UserName = "name";
        private string UserPsd = "pass";

        //渐变步长
        private double OPACITY_STEP1 = 0.02;
        private double OPACITY_STEP2 = 0.06;
        private double OPACITY_STEP3 = 0.1;
        //渐变等级，先慢，后快
        private double OPACITY_LEVEL1 = 0.3;
        private double OPACITY_LEVEL2 = 0.6;
        private MainForm mainFrm;

        public frmStartConnectionConfig(MainForm _MainForm)
        {
            InitializeComponent();
            mainFrm = _MainForm;
        }
        //窗体打开
        private void frmStartConnectionConfig_Load(object sender, EventArgs e)
        {
            this.Refresh();
            if (mainFrm != null)
            {
                mainFrm.Opacity = 0;
            }
            else
            {
                this.panelControl1.Visible = !this.panelControl1.Visible;
            }
            //初始化配置信息
            InitConfig();
        }
        private void InitConfig()
        {
            //FTP
            this.txt_ftpIP.Text = ConnectionCenter.INIFile.IniReadValue(FTPSection, FTPIP);
            this.txt_ftpUserName.Text = ConnectionCenter.INIFile.IniReadValue(FTPSection, FTPUser);
            this.txt_ftpPassword.Text = ConnectionCenter.INIFile.IniReadValue(FTPSection, FTPPsd);
            this.txt_ftpCatalog.Text = ConnectionCenter.INIFile.IniReadValue(FTPSection, FTPCatalog);
            //数据库            
            this.txt_DBServerName.Text = ConnectionCenter.INIFile.IniReadValue(DBSection, DBIP);
            this.txt_DBCatalogName.Text = ConnectionCenter.INIFile.IniReadValue(DBSection, DBCatalog);
            this.txt_DBUserName.Text = ConnectionCenter.INIFile.IniReadValue(DBSection, DBUser);
            this.txt_DBPassword.Text = ConnectionCenter.INIFile.IniReadValue(DBSection, DBPsd);
            //用户
            this.txt_SysUserName.Text = ConnectionCenter.INIFile.IniReadValue(UserSection, UserName);
            this.txt_SysPassword.Text = ConnectionCenter.INIFile.IniReadValue(UserSection, this.txt_SysUserName.Text);
        }

        //窗体关闭
        private void frmStartConnectionConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.timer1.Stop();
            //如果点击取消按钮，则mainFrm已经被释放
            if (mainFrm != null)
            {
                if (!mainFrm.IsDisposed)
                {
                    mainFrm.Opacity = 1;
                }
            }
        }

        //登录按钮
        private void btn_Login_Click(object sender, EventArgs e)
        {
            //FTP
            FTPConnection.FtpIP = this.txt_ftpIP.Text.Trim();
            FTPConnection.FtpUserName = this.txt_ftpUserName.Text.Trim();
            FTPConnection.FtpPassword = this.txt_ftpPassword.Text.Trim();
            FTPConnection.FtpCatalog = this.txt_ftpCatalog.Text.Trim();
            ConnectionCenter.INIFile.IniWriteValue(FTPSection, FTPIP, FTPConnection.FtpIP);
            ConnectionCenter.INIFile.IniWriteValue(FTPSection, FTPUser, FTPConnection.FtpUserName);
            ConnectionCenter.INIFile.IniWriteValue(FTPSection, FTPPsd, FTPConnection.FtpPassword);
            ConnectionCenter.INIFile.IniWriteValue(FTPSection, FTPCatalog, FTPConnection.FtpCatalog);
            //数据库            
            SQLServerConnection.DBServerName = this.txt_DBServerName.Text.Trim();
            SQLServerConnection.DbCatalogName = this.txt_DBCatalogName.Text.Trim();
            SQLServerConnection.DBUserName = this.txt_DBUserName.Text.Trim();
            SQLServerConnection.DBPassword = this.txt_DBPassword.Text.Trim();
            ConnectionCenter.INIFile.IniWriteValue(DBSection, DBIP, SQLServerConnection.DBServerName);
            ConnectionCenter.INIFile.IniWriteValue(DBSection, DBCatalog, SQLServerConnection.DbCatalogName);
            ConnectionCenter.INIFile.IniWriteValue(DBSection, DBUser, SQLServerConnection.DBUserName);
            ConnectionCenter.INIFile.IniWriteValue(DBSection, DBPsd, SQLServerConnection.DBPassword);
            //用户
            UserManager.SysUserName = this.txt_SysUserName.Text.Trim();
            UserManager.SysPassword = this.txt_SysPassword.Text.Trim();
            ConnectionCenter.INIFile.IniWriteValue(UserSection, UserName, UserManager.SysUserName);
            

            //用户验证
            string userPass = ConnectionCenter.INIFile.IniReadValue(UserSection, UserManager.SysUserName);
            if(userPass == UserManager.SysPassword)
            {
                ConnectionCenter.INIFile.IniWriteValue(UserSection, UserManager.SysUserName, UserManager.SysPassword);
            }
            else
            {
                MessageBox.Show("用户密码错误，请重新输入","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            
            if (mainFrm != null)
            {
                //测试时，取消渐变
                //this.timer1.Interval = 100;
                //this.timer1.Start();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        //取消按钮
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (mainFrm != null)
            {
                mainFrm.Close();
            }
        }
        //配置连接
        private void btn_ConfigConnections_Click(object sender, EventArgs e)
        {
            this.panelControl1.Visible = !this.panelControl1.Visible;
        }
        //渐变的timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Opacity >= OPACITY_LEVEL1)
                {
                    this.Opacity -= OPACITY_STEP1;
                }
                else if (this.Opacity < OPACITY_LEVEL2 && this.Opacity >= OPACITY_LEVEL1 && this.Opacity >= OPACITY_STEP2)
                {
                    this.Opacity -= OPACITY_STEP2;
                }
                else if (this.Opacity < OPACITY_LEVEL1 && this.Opacity >= OPACITY_STEP3)
                {
                    this.Opacity -= OPACITY_STEP3;
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {

            }
        }
    }
}