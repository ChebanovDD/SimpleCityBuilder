using Domain.Models;

namespace Application.UseCases.AddBuilding
{
    public enum AddBuildingFailReason
    {
        OutOfBounds,
        NotEnoughGold,
        CellOccupied,
        UnknownBuildingType
    }
    
    public struct PlaceBuildingResult
    {
        public bool IsSuccess;
        public Building Building;
        public AddBuildingFailReason FailReason;
    }
}