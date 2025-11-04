using Domain.Models;
using SubEpics.Models;
using UnityEngine;
using Grid = Domain.Models.Grid;

public class GridProvider : MonoBehaviour
{
    [SerializeField] private Vector2 _size;
    [SerializeField] private UnityTile[] _tiles;

    public Grid GetGrid()
    {
        var grid = new Grid((int)_size.x, (int)_size.y);

        foreach (var unityTile in _tiles)
        {
            switch (unityTile.Count)
            {
                case 1:
                {
                    var (x, y) = unityTile.Position;

                    grid[x, y] = new Tile(x, y, unityTile.Type);
                    break;
                }
                case 4:
                {
                    for (var i = 0; i < 2; i++)
                    {
                        for (var j = 0; j < 2; j++)
                        {
                            var (x, y) = unityTile.Position;

                            x += i;
                            y += j;
                            
                            grid[x, y] = new Tile(x, y, unityTile.Type);
                        }
                    }

                    break;
                }
                default: throw new System.NotImplementedException();
            }
        }
        
        // TODO: Fix bug with null Tiles.
        
        return grid;
    }
}