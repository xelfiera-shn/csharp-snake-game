using CSharpSnakeGame.Objects;
using System.Runtime.InteropServices;

namespace CSharpSnakeGame
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Snake _snake = new Snake();
        private Food _food = new Food();
        private int _score = 0;

        private void frmMain_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        public void StartGame()
        {
            pnlCanvas.Controls.Clear();
            _snake.ResetSnake(pnlCanvas);
            _food.GenerateNewLocation(_snake);
            pnlCanvas.Controls.Add(_food);
            _score = 0;
            lblScore.Text = $"Score: {_score.ToString()}";
            tmrUpdater.Start();
        }

        private void tmrUpdater_Tick(object sender, EventArgs e)
        {
            if (_snake.Move(pnlCanvas, _food))
            {
                _score++;
                lblScore.Text = $"Score: {_score.ToString()}";

                _food.GenerateNewLocation(_snake);
            }

            if(CheckGameOver())
            {
                tmrUpdater.Stop();
                StartGame();
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (_snake.Direction != Directions.Down)
                        _snake.Direction = Directions.Up;
                    break;

                case Keys.D:
                    if (_snake.Direction != Directions.Left)
                        _snake.Direction = Directions.Right;
                    break;

                case Keys.S:
                    if (_snake.Direction != Directions.Up)
                        _snake.Direction = Directions.Down;
                    break;

                case Keys.A:
                    if (_snake.Direction != Directions.Right)
                        _snake.Direction = Directions.Left;
                    break;

                default:
                    break;
            }
        }

        private bool CheckGameOver()
        {
            int headX = _snake.BodyParts.Last().Location.X;
            int headY = _snake.BodyParts.Last().Location.Y;

            foreach (BodyPart part in _snake.BodyParts.SkipLast(1))
            {
                if (part.Location.X == headX && part.Location.Y == headY)
                    return true;
            }

            if (headX >= pnlCanvas.Width || headX < 0 ||
                headY >= pnlCanvas.Height || headY < 0)
                return true;

                return false;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}