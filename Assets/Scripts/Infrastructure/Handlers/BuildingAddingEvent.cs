using Domain.Enums;

namespace Infrastructure.Handlers
{
    public struct BuildingAddingEvent
    {
        public readonly int X;
        public readonly int Y;
        public readonly BuildingType BuildingType;

        public BuildingAddingEvent(int x, int y, BuildingType buildingType)
        {
            X = x;
            Y = y;
            BuildingType = buildingType;
        }
    }
}