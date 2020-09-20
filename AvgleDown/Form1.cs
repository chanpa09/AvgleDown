using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AvgleDown
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Disable form
            f_changeActive();

            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + @"\WorkFolder");

            // insert check
            if (!f_check())
            {
                // Active form
                f_changeActive();
                return;
            }

            // Make work folder(hidden)
            if (dir.Exists == false)
            {
                dir.Create();
                if (dir.Attributes != FileAttributes.Hidden) dir.Attributes = FileAttributes.Hidden;
            }

            try
            {
                // get and set path
                string l_path = f_makePath(g_url.Text);

                // down
                for (int i = 1; i <= 2000; i++)
                {
                    f_down(dir, l_path, i);
                }
            }
            catch
            {
                // make file & message result
                MessageBox.Show(f_makeFile(dir));
            }
            finally
            {
                // Active form
                f_changeActive();
            }

        }

        #region "f_down"
        private void f_down(DirectoryInfo dir, string l_path, int i)
        {
            try
            {
                WebClient wc = new WebClient();

                #region "set request head"
                // set head
                wc.Headers.Add("accept: */*");
                wc.Headers.Add("accept-encoding: gzip, deflate, br");
                wc.Headers.Add("accept-language: ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6");
                wc.Headers.Add("origin: https://avgle.com");
                wc.Headers.Add("sec-fetch-dest: empty");
                wc.Headers.Add("sec-fetch-mode: cors");
                wc.Headers.Add("sec-fetch-site: cross-site");
                wc.Headers.Add("user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36");
                #endregion

                string url = l_path + "/seg-" + i + "-v1-a1.ts";

                string down = dir.FullName + @"\download" + string.Format("{0:D4}", i) + ".ts";
                wc.DownloadFile(url, down);
            }
            catch(Exception err)
            {
                throw;
            }
        }
        #endregion

        #region "make file" 
        private string f_makeFile(DirectoryInfo dir)
        {
            try
            {
                // make file
                string[] inputFilePaths = Directory.GetFiles(dir.FullName, "download*.ts");
                using (var outputStream = File.Create(g_downPath.Text + @"\" + g_newName.Text + ".ts"))
                {
                    foreach (var inputFilePath in inputFilePaths)
                    {
                        using (var inputStream = File.OpenRead(inputFilePath))
                        {
                            inputStream.CopyTo(outputStream);
                        }
                        File.Delete(inputFilePath);
                    }
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }

            return "Finish!!";
        }
        #endregion

        #region "f_makePath：make url"
        /// <summary>
        /// url생성
        /// </summary>
        /// <param name="path">입력한 URL</param>
        /// <returns></returns>
        private string f_makePath(string path)
        {
            return path.Substring(0, path.LastIndexOf("mp4") + 3);
        }
        #endregion

        #region "f_changeActive"
        private void f_changeActive()
        {
            g_downPath.Enabled = g_downPath.Enabled.Equals(true) ? false : true;
            g_newName.Enabled = g_newName.Enabled.Equals(true) ? false : true;
            g_url.Enabled = g_url.Enabled.Equals(true) ? false : true;
            g_button1.Enabled = g_button1.Enabled.Equals(true) ? false : true;
        }
        #endregion

        #region "f_check：check"
        private Boolean f_check()
        {
            // Insert check
            if (g_url.Text.Trim() == "" || g_newName.Text.Trim() == "" || g_downPath.Text.Trim() == "")
            {
                MessageBox.Show("Insert path or new name");
                return false;
            }

            // Directory Check
            DirectoryInfo di = new DirectoryInfo(g_downPath.Text.Trim());
            if (!di.Exists)
            {
                MessageBox.Show("Down path does not exist");
                return false;
            }

            // URL check
            Uri uriResult;
            if (!Uri.TryCreate(g_url.Text.Trim(), UriKind.Absolute, out uriResult))
            {
                MessageBox.Show("Wrong URL");
                return false;
            }

            return true;
        }
        #endregion

    }
}
