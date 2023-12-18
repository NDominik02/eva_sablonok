namespace BlockDocu;

partial class BlockDocu
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
        _menuStrip = new MenuStrip();
        _menuFile = new ToolStripMenuItem();
        _menuFileNewGame = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        _menuFileLoadGame = new ToolStripMenuItem();
        _menuFileSaveGame = new ToolStripMenuItem();
        toolStripMenuItem2 = new ToolStripSeparator();
        _menuFileExit = new ToolStripMenuItem();
        _statusStrip = new StatusStrip();
        _toolLabel1 = new ToolStripStatusLabel();
        _toolLabelPoints = new ToolStripStatusLabel();
        _openFileDialog = new OpenFileDialog();
        _saveFileDialog = new SaveFileDialog();
        _menuStrip.SuspendLayout();
        _statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // _menuStrip
        // 
        _menuStrip.ImageScalingSize = new Size(20, 20);
        _menuStrip.Items.AddRange(new ToolStripItem[] { _menuFile });
        _menuStrip.Location = new Point(0, 0);
        _menuStrip.Name = "_menuStrip";
        _menuStrip.Padding = new Padding(11, 5, 0, 5);
        _menuStrip.Size = new Size(682, 46);
        _menuStrip.TabIndex = 1;
        _menuStrip.Text = "menuStrip1";
        // 
        // _menuFile
        // 
        _menuFile.DropDownItems.AddRange(new ToolStripItem[] { _menuFileNewGame, toolStripMenuItem1, _menuFileLoadGame, _menuFileSaveGame, toolStripMenuItem2, _menuFileExit });
        _menuFile.Name = "_menuFile";
        _menuFile.Size = new Size(71, 36);
        _menuFile.Text = "File";
        // 
        // _menuFileNewGame
        // 
        _menuFileNewGame.Name = "_menuFileNewGame";
        _menuFileNewGame.Size = new Size(322, 44);
        _menuFileNewGame.Text = "Új játék";
        _menuFileNewGame.Click += _menuFileNewGame_Click;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(319, 6);
        // 
        // _menuFileLoadGame
        // 
        _menuFileLoadGame.Name = "_menuFileLoadGame";
        _menuFileLoadGame.Size = new Size(322, 44);
        _menuFileLoadGame.Text = "Játék betöltése...";
        _menuFileLoadGame.Click += _menuFileLoadGame_Click;
        // 
        // _menuFileSaveGame
        // 
        _menuFileSaveGame.Name = "_menuFileSaveGame";
        _menuFileSaveGame.Size = new Size(322, 44);
        _menuFileSaveGame.Text = "Játék mentése...";
        _menuFileSaveGame.Click += _menuFileSaveGame_Click;
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new Size(319, 6);
        // 
        // _menuFileExit
        // 
        _menuFileExit.Name = "_menuFileExit";
        _menuFileExit.Size = new Size(322, 44);
        _menuFileExit.Text = "Kilépés";
        _menuFileExit.Click += _menuFileExit_Click;
        // 
        // _statusStrip
        // 
        _statusStrip.ImageScalingSize = new Size(20, 20);
        _statusStrip.Items.AddRange(new ToolStripItem[] { _toolLabel1, _toolLabelPoints });
        _statusStrip.Location = new Point(0, 565);
        _statusStrip.Name = "_statusStrip";
        _statusStrip.Padding = new Padding(1, 0, 25, 0);
        _statusStrip.Size = new Size(682, 46);
        _statusStrip.TabIndex = 2;
        _statusStrip.Text = "statusStrip1";
        // 
        // _toolLabel1
        // 
        _toolLabel1.Name = "_toolLabel1";
        _toolLabel1.Size = new Size(93, 36);
        _toolLabel1.Text = "Pontok:";
        // 
        // _toolLabelPoints
        // 
        _toolLabelPoints.BorderSides = ToolStripStatusLabelBorderSides.Right;
        _toolLabelPoints.BorderStyle = Border3DStyle.Etched;
        _toolLabelPoints.Name = "_toolLabelPoints";
        _toolLabelPoints.Size = new Size(31, 36);
        _toolLabelPoints.Text = "0";
        // 
        // _openFileDialog
        // 
        _openFileDialog.FileName = "openFileDialog";
        _openFileDialog.Filter = "BlockDocu tábla (*.stl)|*.stl";
        _openFileDialog.Title = "BlockDocu játék betöltése";
        // 
        // _saveFileDialog
        // 
        _saveFileDialog.Filter = "BlockDocu tábla (*.stl)|*.stl";
        _saveFileDialog.Title = "BlockDocu játék mentése";
        // 
        // BlockDocu
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(682, 611);
        Controls.Add(_statusStrip);
        Controls.Add(_menuStrip);
        Name = "BlockDocu";
        Text = "BlockDocu";
        _menuStrip.ResumeLayout(false);
        _menuStrip.PerformLayout();
        _statusStrip.ResumeLayout(false);
        _statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip _menuStrip;
    private ToolStripMenuItem _menuFile;
    private ToolStripMenuItem _menuFileNewGame;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem _menuFileLoadGame;
    private ToolStripMenuItem _menuFileSaveGame;
    private ToolStripSeparator toolStripMenuItem2;
    private ToolStripMenuItem _menuFileExit;
    private StatusStrip _statusStrip;
    private ToolStripStatusLabel _toolLabel1;
    private ToolStripStatusLabel _toolLabelPoints;
    private OpenFileDialog _openFileDialog;
    private SaveFileDialog _saveFileDialog;
}
