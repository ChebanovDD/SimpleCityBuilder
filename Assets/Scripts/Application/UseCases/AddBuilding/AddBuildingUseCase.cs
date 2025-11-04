using Application.Interfaces;
using Domain.Models;

namespace Application.UseCases.AddBuilding
{
    public sealed class AddBuildingUseCase
    {
        private readonly Grid _grid;
        private readonly IPlayerEconomy _economy;
        private readonly IBuildingParamsProvider _buildingParamsProvider;

        public AddBuildingUseCase(Grid grid, IPlayerEconomy economy, IBuildingParamsProvider  buildingParamsProvider)
        {
            _grid = grid;
            _economy = economy;
            _buildingParamsProvider = buildingParamsProvider;
        }
        
        public PlaceBuildingResult Execute(AddBuildingRequest request)
        {
            if (!_grid.IsInside(request.X, request.Y))
            {
                return new PlaceBuildingResult { IsSuccess = false, FailReason = AddBuildingFailReason.OutOfBounds};
            }

            if (_grid.IsOccupied(request.X, request.Y))
            {
                return new PlaceBuildingResult { IsSuccess = false, FailReason = AddBuildingFailReason.CellOccupied };
            }

            if (!_buildingParamsProvider.TryGetBuildingParams(request.Type, out var buildingParams))
            {
                return new PlaceBuildingResult { IsSuccess = false, FailReason = AddBuildingFailReason.UnknownBuildingType };
            }
            
            // if (!_economy.TrySpend(request.BaseCost))
            // {
            //     return new PlaceBuildingResult { Success = false, FailReason = AddBuildingFailReason.NotEnoughGold };
            // }
            
            var building = new Building(buildingParams, request.X, request.Y);
            
            _grid.AddBuilding(building);

            return new PlaceBuildingResult { IsSuccess = true, Building = building };
        }
    }
}