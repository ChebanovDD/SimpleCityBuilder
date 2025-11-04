using System;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Models
{
    public class BuildingParams
    {
        public BuildingType BuildingType { get; }
        public int BaseCost { get; }
        public int BaseIncomePerTick { get; }
        public int[] UpgradeCosts { get; }

        public BuildingParams(BuildingType buildingType, int baseCost, int baseIncomePerTick, int[]? upgradeCosts)
        {
            BuildingType = buildingType;
            BaseCost = baseCost;
            BaseIncomePerTick = baseIncomePerTick;
            UpgradeCosts = upgradeCosts ?? Array.Empty<int>();
        }
    }
    
    public sealed class Building
    {
        private readonly BuildingParams _buildingParams;
        
        public Guid Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Level { get; private set; }
        public int Cost =>  _buildingParams.BaseCost;
        public int IncomePerTick => _buildingParams.BaseIncomePerTick; // TODO: Should depend on Level?
        public int[] UpgradeCosts =>  _buildingParams.UpgradeCosts;
        public BuildingType Type =>  _buildingParams.BuildingType;

        public Building(BuildingParams buildingParams, int x, int y, int level = 1)
        {
            // TODO: Check level values.
            
            Id = Guid.NewGuid();
            X = x;
            Y = y;
            Level = level;
            
            _buildingParams = buildingParams;
        }

        public void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Upgrade()
        {
            if (Level - 1 >= _buildingParams.UpgradeCosts.Length)
            {
                throw new BuildingMaxLevelException();
            }
            
            Level++;
        }
    }
}