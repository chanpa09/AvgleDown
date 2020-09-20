namespace AvgleDown
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.g_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.g_downPath = new System.Windows.Forms.TextBox();
            this.g_newName = new System.Windows.Forms.TextBox();
            this.g_button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // g_url
            // 
            this.g_url.Location = new System.Drawing.Point(113, 54);
            this.g_url.Name = "g_url";
            this.g_url.Size = new System.Drawing.Size(624, 19);
            this.g_url.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Url";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "NewName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "DownPath";
            // 
            // g_downPath
            // 
            this.g_downPath.Location = new System.Drawing.Point(113, 96);
            this.g_downPath.Name = "g_downPath";
            this.g_downPath.Size = new System.Drawing.Size(624, 19);
            this.g_downPath.TabIndex = 8;
            this.g_downPath.Text = "C:\\Users\\chanp\\Desktop\\test\\test";
            // 
            // g_newName
            // 
            this.g_newName.Location = new System.Drawing.Point(113, 139);
            this.g_newName.Name = "g_newName";
            this.g_newName.Size = new System.Drawing.Size(624, 19);
            this.g_newName.TabIndex = 9;
            // 
            // g_button1
            // 
            this.g_button1.Location = new System.Drawing.Point(662, 383);
            this.g_button1.Name = "g_button1";
            this.g_button1.Size = new System.Drawing.Size(75, 23);
            this.g_button1.TabIndex = 10;
            this.g_button1.Text = "Run";
            this.g_button1.UseVisualStyleBackColor = true;
            this.g_button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.g_button1);
            this.Controls.Add(this.g_newName);
            this.Controls.Add(this.g_downPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.g_url);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox g_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox g_downPath;
        private System.Windows.Forms.TextBox g_newName;
        private System.Windows.Forms.Button g_button1;
    }
}

