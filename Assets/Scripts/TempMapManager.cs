using SubEpics;
using UnityEngine;
using UnityEngine.InputSystem;

public class TempMapManager : MonoBehaviour, IGridCursor
{
    private const int FramesInterval = 5;
    
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Transform _cursor;
    
    private Camera _camera;
    
    private readonly RaycastHit[] _hits = new RaycastHit[1];

    public Vector2 Position
    {
        get
        {
            var position = _cursor.position;
            return new Vector2(position.x, position.z);
        }
    }

    private void Start()
    {
        _camera =  Camera.main;
    }

    private void Update()
    {
        if (Time.frameCount % FramesInterval != 0)
        {
            return;
        }
        
        var ray = _camera.ScreenPointToRay(Mouse.current.position.value);
        var hitCount = Physics.RaycastNonAlloc(ray, _hits, Mathf.Infinity, _targetLayer);

        if (hitCount > 0)
        {
            _cursor.position = _hits[0].transform.position;
        }
    }
}
