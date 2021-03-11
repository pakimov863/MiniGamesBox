namespace MiniGamesBox.TicTacToe.Model
{
    using System;

    public class FieldClickEventArgs : EventArgs
    {
        public long ScreenX { get; set; }

        public long ScreenY { get; set; }

        public long FieldX { get; set; }

        public long FieldY { get; set; }
    }
}
