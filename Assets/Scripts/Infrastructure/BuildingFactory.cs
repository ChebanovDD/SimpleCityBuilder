using System.Collections.Generic;
using Domain.Enums;
using UnityEngine;

namespace Infrastructure
{
    // TODO: Use object pools.
    public sealed class BuildingFactory : IBuildingFactory
    {
        private readonly Transform _root;
        private readonly Dictionary<BuildingType, GameObject> _buildingPrefabs;
        
        public BuildingFactory(Dictionary<BuildingType, GameObject> buildingPrefabs,  Transform root)
        {
            _root = root;
            _buildingPrefabs = buildingPrefabs;
        }
        
        public GameObject? Spawn(BuildingType type, int x, int y)
        {
            if (!_buildingPrefabs.TryGetValue(type, out var prefab))
            {
                return null;
            }
            
            var building = Object.Instantiate(prefab, _root);
            building.transform.position = new Vector3(x, 0, y);
                
            return building;
        }

        public void Despawn(GameObject building)
        {
            Object.Destroy(building);
        }
    }
}