namespace Game.WinForms
{
    partial class GameForm
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            _menuFileNewGame = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            _menuFileSaveGame = new ToolStripMenuItem();
            _menuFileLoadGame = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            _menuFileExitGame = new ToolStripMenuItem();
            beállításokToolStripMenuItem = new ToolStripMenuItem();
            _menuSettingsSmallSize = new ToolStripMenuItem();
            _menuSettingsMediumSize = new ToolStripMenuItem();
            _menuSettingsBigSize = new ToolStripMenuItem();
            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, beállításokToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 3, 0, 3);
            menuStrip1.Size = new Size(1003, 44);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _menuFileNewGame, toolStripSeparator1, _menuFileSaveGame, _menuFileLoadGame, toolStripSeparator2, _menuFileExitGame });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 38);
            fileToolStripMenuItem.Text = "File";
            // 
            // _menuFileNewGame
            // 
            _menuFileNewGame.Name = "_menuFileNewGame";
            _menuFileNewGame.Size = new Size(322, 44);
            _menuFileNewGame.Text = "Új játék";
            _menuFileNewGame.Click += MenuFileNewGame_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(319, 6);
            // 
            // _menuFileSaveGame
            // 
            _menuFileSaveGame.Name = "_menuFileSaveGame";
            _menuFileSaveGame.Size = new Size(322, 44);
            _menuFileSaveGame.Text = "Játék mentése...";
            _menuFileSaveGame.Click += MenuFileSaveGame_Click;
            // 
            // _menuFileLoadGame
            // 
            _menuFileLoadGame.Name = "_menuFileLoadGame";
            _menuFileLoadGame.Size = new Size(322, 44);
            _menuFileLoadGame.Text = "Játék betöltése...";
            _menuFileLoadGame.Click += MenuFileLoadGame_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(319, 6);
            // 
            // _menuFileExitGame
            // 
            _menuFileExitGame.Name = "_menuFileExitGame";
            _menuFileExitGame.Size = new Size(322, 44);
            _menuFileExitGame.Text = "Kilépés";
            _menuFileExitGame.Click += MenuFileExit_Click;
            // 
            // beállításokToolStripMenuItem
            // 
            beállításokToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _menuSettingsSmallSize, _menuSettingsMediumSize, _menuSettingsBigSize });
            beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
            beállításokToolStripMenuItem.Size = new Size(147, 38);
            beállításokToolStripMenuItem.Text = "Beállítások";
            // 
            // _menuSettingsSmallSize
            // 
            _menuSettingsSmallSize.Name = "_menuSettingsSmallSize";
            _menuSettingsSmallSize.Size = new Size(359, 44);
            _menuSettingsSmallSize.Text = "Small";
            _menuSettingsSmallSize.Click += MenuSettingsSmallSize_Click;
            // 
            // _menuSettingsMediumSize
            // 
            _menuSettingsMediumSize.Name = "_menuSettingsMediumSize";
            _menuSettingsMediumSize.Size = new Size(359, 44);
            _menuSettingsMediumSize.Text = "Medium";
            _menuSettingsMediumSize.Click += MenuSettingsMediumSize_Click;
            // 
            // _menuSettingsBigSize
            // 
            _menuSettingsBigSize.Name = "_menuSettingsBigSize";
            _menuSettingsBigSize.Size = new Size(359, 44);
            _menuSettingsBigSize.Text = "Large";
            _menuSettingsBigSize.Click += MenuSettingsBigSize_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 806);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(2, 0, 23, 0);
            statusStrip1.Size = new Size(1003, 42);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(100, 32);
            toolStripStatusLabel1.Text = "Pontok: ";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 848);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
            Name = "GameForm";
            Text = "Game";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem _menuFileNewGame;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem _menuFileSaveGame;
        private ToolStripMenuItem _menuFileLoadGame;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem _menuFileExitGame;
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        private ToolStripMenuItem beállításokToolStripMenuItem;
        private ToolStripMenuItem _menuSettingsSmallSize;
        private ToolStripMenuItem _menuSettingsMediumSize;
        private ToolStripMenuItem _menuSettingsBigSize;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
