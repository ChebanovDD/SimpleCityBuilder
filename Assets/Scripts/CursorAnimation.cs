using UnityEngine;

public class CursorAnimation : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _minY = 0.1f;
    [SerializeField] private float _maxY = 0.2f;
    [SerializeField] private float _speed = 1.0f;
    
    private float _midY;
    private float _amplitude;

    private void Start()
    {
        _midY = (_minY + _maxY) / 2.0f;
        _amplitude = (_maxY - _minY) / 2.0f;
    }

    private void Update()
    {
        var newY = _midY + _amplitude * Mathf.Sin(Time.time * _speed);
        var currentPosition = _transform.position;
        
        _transform.position = new Vector3(currentPosition.x, newY, currentPosition.z);
    }
}
