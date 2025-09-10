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
            RepackButton = new IzUI.WinForms.UI.Controls.Inputs.Button();
            DecodeButton = new IzUI.WinForms.UI.Controls.Inputs.Button();
            UnpackButton = new IzUI.WinForms.UI.Controls.Inputs.Button();
            panel2 = new System.Windows.Forms.Panel();
            ListBox = new System.Windows.Forms.CheckedListBox();
            Info = new System.Windows.Forms.RichTextBox();
            SelectAllButton = new IzUI.WinForms.UI.Controls.Inputs.Button();
            panel4 = new System.Windows.Forms.Panel();
            RefreshButton = new IzUI.WinForms.UI.Controls.Inputs.Button();
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
            RepackButton.Alpha.Enabled = true;
            RepackButton.Animations.BackgroundImageHover = null;
            RepackButton.Animations.ColorHover = System.Drawing.Color.RoyalBlue;
            RepackButton.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            RepackButton.Animations.Enabled = true;
            RepackButton.Animations.TextColorHover = System.Drawing.Color.Empty;
            RepackButton.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            RepackButton.Border.Color = System.Drawing.Color.DodgerBlue;
            RepackButton.Border.Enabled = true;
            RepackButton.Border.Radius = new System.Drawing.Size(0, 0);
            RepackButton.Border.Width = 4F;
            RepackButton.Dock = System.Windows.Forms.DockStyle.Top;
            RepackButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            RepackButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            RepackButton.Icon.Enabled = true;
            RepackButton.Icon.IconImage = null;
            RepackButton.Icon.IconSize = 0;
            RepackButton.Layouts.Angle = 0;
            RepackButton.Layouts.Enabled = true;
            RepackButton.Location = new System.Drawing.Point(0, 130);
            RepackButton.Name = "RepackButton";
            RepackButton.Size = new System.Drawing.Size(257, 65);
            RepackButton.TabIndex = 2;
            RepackButton.Text = "Repack";
            RepackButton.TextLayouts.Angle = 0;
            RepackButton.TextLayouts.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RepackButton.TextLayouts.Enabled = true;
            RepackButton.Click += RepackButton_Click;
            // 
            // DecodeButton
            // 
            DecodeButton.Alpha.Enabled = true;
            DecodeButton.Animations.BackgroundImageHover = null;
            DecodeButton.Animations.ColorHover = System.Drawing.Color.RoyalBlue;
            DecodeButton.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            DecodeButton.Animations.Enabled = true;
            DecodeButton.Animations.TextColorHover = System.Drawing.Color.Empty;
            DecodeButton.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            DecodeButton.Border.Color = System.Drawing.Color.DodgerBlue;
            DecodeButton.Border.Enabled = true;
            DecodeButton.Border.Radius = new System.Drawing.Size(0, 0);
            DecodeButton.Border.Width = 4F;
            DecodeButton.Dock = System.Windows.Forms.DockStyle.Top;
            DecodeButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            DecodeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            DecodeButton.Icon.Enabled = true;
            DecodeButton.Icon.IconImage = null;
            DecodeButton.Icon.IconSize = 0;
            DecodeButton.Layouts.Angle = 0;
            DecodeButton.Layouts.Enabled = true;
            DecodeButton.Location = new System.Drawing.Point(0, 65);
            DecodeButton.Name = "DecodeButton";
            DecodeButton.Size = new System.Drawing.Size(257, 65);
            DecodeButton.TabIndex = 3;
            DecodeButton.Text = "Decode";
            DecodeButton.TextLayouts.Angle = 0;
            DecodeButton.TextLayouts.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DecodeButton.TextLayouts.Enabled = true;
            DecodeButton.Click += DecodeButton_Click;
            // 
            // UnpackButton
            // 
            UnpackButton.Alpha.Enabled = true;
            UnpackButton.Animations.BackgroundImageHover = null;
            UnpackButton.Animations.ColorHover = System.Drawing.Color.RoyalBlue;
            UnpackButton.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            UnpackButton.Animations.Enabled = true;
            UnpackButton.Animations.TextColorHover = System.Drawing.Color.Empty;
            UnpackButton.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            UnpackButton.Border.Color = System.Drawing.Color.DodgerBlue;
            UnpackButton.Border.Enabled = true;
            UnpackButton.Border.Radius = new System.Drawing.Size(0, 0);
            UnpackButton.Border.Width = 4F;
            UnpackButton.Dock = System.Windows.Forms.DockStyle.Top;
            UnpackButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            UnpackButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            UnpackButton.Icon.Enabled = true;
            UnpackButton.Icon.IconImage = null;
            UnpackButton.Icon.IconSize = 0;
            UnpackButton.Layouts.Angle = 0;
            UnpackButton.Layouts.Enabled = true;
            UnpackButton.Location = new System.Drawing.Point(0, 0);
            UnpackButton.Name = "UnpackButton";
            UnpackButton.Size = new System.Drawing.Size(257, 65);
            UnpackButton.TabIndex = 0;
            UnpackButton.Text = "Extract";
            UnpackButton.TextLayouts.Angle = 0;
            UnpackButton.TextLayouts.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
            UnpackButton.TextLayouts.Enabled = true;
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
            SelectAllButton.Alpha.Enabled = true;
            SelectAllButton.Animations.BackgroundImageHover = null;
            SelectAllButton.Animations.ColorHover = System.Drawing.Color.Transparent;
            SelectAllButton.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            SelectAllButton.Animations.Enabled = true;
            SelectAllButton.Animations.TextColorHover = System.Drawing.Color.Silver;
            SelectAllButton.BackColor = System.Drawing.Color.Black;
            SelectAllButton.Border.Color = System.Drawing.Color.DodgerBlue;
            SelectAllButton.Border.Enabled = true;
            SelectAllButton.Border.Radius = new System.Drawing.Size(0, 0);
            SelectAllButton.Border.Width = 4F;
            SelectAllButton.Dock = System.Windows.Forms.DockStyle.Left;
            SelectAllButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            SelectAllButton.ForeColor = System.Drawing.Color.Gainsboro;
            SelectAllButton.Icon.Enabled = true;
            SelectAllButton.Icon.IconImage = null;
            SelectAllButton.Icon.IconSize = 0;
            SelectAllButton.Layouts.Angle = 0;
            SelectAllButton.Layouts.Enabled = true;
            SelectAllButton.Location = new System.Drawing.Point(81, 0);
            SelectAllButton.Name = "SelectAllButton";
            SelectAllButton.Size = new System.Drawing.Size(81, 24);
            SelectAllButton.TabIndex = 2;
            SelectAllButton.Text = "Select All";
            SelectAllButton.TextLayouts.Angle = 0;
            SelectAllButton.TextLayouts.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SelectAllButton.TextLayouts.Enabled = true;
            SelectAllButton.Click += SelectAllButton_Click;
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.Color.Black;
            panel4.Controls.Add(SelectAllButton);
            panel4.Controls.Add(RefreshButton);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(257, 130);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(1001, 24);
            panel4.TabIndex = 3;
            // 
            // RefreshButton
            // 
            RefreshButton.Alpha.Enabled = true;
            RefreshButton.Animations.BackgroundImageHover = null;
            RefreshButton.Animations.ColorHover = System.Drawing.Color.Transparent;
            RefreshButton.Animations.CursorHover = System.Windows.Forms.Cursors.Hand;
            RefreshButton.Animations.Enabled = true;
            RefreshButton.Animations.TextColorHover = System.Drawing.Color.Silver;
            RefreshButton.BackColor = System.Drawing.Color.Black;
            RefreshButton.Border.Color = System.Drawing.Color.DodgerBlue;
            RefreshButton.Border.Enabled = true;
            RefreshButton.Border.Radius = new System.Drawing.Size(0, 0);
            RefreshButton.Border.Width = 4F;
            RefreshButton.Dock = System.Windows.Forms.DockStyle.Left;
            RefreshButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            RefreshButton.ForeColor = System.Drawing.Color.Gainsboro;
            RefreshButton.Icon.Enabled = true;
            RefreshButton.Icon.IconImage = null;
            RefreshButton.Icon.IconSize = 0;
            RefreshButton.Layouts.Angle = 0;
            RefreshButton.Layouts.Enabled = true;
            RefreshButton.Location = new System.Drawing.Point(0, 0);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new System.Drawing.Size(81, 24);
            RefreshButton.TabIndex = 3;
            RefreshButton.Text = "Refresh";
            RefreshButton.TextLayouts.Angle = 0;
            RefreshButton.TextLayouts.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RefreshButton.TextLayouts.Enabled = true;
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
        private IzUI.WinForms.UI.Controls.Inputs.Button RepackButton;
        private IzUI.WinForms.UI.Controls.Inputs.Button UnpackButton;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.CheckedListBox ListBox;
        private System.Windows.Forms.RichTextBox Info;
        private IzUI.WinForms.UI.Controls.Inputs.Button SelectAllButton;
        private System.Windows.Forms.Panel panel4;
        private IzUI.WinForms.UI.Controls.Inputs.Button DecodeButton;
        private IzUI.WinForms.UI.Controls.Inputs.Button RefreshButton;
    }
}

