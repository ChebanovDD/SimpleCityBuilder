using System.Collections.Generic;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Models
{
    public sealed class Grid
    {
        private readonly Tile[,]  _tiles;
        private readonly Dictionary<(int X, int Y), Building> _buildings;
        
        public int Width { get; }
        public int Height { get; }

        public bool IsInside(int x, int y) => x >= 0 && y >= 0 && x < Width && y < Height;

        public bool IsOccupied(int x, int y) => _buildings.ContainsKey((x,y));
        
        public Tile this[int x, int y]
        {
            get => _tiles[x, y];
            set => _tiles[x, y] = value;
        }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            
            _tiles = new Tile[width, height];
            _buildings = new Dictionary<(int X, int Y), Building>();
        }

        public void AddBuilding(Building building)
        {
            var x = building.X;
            var y = building.Y;

            if (!IsInside(x, y))
            {
                throw new PositionOutOfBoundsException();
            }

            if (IsOccupied(x, y))
            {
                throw new TileOccupiedException();
            }
            
            if (_tiles[x, y].Type != TileType.Ground)
            {
                throw new TileUnavailableException();
            }
            
            _buildings.Add((x, y), building);
        }
    }
}