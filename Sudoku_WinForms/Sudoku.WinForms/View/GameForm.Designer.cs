namespace ELTE.Sudoku.View
{
    partial class GameForm
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
            _menuStrip = new System.Windows.Forms.MenuStrip();
            _menuFile = new System.Windows.Forms.ToolStripMenuItem();
            _menuFileNewGame = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            _menuFileLoadGame = new System.Windows.Forms.ToolStripMenuItem();
            _menuFileSaveGame = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            _menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            _menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            _menuGameEasy = new System.Windows.Forms.ToolStripMenuItem();
            _menuGameMedium = new System.Windows.Forms.ToolStripMenuItem();
            _menuGameHard = new System.Windows.Forms.ToolStripMenuItem();
            _openFileDialog = new System.Windows.Forms.OpenFileDialog();
            _saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            _statusStrip = new System.Windows.Forms.StatusStrip();
            _toolLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            _toolLabelGameSteps = new System.Windows.Forms.ToolStripStatusLabel();
            _toolLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            _toolLabelGameTime = new System.Windows.Forms.ToolStripStatusLabel();
            _menuStrip.SuspendLayout();
            _statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // _menuStrip
            // 
            _menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            _menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { _menuFile, _menuSettings });
            _menuStrip.Location = new System.Drawing.Point(0, 0);
            _menuStrip.Name = "_menuStrip";
            _menuStrip.Padding = new System.Windows.Forms.Padding(11, 5, 0, 5);
            _menuStrip.Size = new System.Drawing.Size(447, 46);
            _menuStrip.TabIndex = 0;
            _menuStrip.Text = "menuStrip1";
            // 
            // _menuFile
            // 
            _menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _menuFileNewGame, toolStripMenuItem1, _menuFileLoadGame, _menuFileSaveGame, toolStripMenuItem2, _menuFileExit });
            _menuFile.Name = "_menuFile";
            _menuFile.Size = new System.Drawing.Size(71, 36);
            _menuFile.Text = "File";
            // 
            // _menuFileNewGame
            // 
            _menuFileNewGame.Name = "_menuFileNewGame";
            _menuFileNewGame.Size = new System.Drawing.Size(359, 44);
            _menuFileNewGame.Text = "Új játék";
            _menuFileNewGame.Click += MenuFileNewGame_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(356, 6);
            // 
            // _menuFileLoadGame
            // 
            _menuFileLoadGame.Name = "_menuFileLoadGame";
            _menuFileLoadGame.Size = new System.Drawing.Size(359, 44);
            _menuFileLoadGame.Text = "Játék betöltése...";
            _menuFileLoadGame.Click += MenuFileLoadGame_Click;
            // 
            // _menuFileSaveGame
            // 
            _menuFileSaveGame.Name = "_menuFileSaveGame";
            _menuFileSaveGame.Size = new System.Drawing.Size(359, 44);
            _menuFileSaveGame.Text = "Játék mentése...";
            _menuFileSaveGame.Click += MenuFileSaveGame_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(356, 6);
            // 
            // _menuFileExit
            // 
            _menuFileExit.Name = "_menuFileExit";
            _menuFileExit.Size = new System.Drawing.Size(359, 44);
            _menuFileExit.Text = "Kilépés";
            _menuFileExit.Click += MenuFileExit_Click;
            // 
            // _menuSettings
            // 
            _menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _menuGameEasy, _menuGameMedium, _menuGameHard });
            _menuSettings.Name = "_menuSettings";
            _menuSettings.Size = new System.Drawing.Size(147, 38);
            _menuSettings.Text = "Beállítások";
            // 
            // _menuGameEasy
            // 
            _menuGameEasy.Name = "_menuGameEasy";
            _menuGameEasy.Size = new System.Drawing.Size(359, 44);
            _menuGameEasy.Text = "Könnyű játék";
            _menuGameEasy.Click += MenuGameEasy_Click;
            // 
            // _menuGameMedium
            // 
            _menuGameMedium.Name = "_menuGameMedium";
            _menuGameMedium.Size = new System.Drawing.Size(359, 44);
            _menuGameMedium.Text = "Közepes játék";
            _menuGameMedium.Click += MenuGameMedium_Click;
            // 
            // _menuGameHard
            // 
            _menuGameHard.Name = "_menuGameHard";
            _menuGameHard.Size = new System.Drawing.Size(359, 44);
            _menuGameHard.Text = "Nehéz játék";
            _menuGameHard.Click += MenuGameHard_Click;
            // 
            // _openFileDialog
            // 
            _openFileDialog.Filter = "Sudoku tábla (*.stl)|*.stl";
            _openFileDialog.Title = "Sudoku játék betöltése";
            // 
            // _saveFileDialog
            // 
            _saveFileDialog.Filter = "Sudoku tábla (*.stl)|*.stl";
            _saveFileDialog.Title = "Sudoku játék mentése";
            // 
            // _statusStrip
            // 
            _statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            _statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { _toolLabel1, _toolLabelGameSteps, _toolLabel2, _toolLabelGameTime });
            _statusStrip.Location = new System.Drawing.Point(0, 467);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
            _statusStrip.Size = new System.Drawing.Size(447, 46);
            _statusStrip.TabIndex = 1;
            _statusStrip.Text = "statusStrip1";
            // 
            // _toolLabel1
            // 
            _toolLabel1.Name = "_toolLabel1";
            _toolLabel1.Size = new System.Drawing.Size(134, 36);
            _toolLabel1.Text = "Lépésszám:";
            // 
            // _toolLabelGameSteps
            // 
            _toolLabelGameSteps.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            _toolLabelGameSteps.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            _toolLabelGameSteps.Name = "_toolLabelGameSteps";
            _toolLabelGameSteps.Size = new System.Drawing.Size(31, 36);
            _toolLabelGameSteps.Text = "0";
            // 
            // _toolLabel2
            // 
            _toolLabel2.Name = "_toolLabel2";
            _toolLabel2.Size = new System.Drawing.Size(107, 36);
            _toolLabel2.Text = "Játékidő:";
            // 
            // _toolLabelGameTime
            // 
            _toolLabelGameTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            _toolLabelGameTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            _toolLabelGameTime.Name = "_toolLabelGameTime";
            _toolLabelGameTime.Size = new System.Drawing.Size(93, 36);
            _toolLabelGameTime.Text = "0:00:00";
            // 
            // GameForm
            // 
            ClientSize = new System.Drawing.Size(447, 513);
            Controls.Add(_statusStrip);
            Controls.Add(_menuStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MainMenuStrip = _menuStrip;
            Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            MaximizeBox = false;
            Name = "GameForm";
            Text = "Sudoku játék";
            Load += GameForm_Load;
            _menuStrip.ResumeLayout(false);
            _menuStrip.PerformLayout();
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _menuFile;
        private System.Windows.Forms.ToolStripMenuItem _menuFileNewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _menuFileLoadGame;
        private System.Windows.Forms.ToolStripMenuItem _menuFileSaveGame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem _menuFileExit;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem _menuSettings;
        private System.Windows.Forms.ToolStripMenuItem _menuGameEasy;
        private System.Windows.Forms.ToolStripMenuItem _menuGameMedium;
        private System.Windows.Forms.ToolStripMenuItem _menuGameHard;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabel1;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabelGameSteps;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabel2;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabelGameTime;
    }
}

