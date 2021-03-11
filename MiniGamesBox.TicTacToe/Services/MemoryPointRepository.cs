namespace MiniGamesBox.TicTacToe.Services
{
    using System.Collections.Generic;
    using Interfaces;
    using Model;

    public class MemoryPointRepository : IPointRepository
    {
        public IEnumerable<PointInfoModel> GetAllPoints()
        {
            yield return new PointInfoModel {X = 0, Y = 0, Type = PointType.Circle};
            yield return new PointInfoModel { X = 10, Y = 2, Type = PointType.Cross };
            yield return new PointInfoModel { X = 2, Y = 10, Type = PointType.Circle };
        }

        public void AddPoint(PointInfoModel point)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
