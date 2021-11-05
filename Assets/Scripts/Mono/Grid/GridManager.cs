using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Range(1, 30)][SerializeField] private int _gridWidth, _gridLength;
    [SerializeField] private GameObject _tile;
    
    private Vector3[,] _grid;
    private int xOffset, zOffset;

    private void Start()
    {
        xOffset = _gridWidth / 2;
        zOffset = _gridLength / 2;
        
        CreateGrid(_gridWidth, _gridLength);
    }

    private void CreateGrid(int width, int length)
    {
        _grid = new Vector3[width, length];
        
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                _grid[x, z] = new Vector3(x - xOffset, 0, z - zOffset);
            }
        }
    }

    //Visualize Grid For Easier Debugging.
    private void OnDrawGizmos()
    {
        xOffset = _gridWidth / 2;
        zOffset = _gridLength / 2;
        
        for (int x = 0; x < _gridWidth; x++)
        {
            for (int z = 0; z < _gridLength; z++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(new Vector3(x - xOffset, 0 ,z - zOffset), new Vector3(0.2f, 0.2f, 0.2f));
                Handles.Label(new Vector3(x - xOffset + 0.2f , 0 ,z - zOffset), $"{x},0,{z}");
            }
        }
    }
}
