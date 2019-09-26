namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddPP = new System.Windows.Forms.Button();
            this.btnRemoveC = new System.Windows.Forms.Button();
            this.labXY = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.btnDrawC = new System.Windows.Forms.Button();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.wccGraph1 = new Profnastil.WCCGraph();
            this.tbCN = new System.Windows.Forms.TextBox();
            this.tbPullCN = new System.Windows.Forms.TextBox();
            this.tbPullInd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddPP
            // 
            this.btnAddPP.Location = new System.Drawing.Point(12, 343);
            this.btnAddPP.Name = "btnAddPP";
            this.btnAddPP.Size = new System.Drawing.Size(75, 23);
            this.btnAddPP.TabIndex = 5;
            this.btnAddPP.Text = "AddPP";
            this.btnAddPP.UseVisualStyleBackColor = true;
            this.btnAddPP.Click += new System.EventHandler(this.btnAddPP_Click);
            // 
            // btnRemoveC
            // 
            this.btnRemoveC.Location = new System.Drawing.Point(12, 401);
            this.btnRemoveC.Name = "btnRemoveC";
            this.btnRemoveC.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveC.TabIndex = 6;
            this.btnRemoveC.Text = "RemoveCurve";
            this.btnRemoveC.UseVisualStyleBackColor = true;
            this.btnRemoveC.Click += new System.EventHandler(this.btnRemoveC_Click);
            // 
            // labXY
            // 
            this.labXY.AutoSize = true;
            this.labXY.Location = new System.Drawing.Point(463, 406);
            this.labXY.Name = "labXY";
            this.labXY.Size = new System.Drawing.Size(35, 13);
            this.labXY.TabIndex = 7;
            this.labXY.Text = "label1";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(273, 401);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "PullPP";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnDrawC
            // 
            this.btnDrawC.Location = new System.Drawing.Point(12, 372);
            this.btnDrawC.Name = "btnDrawC";
            this.btnDrawC.Size = new System.Drawing.Size(75, 23);
            this.btnDrawC.TabIndex = 9;
            this.btnDrawC.Text = "DrawCurve";
            this.btnDrawC.UseVisualStyleBackColor = true;
            this.btnDrawC.Click += new System.EventHandler(this.btnDrawC_Click);
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(94, 343);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(36, 20);
            this.tbX.TabIndex = 10;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(136, 343);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(36, 20);
            this.tbY.TabIndex = 11;
            // 
            // wccGraph1
            // 
            this.wccGraph1.Dock = System.Windows.Forms.DockStyle.Top;
            this.wccGraph1.Location = new System.Drawing.Point(0, 0);
            this.wccGraph1.Name = "wccGraph1";
            this.wccGraph1.Size = new System.Drawing.Size(563, 334);
            this.wccGraph1.TabIndex = 0;
            // 
            // tbCN
            // 
            this.tbCN.Location = new System.Drawing.Point(178, 343);
            this.tbCN.Name = "tbCN";
            this.tbCN.Size = new System.Drawing.Size(36, 20);
            this.tbCN.TabIndex = 12;
            // 
            // tbPullCN
            // 
            this.tbPullCN.Location = new System.Drawing.Point(354, 403);
            this.tbPullCN.Name = "tbPullCN";
            this.tbPullCN.Size = new System.Drawing.Size(36, 20);
            this.tbPullCN.TabIndex = 13;
            // 
            // tbPullInd
            // 
            this.tbPullInd.Location = new System.Drawing.Point(396, 403);
            this.tbPullInd.Name = "tbPullInd";
            this.tbPullInd.Size = new System.Drawing.Size(36, 20);
            this.tbPullInd.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "SetTit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbPullInd);
            this.Controls.Add(this.tbPullCN);
            this.Controls.Add(this.tbCN);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.btnDrawC);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.labXY);
            this.Controls.Add(this.btnRemoveC);
            this.Controls.Add(this.btnAddPP);
            this.Controls.Add(this.wccGraph1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Profnastil.WCCGraph wccGraph1;
        private System.Windows.Forms.Button btnAddPP;
        private System.Windows.Forms.Button btnRemoveC;
        private System.Windows.Forms.Label labXY;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnDrawC;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbCN;
        private System.Windows.Forms.TextBox tbPullCN;
        private System.Windows.Forms.TextBox tbPullInd;
        private System.Windows.Forms.Button button1;
    }
}

