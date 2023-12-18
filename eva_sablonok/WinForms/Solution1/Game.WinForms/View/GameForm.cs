using Game.Model;
using Game.Persistence;

namespace Game.WinForms
{
    public partial class GameForm : Form
    {
        #region Fields
        private IGameDataAccess _dataAccess = null!;
        private GameModel _model = null!;
        private Button[,] _buttonGrid = null!;

        #endregion

        #region Constructors
        public GameForm()
        {
            InitializeComponent();

            _dataAccess = new GameFileDataAccess();

            _model = new GameModel(_dataAccess);
            _model.GameAdvanced += new EventHandler<GameEventArgs>(Model_GameAdvanced);
            _model.FieldChanged += new EventHandler<GameFieldEventArgs>(Model_FieldChanged);
            _model.GameOver += new EventHandler<GameEventArgs>(Model_GameOver);

            GenerateTable();
            SetupMenus();

            _model.NewGame();
            SetupTable();
        }

        #endregion

        #region Game event handlers
        private void Model_FieldChanged(object? sender, GameFieldEventArgs e)
        {
            // mez� friss�t�se
        }


        private void Model_GameAdvanced(object? sender, GameEventArgs e)
        {
            // T�rt�nt egy l�p�s a modellben
        }

        private void Model_GameOver(object? sender, GameEventArgs e)
        {
            foreach (Button button in _buttonGrid) // kikapcsoljuk a gombokat
                button.Enabled = false;

            MessageBox.Show("V�ge a j�t�knak!",
                            "Game j�t�k",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
        }
        #endregion

        #region Grid event handlers
        private void ButtonGrid_MouseClick(object? sender, MouseEventArgs e)
        {

            if (sender is Button button)
            {

                // a TabIndex-b�l megkapjuk a sort �s oszlopot
                Int32 x = (button.TabIndex - 100) / _model.Table.Size;
                Int32 y = (button.TabIndex - 100) % _model.Table.Size;

                _model.Step(x, y); // l�p�s a j�t�kban
            }

        }

        #endregion

        #region Menu event handlers
        private void MenuFileNewGame_Click(object? sender, EventArgs e)
        {
            _model.NewGame();
            GenerateTable();
            SetupMenus();
        }

        private async void MenuFileLoadGame_Click(object? sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK) // ha kiv�lasztottunk egy f�jlt
            {
                try
                {
                    // j�t�k bet�lt�se
                    await _model.LoadGameAsync(_openFileDialog.FileName);
                }
                catch (GameDataException)
                {
                    MessageBox.Show("J�t�k bet�lt�se sikertelen!" + Environment.NewLine + "Hib�s az el�r�si �t, vagy a f�jlform�tum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _model.NewGame();
                }

                SetupTable();
            }
        }

        private async void MenuFileSaveGame_Click(object? sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // j�t� ment�se
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                }
                catch (GameDataException)
                {
                    MessageBox.Show("J�t�k ment�se sikertelen!" + Environment.NewLine + "Hib�s az el�r�si �t, vagy a k�nyvt�r nem �rhat�.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuFileExit_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan ki szeretne l�pni?", "Sudoku j�t�k", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ha igennel v�laszol
                Close();
            }
        }
        private void MenuSettingsSmallSize_Click(object sender, EventArgs e)
        {
            _model.TableSize = TableSize.Small;
        }

        private void MenuSettingsMediumSize_Click(object sender, EventArgs e)
        {
            _model.TableSize = TableSize.Medium;
        }

        private void MenuSettingsBigSize_Click(object sender, EventArgs e)
        {
            _model.TableSize = TableSize.Large;
        }

        private void SetupMenus()
        {
            _menuSettingsBigSize.Checked = (_model.TableSize == TableSize.Large);
            _menuSettingsMediumSize.Checked = (_model.TableSize == TableSize.Medium);
            _menuSettingsSmallSize.Checked = (_model.TableSize == TableSize.Small);
        }

        #endregion

        #region Private game methods


        private void GenerateTable()
        {
            if (_buttonGrid != null)
            {
                foreach (Button button in _buttonGrid)
                {
                    Controls.Remove(button);
                }
            }
            _buttonGrid = new Button[_model.Table.Size, _model.Table.Size];

            for (int i = 0; i < _model.Table.Size; i++)
            {
                for (int j = 0; j < _model.Table.Size; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Location = new Point(5 + 75 * j, 35 + 75 * i);
                    _buttonGrid[i, j].Size = new Size(70, 70);
                    _buttonGrid[i, j].TabIndex = 100 + i * _model.Table.Size + j;
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    _buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);

                    Controls.Add(_buttonGrid[i, j]);
                }
            }

            Width = _model.Table.Size * _buttonGrid[0, 0].Size.Width + (_model.Table.Size * 10);
            Height = _model.Table.Size * _buttonGrid[0, 0].Size.Width + 130 + _model.Table.Size * 3;
        }

        private void SetupTable()
        {
            // A modell alapjan sz�nezz�k ki a gombokat
        }

        #endregion
    }
}
