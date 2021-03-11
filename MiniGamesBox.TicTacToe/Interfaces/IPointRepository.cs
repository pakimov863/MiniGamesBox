namespace MiniGamesBox.TicTacToe.Interfaces
{
    using System.Collections.Generic;
    using TicTacToe.Model;

    public interface IPointRepository
    {
        IEnumerable<PointInfoModel> GetAllPoints();

        void AddPoint(PointInfoModel point);

        void Clear();
    }
}
