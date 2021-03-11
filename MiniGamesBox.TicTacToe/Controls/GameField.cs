namespace MiniGamesBox.TicTacToe.Controls
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Interfaces;
    using Model;

    public partial class GameField : UserControl
    {
        private readonly int _gridStep;

        private readonly Pen _gridPen;

        private readonly Color _backgroundColor;

        private readonly IPointRepository _pointRepo;
        
        private Pen _crossPen;

        private Pen _circlePen;

        private long _lastX;

        private long _lastY;

        private long _currentX;

        private long _currentY;

        private event EventHandler<FieldClickEventArgs> _fieldClicked;

        public GameField()
        {
            _gridStep = 30;
            _gridPen = new Pen(Color.LightGray, 1);
            _backgroundColor = Color.White;

            InitializeComponent();
        }

        public GameField(IPointRepository pointRepo)
            : this()
        {
            _pointRepo = pointRepo;
        }

        public event EventHandler<FieldClickEventArgs> FieldClicked
        {
            add => _fieldClicked += value;
            remove => _fieldClicked -= value;
        }

        public void Initialize(Color crossColor, Color circleColor)
        {
            _crossPen = new Pen(crossColor, 2);
            _circlePen = new Pen(circleColor, 2);
        }

        private void FieldDrawerMouseDown(object sender, MouseEventArgs e)
        {
            _lastX = e.X;
            _lastY = e.Y;
        }

        private void FieldDrawerMouseMove(object sender, MouseEventArgs e)
        {
            if (!FieldDrawer.Capture)
            {
                return;
            }

            _currentX -= e.X - _lastX;
            _currentY += e.Y - _lastY;
            _lastX = e.X;
            _lastY = e.Y;

            FieldDrawer.Invalidate();
        }

        private void FieldDrawerMouseClick(object sender, MouseEventArgs e)
        {
            if (_fieldClicked == null)
            {
                return;
            }

            var clickedX = e.X < 0 ? _currentX - e.X : e.X + _currentX;
            var clickedY = e.Y > 0 ? _currentY - e.Y : e.Y + _currentY;

            var pointX = Math.Floor(clickedX / (decimal)_gridStep);
            var pointY = Math.Ceiling(clickedY / (decimal)_gridStep);

            var args = new FieldClickEventArgs { ScreenX = e.X, ScreenY = e.Y, FieldX = (long)pointX, FieldY = (long)pointY };
            _fieldClicked.Invoke(this, args);
        }

        private void FieldDrawerPaint(object sender, PaintEventArgs e)
        {
            var pictureBox = (PictureBox) sender;
            var width = pictureBox.Width;
            var height = pictureBox.Height;
            var graphics = e.Graphics;

            graphics.Clear(_backgroundColor);
            DrawScreenGrid(graphics, _currentX, _currentX + width, _currentY, _currentY - height);
            DrawPoints(graphics, _currentX, _currentX + width, _currentY, _currentY - height);

            #if (DEBUG)
            DrawScreenAxis(graphics, _currentX, _currentX + width, _currentY, _currentY - height);
            DrawDebugInfo(graphics, _currentX, _currentX + width, _currentY, _currentY - height);
            #endif
        }

        private void DrawDebugInfo(Graphics graphics, long minX, long maxX, long minY, long maxY)
        {
            var sb = new StringBuilder();

            var pointX = Math.Floor(_currentX / (decimal)_gridStep);
            var pointY = Math.Ceiling(_currentY / (decimal)_gridStep);

            sb.Append("Border: ").Append(minX).Append(",").Append(maxX).Append("; ").Append(minY).Append(",").Append(maxY).AppendLine();
            sb.Append("Pixel coord: ").Append(_currentX).Append(",").Append(_currentY).AppendLine();
            sb.Append("Point coord: ").Append(pointX).Append(",").Append(pointY).AppendLine();

            graphics.DrawString(sb.ToString(), new Font("Consolas", 10), new SolidBrush(Color.Black), 2, 2);
        }

        private void DrawScreenAxis(Graphics graphics, long minX, long maxX, long minY, long maxY)
        {
            if (minX < 0 && maxX > 0)
            {
                graphics.DrawLine(new Pen(Color.Black, 1), Convert.ToInt32(0 - minX), 0, Convert.ToInt32(0 - minX), Convert.ToInt32(minY - maxY));
            }

            if (minY > 0 && maxY < 0)
            {
                graphics.DrawLine(new Pen(Color.Black, 1), 0, Convert.ToInt32(minY), Convert.ToInt32(maxX - minX), Convert.ToInt32(minY));
            }
        }

        private void DrawScreenGrid(Graphics graphics, long minX, long maxX, long minY, long maxY)
        {
            for (var i = minX; i <= maxX; ++i)
            {
                if (i % _gridStep != 0)
                {
                    continue;
                }

                graphics.DrawLine(_gridPen, i - minX, 0, i - minX, minY - maxY);
            }

            for (var i = -minY; i <= -maxY; ++i)
            {
                if (i % _gridStep != 0)
                {
                    continue;
                }

                graphics.DrawLine(_gridPen, 0, i + minY, maxX - minX, i + minY);
            }
        }

        private void DrawPoints(Graphics graphics, long minX, long maxX, long minY, long maxY)
        {
            if (_pointRepo == null)
            {
                return;
            }

            var paddedMinX = minX - _gridStep * 2;
            var paddedMaxScreenX = maxX - minX;
            var paddedMinScreenY = -_gridStep;
            var paddedMaxScreenY = minY - maxY;

            foreach (var point in _pointRepo.GetAllPoints())
            {
                var startScreenX = point.X * _gridStep - minX + 2;
                var startScreenY = point.Y * _gridStep + minY + 2;
                var width = _gridStep - 4;
                var height = _gridStep - 4;

                if (paddedMinX > startScreenX || paddedMaxScreenX < startScreenX)
                {
                    continue;
                }

                if (paddedMinScreenY > startScreenY || paddedMaxScreenY < startScreenY)
                {
                    continue;
                }

                DrawSinglePoint(graphics, point, startScreenX, startScreenY, width, height);
            }
        }

        private void DrawSinglePoint(Graphics graphics, PointInfoModel point, long startX, long startY, long width, long height)
        {
            if (point.Type == PointType.Circle)
            {
                graphics.DrawArc(_circlePen, startX, startY, width, height, 0, 360);
            }
            else if (point.Type == PointType.Cross)
            {
                graphics.DrawLine(_crossPen, startX, startY, startX + width, startY + height);
                graphics.DrawLine(_crossPen, startX, startY + height, startX + width, startY);
            }
            else
            {
                throw new Exception($"Некорректный тип точки для отображения ({point.Type})");
            }
        }
    }
}
