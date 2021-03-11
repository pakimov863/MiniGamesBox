namespace MiniGamesBox.TicTacToe.Interfaces
{
    using System.Collections.Generic;
    using TicTacToe.Model;

    /// <summary>
    /// Интерфейс репозитория точек на поле.
    /// </summary>
    public interface IPointRepository
    {
        /// <summary>
        /// Перечисляет все точки на поле.
        /// </summary>
        /// <returns>Перечисление с описанием точек.</returns>
        IEnumerable<PointInfoModel> GetAllPoints();

        /// <summary>
        /// Добавляет новую точку.
        /// </summary>
        /// <param name="point">Описание добавляемой точки.</param>
        void AddPoint(PointInfoModel point);

        /// <summary>
        /// Очищает репозиторий.
        /// </summary>
        void Clear();
    }
}
