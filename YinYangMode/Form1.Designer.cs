namespace YinYangMode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon = new NotifyIcon(components);
            trayMenu = new ContextMenuStrip(components);
            trayMenuToggleItem = new ToolStripMenuItem();
            trayMenuOptionsItem = new ToolStripMenuItem();
            trayMenuExitItem = new ToolStripMenuItem();
            labelHotkey = new Label();
            comboModifiers = new ComboBox();
            comboKey = new ComboBox();
            labelModifiers = new Label();
            labelKey = new Label();
            checkRunAtStartup = new CheckBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            labelIconCredit = new Label();
            trayMenu.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = trayMenu;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "YinYangMode";
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            // 
            // trayMenu
            // 
            trayMenu.Items.AddRange(new ToolStripItem[] { trayMenuToggleItem, trayMenuOptionsItem, trayMenuExitItem });
            trayMenu.Name = "trayMenu";
            trayMenu.Size = new Size(148, 70);
            // 
            // trayMenuToggleItem
            // 
            trayMenuToggleItem.Name = "trayMenuToggleItem";
            trayMenuToggleItem.Size = new Size(147, 22);
            trayMenuToggleItem.Text = "Toggle theme";
            trayMenuToggleItem.Click += trayMenuToggleItem_Click;
            // 
            // trayMenuOptionsItem
            // 
            trayMenuOptionsItem.Name = "trayMenuOptionsItem";
            trayMenuOptionsItem.Size = new Size(147, 22);
            trayMenuOptionsItem.Text = "Options…";
            trayMenuOptionsItem.Click += trayMenuOptionsItem_Click;
            // 
            // trayMenuExitItem
            // 
            trayMenuExitItem.Name = "trayMenuExitItem";
            trayMenuExitItem.Size = new Size(147, 22);
            trayMenuExitItem.Text = "Exit";
            trayMenuExitItem.Click += trayMenuExitItem_Click;
            // 
            // labelHotkey
            // 
            labelHotkey.AutoSize = true;
            labelHotkey.Location = new Point(12, 9);
            labelHotkey.Name = "labelHotkey";
            labelHotkey.Size = new Size(90, 15);
            labelHotkey.TabIndex = 0;
            labelHotkey.Text = "Toggle shortcut";
            // 
            // comboModifiers
            // 
            comboModifiers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboModifiers.FormattingEnabled = true;
            comboModifiers.Location = new Point(12, 52);
            comboModifiers.Name = "comboModifiers";
            comboModifiers.Size = new Size(150, 23);
            comboModifiers.TabIndex = 1;
            // 
            // comboKey
            // 
            comboKey.DropDownStyle = ComboBoxStyle.DropDownList;
            comboKey.FormattingEnabled = true;
            comboKey.Location = new Point(180, 52);
            comboKey.Name = "comboKey";
            comboKey.Size = new Size(80, 23);
            comboKey.TabIndex = 2;
            // 
            // labelModifiers
            // 
            labelModifiers.AutoSize = true;
            labelModifiers.Location = new Point(12, 34);
            labelModifiers.Name = "labelModifiers";
            labelModifiers.Size = new Size(57, 15);
            labelModifiers.TabIndex = 3;
            labelModifiers.Text = "Modifiers";
            // 
            // labelKey
            // 
            labelKey.AutoSize = true;
            labelKey.Location = new Point(180, 34);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(26, 15);
            labelKey.TabIndex = 4;
            labelKey.Text = "Key";
            // 
            // checkRunAtStartup
            // 
            checkRunAtStartup.AutoSize = true;
            checkRunAtStartup.Location = new Point(12, 92);
            checkRunAtStartup.Name = "checkRunAtStartup";
            checkRunAtStartup.Size = new Size(152, 19);
            checkRunAtStartup.TabIndex = 5;
            checkRunAtStartup.Text = "Run at Windows startup";
            checkRunAtStartup.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(104, 155);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(185, 155);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelIconCredit
            // 
            labelIconCredit.AutoSize = true;
            labelIconCredit.ForeColor = SystemColors.GrayText;
            labelIconCredit.Location = new Point(12, 125);
            labelIconCredit.Name = "labelIconCredit";
            labelIconCredit.Size = new Size(234, 15);
            labelIconCredit.TabIndex = 8;
            labelIconCredit.Text = "Icon: Yinyang icons by Park Jisun - Flaticon";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 190);
            Controls.Add(labelIconCredit);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(checkRunAtStartup);
            Controls.Add(labelKey);
            Controls.Add(labelModifiers);
            Controls.Add(comboKey);
            Controls.Add(comboModifiers);
            Controls.Add(labelHotkey);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YinYangMode – Options";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            trayMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip trayMenu;
        private ToolStripMenuItem trayMenuToggleItem;
        private ToolStripMenuItem trayMenuOptionsItem;
        private ToolStripMenuItem trayMenuExitItem;
        private Label labelHotkey;
        private ComboBox comboModifiers;
        private ComboBox comboKey;
        private Label labelModifiers;
        private Label labelKey;
        private CheckBox checkRunAtStartup;
        private Button buttonSave;
        private Button buttonCancel;
        private Label labelIconCredit;
    }
}
