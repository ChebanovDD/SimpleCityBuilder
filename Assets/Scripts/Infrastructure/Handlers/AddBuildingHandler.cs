using System;
using Application.UseCases.AddBuilding;
using Domain.Models;
using MessagePipe;
using UnityEngine;
using VContainer.Unity;

namespace Infrastructure.Handlers
{
    public sealed class AddBuildingHandler : IStartable, IDisposable
    {
        private readonly AddBuildingUseCase _useCase;
        private readonly ISubscriber<BuildingAddingEvent> _subscriber;
        private readonly IPublisher<BuildingAddedEvent> _buildingAddedPub;

        private IDisposable? _subscription;

        public AddBuildingHandler(AddBuildingUseCase useCase, ISubscriber<BuildingAddingEvent> subscriber,
            IPublisher<BuildingAddedEvent> buildingAddedPub)
        {
            _useCase = useCase;
            _subscriber = subscriber;
            _buildingAddedPub = buildingAddedPub;
        }

        public void Start()
        {
            _subscription = _subscriber.Subscribe(OnBuildingAdding);
        }
        
        public void Dispose()
        {
            _subscription?.Dispose();
        }
        
        private void OnBuildingAdding(BuildingAddingEvent e)
        {
            var result = _useCase.Execute(new AddBuildingRequest(e.X, e.Y, e.BuildingType));

            if (result.IsSuccess)
            {
                PublishBuildingAdded(result.Building);
            }
            else
            {
                if (result.FailReason == AddBuildingFailReason.NotEnoughGold)
                {
                    Debug.LogError($"Not enough gold: {result.FailReason}");
                }

                // TODO: Fail publisher.
            }
        }

        private void PublishBuildingAdded(Building building)
        {
            _buildingAddedPub.Publish(new  BuildingAddedEvent(building.X, building.Y, building.Type));
        }
    }
}