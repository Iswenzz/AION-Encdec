namespace AION.Encdec
{
    partial class Encdec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encdec));
            panel1 = new System.Windows.Forms.Panel();
            RepackButton = new System.Windows.Forms.Button();
            DecodeButton = new System.Windows.Forms.Button();
            UnpackButton = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            ListBox = new System.Windows.Forms.CheckedListBox();
            Info = new System.Windows.Forms.RichTextBox();
            SelectAllButton = new System.Windows.Forms.Button();
            panel4 = new System.Windows.Forms.Panel();
            ClearButton = new System.Windows.Forms.Button();
            RefreshButton = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(RepackButton);
            panel1.Controls.Add(DecodeButton);
            panel1.Controls.Add(UnpackButton);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(257, 664);
            panel1.TabIndex = 10;
            // 
            // RepackButton
            // 
            RepackButton.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            RepackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            RepackButton.Dock = System.Windows.Forms.DockStyle.Top;
            RepackButton.FlatAppearance.BorderSize = 0;
            RepackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            RepackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RepackButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            RepackButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            RepackButton.Location = new System.Drawing.Point(0, 130);
            RepackButton.Name = "RepackButton";
            RepackButton.Size = new System.Drawing.Size(257, 65);
            RepackButton.TabIndex = 2;
            RepackButton.Text = "Repack";
            RepackButton.UseVisualStyleBackColor = false;
            RepackButton.Click += RepackButton_Click;
            // 
            // DecodeButton
            // 
            DecodeButton.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            DecodeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            DecodeButton.Dock = System.Windows.Forms.DockStyle.Top;
            DecodeButton.FlatAppearance.BorderSize = 0;
            DecodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            DecodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            DecodeButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            DecodeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            DecodeButton.Location = new System.Drawing.Point(0, 65);
            DecodeButton.Name = "DecodeButton";
            DecodeButton.Size = new System.Drawing.Size(257, 65);
            DecodeButton.TabIndex = 3;
            DecodeButton.Text = "Decode";
            DecodeButton.UseVisualStyleBackColor = false;
            DecodeButton.Click += DecodeButton_Click;
            // 
            // UnpackButton
            // 
            UnpackButton.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            UnpackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            UnpackButton.Dock = System.Windows.Forms.DockStyle.Top;
            UnpackButton.FlatAppearance.BorderSize = 0;
            UnpackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            UnpackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UnpackButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            UnpackButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            UnpackButton.Location = new System.Drawing.Point(0, 0);
            UnpackButton.Name = "UnpackButton";
            UnpackButton.Size = new System.Drawing.Size(257, 65);
            UnpackButton.TabIndex = 0;
            UnpackButton.Text = "Extract";
            UnpackButton.UseVisualStyleBackColor = false;
            UnpackButton.Click += UnpackButton_Click;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(5, 5, 5);
            panel2.Controls.Add(ListBox);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(257, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1001, 130);
            panel2.TabIndex = 11;
            // 
            // ListBox
            // 
            ListBox.BackColor = System.Drawing.Color.FromArgb(5, 5, 5);
            ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ListBox.CheckOnClick = true;
            ListBox.ColumnWidth = 370;
            ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            ListBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            ListBox.ForeColor = System.Drawing.Color.Gainsboro;
            ListBox.FormattingEnabled = true;
            ListBox.HorizontalScrollbar = true;
            ListBox.Location = new System.Drawing.Point(0, 0);
            ListBox.MultiColumn = true;
            ListBox.Name = "ListBox";
            ListBox.Size = new System.Drawing.Size(1001, 130);
            ListBox.TabIndex = 0;
            ListBox.ThreeDCheckBoxes = true;
            ListBox.ItemCheck += ListBox_ItemCheck;
            // 
            // Info
            // 
            Info.BackColor = System.Drawing.Color.Black;
            Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            Info.Dock = System.Windows.Forms.DockStyle.Fill;
            Info.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Info.ForeColor = System.Drawing.Color.Gainsboro;
            Info.Location = new System.Drawing.Point(257, 154);
            Info.Margin = new System.Windows.Forms.Padding(4);
            Info.Name = "Info";
            Info.ReadOnly = true;
            Info.Size = new System.Drawing.Size(1001, 510);
            Info.TabIndex = 0;
            Info.Text = "";
            // 
            // SelectAllButton
            // 
            SelectAllButton.BackColor = System.Drawing.Color.Black;
            SelectAllButton.Cursor = System.Windows.Forms.Cursors.Hand;
            SelectAllButton.Dock = System.Windows.Forms.DockStyle.Left;
            SelectAllButton.FlatAppearance.BorderSize = 0;
            SelectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SelectAllButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            SelectAllButton.ForeColor = System.Drawing.Color.Gainsboro;
            SelectAllButton.Location = new System.Drawing.Point(81, 0);
            SelectAllButton.Name = "SelectAllButton";
            SelectAllButton.Size = new System.Drawing.Size(81, 24);
            SelectAllButton.TabIndex = 2;
            SelectAllButton.Text = "Select All";
            SelectAllButton.UseVisualStyleBackColor = false;
            SelectAllButton.Click += SelectAllButton_Click;
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.Color.Black;
            panel4.Controls.Add(ClearButton);
            panel4.Controls.Add(SelectAllButton);
            panel4.Controls.Add(RefreshButton);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(257, 130);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(1001, 24);
            panel4.TabIndex = 3;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = System.Drawing.Color.Black;
            ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            ClearButton.Dock = System.Windows.Forms.DockStyle.Right;
            ClearButton.FlatAppearance.BorderSize = 0;
            ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ClearButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            ClearButton.ForeColor = System.Drawing.Color.Gainsboro;
            ClearButton.Location = new System.Drawing.Point(920, 0);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new System.Drawing.Size(81, 24);
            ClearButton.TabIndex = 4;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Click += ClearButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = System.Drawing.Color.Black;
            RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            RefreshButton.Dock = System.Windows.Forms.DockStyle.Left;
            RefreshButton.FlatAppearance.BorderSize = 0;
            RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RefreshButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            RefreshButton.ForeColor = System.Drawing.Color.Gainsboro;
            RefreshButton.Location = new System.Drawing.Point(0, 0);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new System.Drawing.Size(81, 24);
            RefreshButton.TabIndex = 3;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // Encdec
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ClientSize = new System.Drawing.Size(1258, 664);
            Controls.Add(Info);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Encdec";
            Text = "AION Encdec";
            Load += Encdec_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RepackButton;
        private System.Windows.Forms.Button UnpackButton;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.CheckedListBox ListBox;
        private System.Windows.Forms.RichTextBox Info;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button DecodeButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button ClearButton;
    }
}

