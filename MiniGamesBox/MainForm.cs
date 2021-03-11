namespace MiniGamesBox
{
    using System.Drawing;
    using System.Windows.Forms;
    using TicTacToe.Controls;
    using TicTacToe.Services;

    public partial class MainForm : Form
    {
        private GameField _gameField;

        public MainForm()
        {
            InitializeComponent();
            InitializeField(new GameField());
        }

        private void InitializeField(GameField field)
        {
            _gameField = field;

            Controls.Add(_gameField);
            _gameField.Location = new Point(12, 12);
            _gameField.Name = "gameField1";
            _gameField.Size = new Size(545, 383);
            _gameField.TabIndex = 0;

            _gameField.Initialize(new MemoryPointRepository(), Color.Red, Color.Blue);
        }
    }
}
