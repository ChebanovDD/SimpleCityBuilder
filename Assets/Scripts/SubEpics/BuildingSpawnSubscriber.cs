using System;
using Infrastructure;
using Infrastructure.Handlers;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace SubEpics
{
    public class BuildingSpawnSubscriber : MonoBehaviour
    {
        private IBuildingFactory? _factory;
        private IDisposable? _subscription;

        [Inject]
        public void Construct(ISubscriber<BuildingAddedEvent> subscriber, IBuildingFactory factory)
        {
            _factory = factory;
            _subscription = subscriber.Subscribe(OnBuildingAdded);
        }

        public void OnDestroy() => _subscription?.Dispose();
        
        private void OnBuildingAdded(BuildingAddedEvent e)
        {
            _factory?.Spawn(e.BuildingType, e.X, e.Y);
        }
    }
}