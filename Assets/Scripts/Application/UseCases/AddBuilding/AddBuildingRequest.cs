using Domain.Enums;

namespace Application.UseCases.AddBuilding
{
    public struct AddBuildingRequest
    {
        public int X;
        public int Y;
        public BuildingType Type;

        public AddBuildingRequest(int x, int y, BuildingType type)
        {
            X = x;
            Y = y;
            Type = type;
        }
    }
}