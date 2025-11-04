using Domain.Enums;
using UnityEngine;

namespace SubEpics.Models
{
    public class UnityTile : MonoBehaviour
    {
        [SerializeField] private TileType _type;
        [SerializeField] private int _count = 1;

        public int Count => _count;
        public TileType Type => _type;
        
        public (int X, int Y) Position
        {
            get
            {
                var position = transform.position;
                return ((int)position.x, (int)position.z);
            }
        }
    }
}
