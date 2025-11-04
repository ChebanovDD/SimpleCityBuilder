using System;

namespace Domain.Exceptions
{
    public sealed class BuildingMaxLevelException : Exception
    {
        public BuildingMaxLevelException() : base("Building 'Level' exceeds maximum level.")
        {
        }
    }
}