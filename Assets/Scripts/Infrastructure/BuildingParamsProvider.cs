using System.Collections.Generic;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models;

namespace Infrastructure
{
    public sealed class BuildingParamsProvider : IBuildingParamsProvider
    {
        private readonly Dictionary<BuildingType, BuildingParams> _buildingParams;

        public BuildingParamsProvider(Dictionary<BuildingType, BuildingParams> buildingParams)
        {
            _buildingParams = buildingParams;
        }
        
        public bool TryGetBuildingParams(BuildingType buildingType, out BuildingParams buildingParams)
        {
            return _buildingParams.TryGetValue(buildingType, out buildingParams);
        }
    }
}