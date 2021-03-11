using System;
using System.Linq;

namespace MiniGamesBox.TicTacToe.Services
{
    using System.Collections.Generic;
    using Interfaces;
    using Model;

    public class MemoryPointRepository : IPointRepository
    {
        private List<PointInfoModel> lst = new List<PointInfoModel>(); 

        public IEnumerable<PointInfoModel> GetAllPoints()
        {
            if (!lst.Any())
            {
                var random = new Random();
                for (var i = 0; i < 1000; i++)
                {
                    lst.Add(new PointInfoModel {X = random.Next(-50, 50), Y = random.Next(-50, 50), Type = random.NextDouble() > 0.5 ? PointType.Circle : PointType.Cross});
                }
            }

            return lst;
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
