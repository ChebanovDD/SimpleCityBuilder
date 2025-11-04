using System;
using Domain.Enums;

namespace Domain.Models
{
    public class Tile
    {
        public Guid Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public TileType Type { get; private set; }

        public Tile(int x, int y, TileType type)
        {
            Id = Guid.NewGuid();
            X = x;
            Y = y;
            Type = type;
        }
    }
}
