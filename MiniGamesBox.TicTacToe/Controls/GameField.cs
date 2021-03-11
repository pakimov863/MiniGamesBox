namespace MiniGamesBox.TicTacToe.Controls
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Interfaces;
    using TicTacToe.Model;

    /// <summary>
    /// Контрол для вывода игрового поля.
    /// </summary>
    public partial class GameField : UserControl
    {
        /// <summary>
        /// Шаг сетки игрового поля.
        /// </summary>
        private readonly int _gridStep;

        /// <summary>
        /// Перо для черчения сетки игрового поля.
        /// </summary>
        private readonly Pen _gridPen;

        /// <summary>
        /// Цвет фона игрового поля.
        /// </summary>
        private readonly Color _backgroundColor;

        /// <summary>
        /// Репозиторий для доступа к точкам игрового поля.
        /// </summary>
        private IPointRepository _pointRepo;
        
        /// <summary>
        /// Перо для черчения фигур-крестиков.
        /// </summary>
        private Pen _crossPen;

        /// <summary>
        /// Перо для черчения фигур-ноликов.
        /// </summary>
        private Pen _circlePen;

        /// <summary>
        /// Координата X последнего нажатия мышью на игровое поле.
        /// </summary>
        /// <remarks>Число от 0 до бесконечности. Отсчет от верхнего левого угла.</remarks>
        private long _lastX;

        /// <summary>
        /// Координата Y последнего нажатия мышью на игровое поле.
        /// </summary>
        /// <remarks>Число от 0 до inf. Отсчет от верхнего левого угла.</remarks>
        private long _lastY;

        /// <summary>
        /// Текущее значение минимальной отображенной X на поле.
        /// </summary>
        /// <remarks>Число от -inf до inf. Это текущий отображаемый X на левом краю картинки.</remarks>
        private long _currentX;

        /// <summary>
        /// Текущее значение минимальной отображенной Y на поле.
        /// </summary>
        /// <remarks>Число от -inf до inf. Это текущий отображаемый Y на верхнем краю картинки.</remarks>
        private long _currentY;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GameField"/>.
        /// </summary>
        public GameField()
        {
            _gridStep = 30;
            _gridPen = new Pen(Color.LightGray, 1);
            _backgroundColor = Color.White;

            CenterField();
            InitializeComponent();
        }

        /// <summary>
        /// Задает событие, срабатывающее при нажатии пользователем на поле.
        /// </summary>
        public event EventHandler<FieldClickEventArgs> FieldClicked;

        /// <summary>
        /// Инициализирует экземпляр пользовательского компонента.
        /// </summary>
        /// <param name="pointRepo">Репозиторий для доступа к точкам на поле.</param>
        /// <param name="crossColor">Цвет крестиков.</param>
        /// <param name="circleColor">Цвет ноликов.</param>
        public void Initialize(IPointRepository pointRepo, Color crossColor, Color circleColor)
        {
            _pointRepo = pointRepo;
            _crossPen = new Pen(crossColor, 2);
            _circlePen = new Pen(circleColor, 2);
        }

        /// <summary>
        /// Устанавливает текущее положение поля в (0; 0).
        /// </summary>
        public void CenterField()
        {
            _currentX = 0;
            _currentY = 0;
            _lastX = 0;
            _lastY = 0;

            FieldDrawer.Invalidate();
        }

        /// <summary>
        /// Обрабатывает событие нажатия мышью на игровое поле.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void FieldDrawerMouseDown(object sender, MouseEventArgs e)
        {
            _lastX = e.X;
            _lastY = e.Y;
        }

        /// <summary>
        /// Обрабатывает событие передвижения мыши по игровому полю.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Обрабатывает событие кратковременного нажатия мышью на игровое поле.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void FieldDrawerMouseClick(object sender, MouseEventArgs e)
        {
            if (FieldClicked == null)
            {
                return;
            }

            var clickedX = e.X < 0 ? _currentX - e.X : e.X + _currentX;
            var clickedY = e.Y > 0 ? _currentY - e.Y : e.Y + _currentY;

            var pointX = Math.Floor(clickedX / (decimal)_gridStep);
            var pointY = Math.Ceiling(clickedY / (decimal)_gridStep);

            var args = new FieldClickEventArgs { ScreenX = e.X, ScreenY = e.Y, FieldX = (long)pointX, FieldY = (long)pointY };
            FieldClicked.Invoke(this, args);
        }

        /// <summary>
        /// Обрабатывает событие перерисовки игрового поля.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Отображает отладочную информацию на поле.
        /// </summary>
        /// <param name="graphics">Объект графики для рисования.</param>
        /// <param name="minX">Минимальная координата X, отображенная на поле.</param>
        /// <param name="maxX">Максимальная координата X, отображенная на поле.</param>
        /// <param name="minY">Минимальная координата Y, отображенная на поле.</param>
        /// <param name="maxY">Максимальная координата X, отображенная на поле.</param>
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

        /// <summary>
        /// Выполняет перерисовку осей на игровом поле.
        /// </summary>
        /// <param name="graphics">Объект графики для рисования.</param>
        /// <param name="minX">Минимальная координата X, отображенная на поле.</param>
        /// <param name="maxX">Максимальная координата X, отображенная на поле.</param>
        /// <param name="minY">Минимальная координата Y, отображенная на поле.</param>
        /// <param name="maxY">Максимальная координата X, отображенная на поле.</param>
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

        /// <summary>
        /// Выполняет перерисовку сетки игрового поля.
        /// </summary>
        /// <param name="graphics">Объект графики для рисования.</param>
        /// <param name="minX">Минимальная координата X, отображенная на поле.</param>
        /// <param name="maxX">Максимальная координата X, отображенная на поле.</param>
        /// <param name="minY">Минимальная координата Y, отображенная на поле.</param>
        /// <param name="maxY">Максимальная координата X, отображенная на поле.</param>
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

        /// <summary>
        /// Выполняет перерисовку точек на поле.
        /// </summary>
        /// <param name="graphics">Объект графики для рисования.</param>
        /// <param name="minX">Минимальная координата X, отображенная на поле.</param>
        /// <param name="maxX">Максимальная координата X, отображенная на поле.</param>
        /// <param name="minY">Минимальная координата Y, отображенная на поле.</param>
        /// <param name="maxY">Максимальная координата X, отображенная на поле.</param>
        private void DrawPoints(Graphics graphics, long minX, long maxX, long minY, long maxY)
        {
            if (_pointRepo == null)
            {
                return;
            }

            var paddedMinScreenX = -_gridStep;
            var paddedMaxScreenX = maxX - minX;
            var paddedMinScreenY = -_gridStep;
            var paddedMaxScreenY = minY - maxY;

            foreach (var point in _pointRepo.GetAllPoints())
            {
                var startScreenX = point.X * _gridStep - minX + 2;
                var startScreenY = point.Y * _gridStep + minY + 2;
                var width = _gridStep - 4;
                var height = _gridStep - 4;

                if (paddedMinScreenX > startScreenX || paddedMaxScreenX < startScreenX)
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

        /// <summary>
        /// Выполняет перерисовку одной точки на поле.
        /// </summary>
        /// <param name="graphics">Объект графики для рисования.</param>
        /// <param name="point">Информация о точке.</param>
        /// <param name="startX">X-координата верхнего левого угла иконки.</param>
        /// <param name="startY">Y-координата верхнего левого угла иконки.</param>
        /// <param name="width">Ширина иконки.</param>
        /// <param name="height">Высота иконки.</param>
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
