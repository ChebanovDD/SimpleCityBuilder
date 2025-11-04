using System;

namespace Domain.Exceptions
{
    public sealed class TileOccupiedException : Exception
    {
        public TileOccupiedException() : base("Tile occupied.")
        {
        }
    }
}