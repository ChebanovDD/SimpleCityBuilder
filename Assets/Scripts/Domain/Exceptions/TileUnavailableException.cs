using System;

namespace Domain.Exceptions
{
    public sealed class TileUnavailableException : Exception
    {
        public TileUnavailableException() : base("Tile is unavailable.")
        {
        }
    }
}