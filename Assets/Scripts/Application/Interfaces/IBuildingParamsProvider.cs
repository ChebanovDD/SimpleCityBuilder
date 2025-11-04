using Domain.Enums;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IBuildingParamsProvider
    {
        bool TryGetBuildingParams(BuildingType buildingType, out BuildingParams buildingParams);
    }
}