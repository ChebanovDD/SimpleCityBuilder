using System.Collections.Generic;
using System.Linq;
using Application.UseCases.AddBuilding;
using Domain.Enums;
using Domain.Models;
using Infrastructure;
using Infrastructure.Handlers;
using MessagePipe;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GridProvider _gridProvider;
    [SerializeField] private TempMapManager _mapManager;

    [SerializeField] private Transform _buildingsRoot;
    
    [SerializeField] private PrefabPair[] _buildingPrefabs;
    
    [Header("Initial gold")]
    [SerializeField] private int _initialGold = 1000;
    
    [System.Serializable]
    public struct PrefabPair { public BuildingType Type; public GameObject BuildingPrefab; }
    
    protected override void Configure(IContainerBuilder builder)
    {
        // Domain
        builder.RegisterInstance(_gridProvider.GetGrid());

        builder.RegisterInstance(_mapManager).AsImplementedInterfaces();
        
        // Building types repo: create Domain.BuildingType instances from config here
        // var types = new List<Domain.Models.BuildingType>
        // {
        //     new Domain.Models.BuildingType("house","House", 100, 1, new[]{50,100}),
        //     new Domain.Models.BuildingType("farm","Farm", 150, 2, new[]{75,150}),
        //     new Domain.Models.BuildingType("mine","Mine", 200, 3, new[]{100,200})
        // };
        //
        // builder.RegisterInstance(new InMemoryBuildingTypeRepository(types)).AsImplementedInterfaces();
        
        builder.RegisterInstance(new PlayerEconomy(_initialGold)).AsImplementedInterfaces();
        builder.RegisterInstance(new BuildingParamsProvider(GetBuildingParams())).AsImplementedInterfaces();
        
        // // UseCase
        builder.Register<AddBuildingUseCase>(Lifetime.Singleton);
        
        // MessagePipe
        builder.RegisterMessagePipe();

        builder.Register<AddBuildingHandler>(Lifetime.Singleton).AsImplementedInterfaces();
        
        // Buildings factory.
        builder.RegisterInstance<IBuildingFactory>(
            new BuildingFactory(
                buildingPrefabs: _buildingPrefabs.ToDictionary(prefab => prefab.Type, prefab => prefab.BuildingPrefab),
                root: _buildingsRoot)
        );

        // builder.Register<BuildingSpawnSubscriber>(Lifetime.Singleton);

        // Presentation: PlacePresenter and BuildingSpawnSubscriber are MonoBehaviours in scene - they will receive injections via VContainer

        builder.RegisterEntryPoint<CityBuilderGame>();
    }

    // TODO: Move params to ScriptableObjects.
    private static Dictionary<BuildingType, BuildingParams> GetBuildingParams()
    {
        return new Dictionary<BuildingType, BuildingParams>
        {
            [BuildingType.House] = new(BuildingType.House, 100, 1, new[] { 50, 100 }),
            [BuildingType.Farm] = new(BuildingType.House, 150, 2, new[] { 75, 150 }),
            [BuildingType.Mine] = new(BuildingType.House, 200, 3, new[] { 100, 200 })
        };
    }
}