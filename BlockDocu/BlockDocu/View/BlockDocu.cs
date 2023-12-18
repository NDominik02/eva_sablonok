using BlockDocu.Model;
using System.Numerics;
using System.Windows.Forms;

namespace BlockDocu
{
    public partial class BlockDocu : Form
    {
        #region Fields

        private IBlockDocuDataAccess _dataAccess = null!;
        private BlockDocuGameModel _model = null!;
        private Button[,] _buttonGrid = null!;
        private Button[,] _buttonGrid2 = null!;

        #endregion

        #region Constructors
        public BlockDocu()
        {
            InitializeComponent();

            _dataAccess = new BlockDocuFileDataAccess();

            _model = new BlockDocuGameModel(_dataAccess);
            _model.FieldChanged += new EventHandler<BlockDocuFieldEventArgs>(Game_FieldChanged);
            _model.GameOver += new EventHandler<BlockDocuEventArgs>(Game_GameOver);

            GenerateTable();

            _model.NewGame();
            SetupTable();

        }

        #endregion

        #region Game event handlers

        private void Game_FieldChanged(object? sender, BlockDocuFieldEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_model.Table.IsOwned(i, j))
                    {
                        _buttonGrid[i, j].BackColor = Color.Blue;
                    }
                    else
                    {
                        _buttonGrid[i, j].BackColor = Color.White;
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (_model.ShapeTable.IsOwned(i, j))
                    {
                        _buttonGrid2[i, j].BackColor = Color.Blue;
                    }
                    else
                    {
                        _buttonGrid2[i, j].BackColor = Color.White;
                    }
                }
            }
            _toolLabelPoints.Text = _model.Table.PointsT.ToString();

        }

        private void Game_GameOver(Object? sender, BlockDocuEventArgs e)
        {

            foreach (Button button in _buttonGrid) // kikapcsoljuk a gombokat
                button.Enabled = false;

            _menuFileSaveGame.Enabled = false;

            MessageBox.Show("V�ge a j�t�knak! :(" + Environment.NewLine +
                            "�sszesen " + e.Points + " pontot gy�jt�tt�l. ",
                            "BlockDocu j�t�k",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
            if ((MessageBox.Show("Szeretn�l �j j�t�kot kezdeni? :))", "BlockDocu j�t�k", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                _menuFileSaveGame.Enabled = true;
                _model.NewGame();
                SetupTable();
                foreach (Button button in _buttonGrid)
                    button.Enabled = true;
            }
            else
            {
                Close();
            }
        }

        #endregion

        #region Grid event handlers

        private void ButtonGrid_MouseClick(Object? sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                Int32 x = (button.TabIndex - 100) / _model.Table.Size;
                Int32 y = (button.TabIndex - 100) % _model.Table.Size;

                _model.Step(x, y); // l�p�s a j�t�kban

            }
        }

        #endregion

        #region Menu event handlers
        private void _menuFileNewGame_Click(object sender, EventArgs e)
        {
            _menuFileSaveGame.Enabled = true;
            _model.NewGame();
            SetupTable();
            foreach (Button button in _buttonGrid) // kikapcsoljuk a gombokat
                button.Enabled = true;


        }

        private async void _menuFileLoadGame_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK) // ha kiv�lasztottunk egy f�jlt
            {
                try
                {
                    // j�t�k bet�lt�se
                    await _model.LoadGameAsync(_openFileDialog.FileName);
                    _menuFileSaveGame.Enabled = true;
                }
                catch (BlockDocuDataException)
                {
                    MessageBox.Show("J�t�k bet�lt�se sikertelen!" + Environment.NewLine + "Hib�s az el�r�si �t, vagy a f�jlform�tum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _model.NewGame();
                    _menuFileSaveGame.Enabled = true;
                }

                SetupTable();
            }

        }

        private async void _menuFileSaveGame_Click(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // j�t� ment�se
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                }
                catch (BlockDocuDataException)
                {
                    MessageBox.Show("J�t�k ment�se sikertelen!" + Environment.NewLine + "Hib�s az el�r�si �t, vagy a k�nyvt�r nem �rhat�.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void _menuFileExit_Click(object sender, EventArgs e)
        {
            // megk�rdezz�k, hogy biztos ki szeretne-e l�pni
            if (MessageBox.Show("Biztosan ki szeretne l�pni?", "Sudoku j�t�k", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ha igennel v�laszol
                Close();
            }

        }


        #endregion

        #region Private methods

        private void GenerateTable()
        {
            _buttonGrid = new Button[_model.Table.Size, _model.Table.Size];
            for (int i = 0; i < _model.Table.Size; i++)
            {
                for (int j = 0; j < _model.Table.Size; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Location = new Point(5 + 100 * j, 35 + 100 * i);
                    _buttonGrid[i, j].Size = new Size(100, 100);
                    _buttonGrid[i, j].TabIndex = 100 + i * _model.Table.Size + j;
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    _buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);

                    Controls.Add(_buttonGrid[i, j]);
                }
            }

            _buttonGrid2 = new Button[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    _buttonGrid2[i, j] = new Button();
                    _buttonGrid2[i, j].Location = new Point(50 + 100 * j + 400, 90 + 100 * i);
                    _buttonGrid2[i, j].Size = new Size(100, 100);
                    _buttonGrid2[i, j].TabIndex = 100 + i * _model.Table.Size + j + 17;
                    _buttonGrid2[i, j].FlatStyle = FlatStyle.Flat;

                    Controls.Add(_buttonGrid2[i, j]);

                }
            }

        }

        private void SetupTable()
        {
            for (Int32 i = 0; i < _buttonGrid.GetLength(0); i++)
            {
                for (Int32 j = 0; j < _buttonGrid.GetLength(1); j++)
                {
                    if (_model.Table.IsOwned(i, j))
                    {
                        _buttonGrid[i, j].BackColor = Color.Blue;
                    }
                    else
                    {
                        _buttonGrid[i, j].BackColor = Color.White;
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (_model.ShapeTable.IsOwned(i, j))
                    {
                        _buttonGrid2[i, j].BackColor = Color.Blue;
                    }
                    else
                    {
                        _buttonGrid2[i, j].BackColor = Color.White;
                    }
                }
            }
            _toolLabelPoints.Text = _model.Table.PointsT.ToString();
        }

        #endregion

    }
}