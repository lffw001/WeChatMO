using System.Diagnostics;
using System.Reflection;

namespace YueHuan
{
    public partial class MainForm : Form
    {

        private readonly WeChatWin weChatWin;
        public MainForm()
        {
            InitializeComponent();
            weChatWin = new WeChatWin();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ��ȡ���򼯰汾��
            Assembly assembly = Assembly.GetEntryAssembly()!;
            Version assemblyVersion = assembly.GetName().Version!;
            Console.WriteLine("���򼯰汾��: " + assemblyVersion);

            // ��ȡ�ļ��汾��
            string filePath = Environment.ProcessPath!;
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(filePath);
            Version fileVer = new(fileVersion.FileVersion!);
            string version = $"{fileVer.Major}.{fileVer.Minor}.{fileVer.Build}.{fileVer.Revision}";
            // MessageBox.Show(version);

            string infoPath = Environment.ProcessPath!; // ��ȡ��ִ���ļ�·��
            FileInfo fileInfo = new(infoPath);

            // ��ȡ��Ŀ�汾�ţ��滻Ϊʵ�ʵİ汾�ţ�
            Version projectVersion = new();
            Console.WriteLine("��Ŀ�汾��: " + projectVersion);

            this.Text = $" ���΢�Ŷ࿪���� v{assemblyVersion}";

            VersionLabel.Text = $" {weChatWin.WechatVer.Last()}"; // ����֧�ְ汾

            PatchInfoLabel.Text = " ���΢�Ŷ࿪���Ʋ���";
            ReleaseLabel.Text = $" {fileInfo.LastWriteTime:yyyy-MM-dd}"; // fileInfo.LastAccessTime  # ����ʱ��  fileInfo.CreationTime   # �ļ�����ʱ��

            if (!string.IsNullOrEmpty(weChatWin.WeChatVersion))
            {
                LoggerListBox.Items.Add($"���߰汾��{version}");
                LoggerListBox.Items.Add($"��ǰ�汾��{weChatWin.WeChatVersion}");
                LoggerListBox.Items.Add($"��װ·����{weChatWin.WeChatPath}");
                // LoggerListBox.Items.Add("QQ����Ⱥ��913959002");
            }
            else
            {
                LoggerListBox.Items.Add($"���ĵ��Ի�δ��װPC ΢�ţ��뵽�����������°汾");
                PatchesButton.Enabled = false;
            }
            DownloadLinkLabel.Text = " ���԰�    ��ʽ��";
            DownloadLinkLabel.Links.Add(new LinkLabel.Link(1, 3, "https://www.redsonw.com/wechatwinbeta.html"));
            DownloadLinkLabel.Links.Add(new LinkLabel.Link(8, 12, "https://dldir1.qq.com/weixin/Windows/WeChatSetup.exe"));
        }

        private void DownloadLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link!.LinkData is string url)
            {
                WeChatWin.OpenURL(url);
            }
        }

        private void PatchesButton_Click(object sender, EventArgs e)
        {
            LimitRemover remover = new(weChatWin, LoggerListBox);
            remover.RemoveLimit();
        }
    }
}