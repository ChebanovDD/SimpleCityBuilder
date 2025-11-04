using System;

namespace Domain.Exceptions
{
    public sealed class PositionOutOfBoundsException : Exception
    {
        public PositionOutOfBoundsException() : base("Position is out of bounds.")
        {
        }
    }
}