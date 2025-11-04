using Domain.Enums;
using Infrastructure.Handlers;
using MessagePipe;
using SubEpics;
using UnityEngine.InputSystem;
using VContainer.Unity;

public sealed class CityBuilderGame : IStartable
{
    private readonly IGridCursor _gridCursor;
    private readonly IPublisher<BuildingAddingEvent> _buildingAddingPub;
    private bool _isPlacing = true; // TODO: Implement game state using Strategy pattern.
    
    private InputAction _leftMouseClick;

    public CityBuilderGame(IGridCursor gridCursor, IPublisher<BuildingAddingEvent> buildingAddingPub)
    {
        _gridCursor = gridCursor;
        _buildingAddingPub = buildingAddingPub;
    }
    
    public void Start()
    {
        _leftMouseClick = new InputAction(binding: "<Mouse>/leftButton");
        _leftMouseClick.performed += _ => OnLeftMouseClicked();
        _leftMouseClick.Enable();
    }
    
    private void OnLeftMouseClicked()
    {
        var position = _gridCursor.Position;
        var x = (int)position.x;
        var y = (int)position.y;
        
        _buildingAddingPub.Publish(new BuildingAddingEvent(x, y, BuildingType.House));
    }
}