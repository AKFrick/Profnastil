namespace Profnastil
{
    partial class WCCGraph
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.zGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zGraph
            // 
            this.zGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zGraph.Location = new System.Drawing.Point(0, 0);
            this.zGraph.Name = "zGraph";
            this.zGraph.ScrollGrace = 0D;
            this.zGraph.ScrollMaxX = 0D;
            this.zGraph.ScrollMaxY = 0D;
            this.zGraph.ScrollMaxY2 = 0D;
            this.zGraph.ScrollMinX = 0D;
            this.zGraph.ScrollMinY = 0D;
            this.zGraph.ScrollMinY2 = 0D;
            this.zGraph.Size = new System.Drawing.Size(482, 334);
            this.zGraph.TabIndex = 0;
            // 
            // WCCGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zGraph);
            this.Name = "WCCGraph";
            this.Size = new System.Drawing.Size(482, 334);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zGraph;
    }
}
