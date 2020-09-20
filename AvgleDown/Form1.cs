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
            if(f_path.Text.Trim() == "" || f_newName.Text.Trim() == "" || f_downPath.Text.Trim() == "")
            {
                MessageBox.Show("Insert path or new name");
            }
            else
            {
                string l_path = f_path.Text;

                // get path
                l_path = f_makePath(l_path);

                button1.Enabled = false;

                try
                {
                    // down
                    using (WebClient wc = new WebClient())
                    {
                        // set head
                        wc.Headers.Add("accept: */*");
                        wc.Headers.Add("accept-encoding: gzip, deflate, br");
                        wc.Headers.Add("accept-language: ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6");
                        wc.Headers.Add("origin: https://avgle.com");
                        wc.Headers.Add("sec-fetch-dest: empty");
                        wc.Headers.Add("sec-fetch-mode: cors");
                        wc.Headers.Add("sec-fetch-site: cross-site");
                        wc.Headers.Add("user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36");

                        for (int i = 1; i <= int.MaxValue; i++)
                        {
                            string url = l_path + "/seg-" + i + "-v1-a1.ts";
                            string down = f_downPath.Text + @"\download" + string.Format("{0:D4}", i) + ".ts";
                            wc.DownloadFile(url, down);
                        }
                    }
                }
                catch 
                {
                    // make file
                    string[] inputFilePaths = Directory.GetFiles(f_downPath.Text, "download*.ts");
                    Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
                    using (var outputStream = File.Create(f_downPath.Text + @"\" + f_newName.Text + ".ts"))
                    {
                        foreach (var inputFilePath in inputFilePaths)
                        {
                            using (var inputStream = File.OpenRead(inputFilePath))
                            {
                                // Buffer size can be passed as the second argument.
                                inputStream.CopyTo(outputStream);
                            }
                            File.Delete(inputFilePath);
                        }
                    }
                    MessageBox.Show("Finish!!");
                }
                finally
                {
                    // 
                    button1.Enabled = true;
                }
            }
        }

        #region "f_makePath：url생성"
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

    }
}
