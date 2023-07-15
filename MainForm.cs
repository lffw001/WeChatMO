using System.Diagnostics;
using System.Reflection;
using WeChatMultiOpen;
using YueHuan;

namespace RemoveMulti
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
            DownloadLinkLabel.Text = " ���²��԰�    �������°�";
            DownloadLinkLabel.Links.Add(new LinkLabel.Link(1, 5, "https://www.redsonw.com/pc/commsocial/wechatwin.html"));
            DownloadLinkLabel.Links.Add(new LinkLabel.Link(10, 15, "https://dldir1.qq.com/weixin/Windows/WeChatSetup.exe"));
        }

        private void DownloadLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // DownloadLinkLabel.Links[0].LinkData = DownloadLinkLabel.Text;
            // DownloadLinkLabel.LinkVisited = true;
            if (e.Link!.LinkData is string url)
            {
                WeChatWin.OpenURL(url);
            }
        }

        private void PatchesButton_Click(object sender, EventArgs e)
        {

            string fileName = "WeChatWin.dll";
            string filePath = Path.Combine(weChatWin.WeChatPath, $"[{weChatWin.WeChatVersion}]", fileName);

            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            string? version = fileVersionInfo.FileVersion;

            if (!weChatWin.CheckVersion())
            {
                LoggerListBox.Items.Add($"��ǰ�汾��[{version}] ��֧�ֽ�����ƣ������Ȱ�װ΢�� [{weChatWin.WechatVer[0]}] �����ϰ汾");
                return;
            }

            string backFile = Path.Combine(filePath, ".bak");

            if (File.Exists(backFile))
            {
                DialogResult result = MessageBox.Show("�����ļ��Ѿ����ڣ��Ƿ�������ݣ�ѡ���ǡ���������ݣ�ѡ�񡰷����������ݡ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (!weChatWin.Backup())
                    {
                        LoggerListBox.Items.Add($"���ݳɹ���{backFile}");
                    }
                }
            }
            else
            {
                LoggerListBox.Items.Add($"�����Ѵ��ڣ�{backFile}");
            }

            string chatName = "WeChat";
            Process[] processes = Process.GetProcessesByName(chatName);
            if (processes.Length > 0)
            {
                DialogResult result = MessageBox.Show("΢���Ѿ����У��Ƿ�Ҫ����������ƣ�ѡ���ǡ��ر�΢�ż�����ѡ�񡰷������������ơ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (Process process in processes)
                    {
                        process.Kill();
                        LoggerListBox.Items.Add("���ڹر�΢�ţ����Ժ�...");
                        Thread.Sleep(500);
                        LoggerListBox.Items.Add("΢���Ѿ����ر�");
                    }
                }
                else
                {
                    LoggerListBox.Items.Add("�����������");
                }
            }

            LoggerListBox.Items.Add($"��ʼ��ʮ������ƫ����...");
            (long offset, byte oldValue, byte newValue) values = version switch
            {
                "3.9.5.65" => (0x01CDFBD8, 0x85, 0x33),
                "3.9.5.73" => (0x01CE1C38, 0x85, 0x33),
                "3.9.5.81" => (0x01CE15A8, 0x85, 0x33),
                "3.9.5.91" => (0x01CE2E28, 0x85, 0x33),
                "3.9.6.22" => (0X01CCE808, 0x85, 0x31),
                _ => throw new ArgumentException($"��ǰ�汾��[{version}] ��֧�ֽ�����ƣ������Ȱ�װ΢�� [{weChatWin.WechatVer[0]}] �����ϰ汾")
            };
            long offset = values.offset;        // ƫ������ʮ�����Ʊ�ʾ 
            byte oldValue = values.oldValue;    // ԭʼ�ֽ�����
            byte newValue = values.newValue;    // �µ��ֽ�����

            LoggerListBox.Items.Add($"��ʼ��[ {version} ]ʮ������ƫ�������...");

            try
            {
                LoggerListBox.Items.Add("��ʼ�����ļ�");
                using FileStream fs = new(filePath, FileMode.Open, FileAccess.ReadWrite);
                fs.Seek(offset, SeekOrigin.Begin);
                LoggerListBox.Items.Add($"����ɹ�:{filePath}");

                byte currentValue = (byte)fs.ReadByte();        // ��ȡָ��λ�õ��ֽ�����
                LoggerListBox.Items.Add("��ȡԭʼ����...");

                if (currentValue == oldValue)
                {
                    // ���ļ�����λ����������Ϊָ����ƫ����
                    fs.Seek(offset, SeekOrigin.Begin);
                    LoggerListBox.Items.Add($"�����ļ����׼����ʼ�滻����...");

                    // д���µ��ֽ�����
                    fs.WriteByte(newValue);
                    LoggerListBox.Items.Add($"�޸�{fileName} ���");

                    // ˢ���ļ�����ȷ������д���ļ�
                    fs.Flush();
                    LoggerListBox.Items.Add("���˫�����Ʋ������");
                }
                else
                {
                    LoggerListBox.Items.Add("δ�ҵ�ָ��λ�õ��ֽ����ݻ������ѱ��޸ģ�");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                // LoggerListBox.Items.Add("�ļ��޸ĳ��ִ���" + ex.Message);
            }
            finally
            {
                LoggerListBox.SelectedIndex = LoggerListBox.Items.Count - 1;
                LoggerListBox.ClearSelected();
                LoggerListBox.TopIndex = LoggerListBox.Items.Count - 1;
            }
        }

        private void AboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // MessageBox.Show("΢��");
            // �����½��̲��򿪹��ڴ���
            AboutForm aboutForm = new();
            aboutForm.ShowDialog();
        }
    }
}