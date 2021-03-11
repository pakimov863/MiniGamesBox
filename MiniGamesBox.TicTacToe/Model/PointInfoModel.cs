namespace MiniGamesBox.TicTacToe.Model
{
    /// <summary>
    /// Информация о установленной на поле точке.
    /// </summary>
    public class PointInfoModel
    {
        /// <summary>
        /// Получает или задает X-координату точки. 
        /// </summary>
        public long X { get; set; }

        /// <summary>
        /// Получает или задает Y-координату точки.
        /// </summary>
        public long Y { get; set; }

        /// <summary>
        /// Получает или задает тип точки.
        /// </summary>
        public PointType Type { get; set; }
    }
}
