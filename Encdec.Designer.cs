namespace Iswenzz.AION.Encdec
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AboutButton = new Iswenzz.UI.Controls.Buttons.FlatButton();
            this.RepackButton = new Iswenzz.UI.Controls.Buttons.FlatButton();
            this.DecodeButton = new Iswenzz.UI.Controls.Buttons.FlatButton();
            this.ExtractButton = new Iswenzz.UI.Controls.Buttons.FlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Info = new ConsoleControl.ConsoleControl();
            this.SelectAllButton = new Iswenzz.UI.Controls.Buttons.FlatButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AboutButton);
            this.panel1.Controls.Add(this.RepackButton);
            this.panel1.Controls.Add(this.DecodeButton);
            this.panel1.Controls.Add(this.ExtractButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 575);
            this.panel1.TabIndex = 10;
            // 
            // AboutButton
            // 
            this.AboutButton.Angles = 90;
            this.AboutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.AboutButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AboutButton.FlatAppearance.BorderSize = 0;
            this.AboutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AboutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutButton.Font = new System.Drawing.Font("Corbel", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AboutButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AboutButton.HoverColorLeave = System.Drawing.Color.Empty;
            this.AboutButton.HoverColorText = System.Drawing.Color.DarkOrange;
            this.AboutButton.HoverColorTextLeave = System.Drawing.Color.Empty;
            this.AboutButton.Icon = null;
            this.AboutButton.IconAutoPlacement = false;
            this.AboutButton.IconSize = 0;
            this.AboutButton.Location = new System.Drawing.Point(0, 510);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.RoundedCorner = 0;
            this.AboutButton.Size = new System.Drawing.Size(257, 65);
            this.AboutButton.TabIndex = 3;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = false;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // RepackButton
            // 
            this.RepackButton.Angles = 90;
            this.RepackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RepackButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RepackButton.FlatAppearance.BorderSize = 0;
            this.RepackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RepackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RepackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RepackButton.Font = new System.Drawing.Font("Corbel", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepackButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.RepackButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RepackButton.HoverColorLeave = System.Drawing.Color.Empty;
            this.RepackButton.HoverColorText = System.Drawing.Color.DarkOrange;
            this.RepackButton.HoverColorTextLeave = System.Drawing.Color.Empty;
            this.RepackButton.Icon = null;
            this.RepackButton.IconAutoPlacement = false;
            this.RepackButton.IconSize = 0;
            this.RepackButton.Location = new System.Drawing.Point(0, 130);
            this.RepackButton.Name = "RepackButton";
            this.RepackButton.RoundedCorner = 0;
            this.RepackButton.Size = new System.Drawing.Size(257, 65);
            this.RepackButton.TabIndex = 2;
            this.RepackButton.Text = "Repack PAK";
            this.RepackButton.UseVisualStyleBackColor = false;
            this.RepackButton.Click += new System.EventHandler(this.RepackButton_Click);
            // 
            // DecodeButton
            // 
            this.DecodeButton.Angles = 90;
            this.DecodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.DecodeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DecodeButton.FlatAppearance.BorderSize = 0;
            this.DecodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DecodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DecodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecodeButton.Font = new System.Drawing.Font("Corbel", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecodeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DecodeButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DecodeButton.HoverColorLeave = System.Drawing.Color.Empty;
            this.DecodeButton.HoverColorText = System.Drawing.Color.DarkOrange;
            this.DecodeButton.HoverColorTextLeave = System.Drawing.Color.Empty;
            this.DecodeButton.Icon = null;
            this.DecodeButton.IconAutoPlacement = false;
            this.DecodeButton.IconSize = 0;
            this.DecodeButton.Location = new System.Drawing.Point(0, 65);
            this.DecodeButton.Name = "DecodeButton";
            this.DecodeButton.RoundedCorner = 0;
            this.DecodeButton.Size = new System.Drawing.Size(257, 65);
            this.DecodeButton.TabIndex = 1;
            this.DecodeButton.Text = "Decode Files";
            this.DecodeButton.UseVisualStyleBackColor = false;
            this.DecodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Angles = 90;
            this.ExtractButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ExtractButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExtractButton.FlatAppearance.BorderSize = 0;
            this.ExtractButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExtractButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ExtractButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExtractButton.Font = new System.Drawing.Font("Corbel", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtractButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ExtractButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExtractButton.HoverColorLeave = System.Drawing.Color.Empty;
            this.ExtractButton.HoverColorText = System.Drawing.Color.DarkOrange;
            this.ExtractButton.HoverColorTextLeave = System.Drawing.Color.Empty;
            this.ExtractButton.Icon = null;
            this.ExtractButton.IconAutoPlacement = false;
            this.ExtractButton.IconSize = 0;
            this.ExtractButton.Location = new System.Drawing.Point(0, 0);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.RoundedCorner = 0;
            this.ExtractButton.Size = new System.Drawing.Size(257, 65);
            this.ExtractButton.TabIndex = 0;
            this.ExtractButton.Text = "Extract PAK";
            this.ExtractButton.UseVisualStyleBackColor = false;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.panel2.Controls.Add(this.listBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(257, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 130);
            this.panel2.TabIndex = 11;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox.CheckOnClick = true;
            this.listBox.ColumnWidth = 370;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.MultiColumn = true;
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(943, 130);
            this.listBox.TabIndex = 0;
            this.listBox.ThreeDCheckBoxes = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(827, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = ".PAK in PAK Folder";
            // 
            // Info
            // 
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info.IsInputEnabled = false;
            this.Info.Location = new System.Drawing.Point(257, 154);
            this.Info.Margin = new System.Windows.Forms.Padding(4);
            this.Info.Name = "Info";
            this.Info.SendKeyboardCommandsToProcess = false;
            this.Info.ShowDiagnostics = false;
            this.Info.Size = new System.Drawing.Size(943, 421);
            this.Info.TabIndex = 0;
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Angles = 0;
            this.SelectAllButton.BackColor = System.Drawing.Color.Black;
            this.SelectAllButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SelectAllButton.FlatAppearance.BorderSize = 0;
            this.SelectAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SelectAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SelectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectAllButton.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllButton.ForeColor = System.Drawing.Color.Gray;
            this.SelectAllButton.HoverColor = System.Drawing.Color.Black;
            this.SelectAllButton.HoverColorLeave = System.Drawing.Color.Empty;
            this.SelectAllButton.HoverColorText = System.Drawing.Color.DarkOrange;
            this.SelectAllButton.HoverColorTextLeave = System.Drawing.Color.Empty;
            this.SelectAllButton.Icon = null;
            this.SelectAllButton.IconAutoPlacement = false;
            this.SelectAllButton.IconSize = 0;
            this.SelectAllButton.Location = new System.Drawing.Point(0, 0);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.RoundedCorner = 0;
            this.SelectAllButton.Size = new System.Drawing.Size(74, 24);
            this.SelectAllButton.TabIndex = 2;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = false;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.SelectAllButton);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(257, 130);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(943, 24);
            this.panel4.TabIndex = 3;
            // 
            // Encdec
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1200, 575);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Encdec";
            this.Text = "Aion Encdec";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private UI.Controls.Buttons.FlatButton RepackButton;
        private UI.Controls.Buttons.FlatButton DecodeButton;
        private UI.Controls.Buttons.FlatButton ExtractButton;
        private System.Windows.Forms.Panel panel2;
        private UI.Controls.Buttons.FlatButton AboutButton;
        public System.Windows.Forms.CheckedListBox listBox;
        private System.Windows.Forms.Label label1;
        private ConsoleControl.ConsoleControl Info;
        private UI.Controls.Buttons.FlatButton SelectAllButton;
        private System.Windows.Forms.Panel panel4;
    }
}

