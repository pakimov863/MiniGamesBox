namespace MiniGamesBox.TicTacToe.Model
{
    using System;

    /// <summary>
    /// Аргументы события от нажатия по полю.
    /// </summary>
    public class FieldClickEventArgs : EventArgs
    {
        /// <summary>
        /// Получает или задает экранную координату X точки, куда нажал пользователь.
        /// </summary>
        public long ScreenX { get; set; }

        /// <summary>
        /// Получает или задает экранную координату Y точки, куда нажал пользователь.
        /// </summary>
        public long ScreenY { get; set; }

        /// <summary>
        /// Получает или задает координату X ячейки, куда нажал пользователь.
        /// </summary>
        public long FieldX { get; set; }

        /// <summary>
        /// Получает или задает координату Y ячейки, куда нажал пользователь.
        /// </summary>
        public long FieldY { get; set; }
    }
}
