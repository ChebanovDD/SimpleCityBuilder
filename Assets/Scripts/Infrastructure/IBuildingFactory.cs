using Domain.Enums;
using UnityEngine;

namespace Infrastructure
{
    public interface IBuildingFactory
    {
        GameObject? Spawn(BuildingType type, int x, int y);
        void Despawn(GameObject building);
    }
}