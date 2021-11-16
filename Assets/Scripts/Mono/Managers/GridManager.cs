using UnityEditor;
using UnityEngine;
using VD.Datastructures;

public class GridManager : Singleton<GridManager>
{
    [Range(1, 30)][SerializeField] private int _gridWidth, _gridLength;
    [SerializeField] private bool _showGrid;

    private Vector3[,] _grid;
    private int xOffset, zOffset;
    public Vector3[,] Grid => _grid;

    #region Unity Event Functions

    public override void Awake()
    {
        base.Awake();
        xOffset = _gridWidth / 2;
        zOffset = _gridLength / 2;
        
        CreateGrid(_gridWidth, _gridLength);
    }

    private void Start()
    {
        // xOffset = _gridWidth / 2;
        // zOffset = _gridLength / 2;
        //
        // CreateGrid(_gridWidth, _gridLength);
    }

    #endregion

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
        if (_showGrid)
        {
            xOffset = _gridWidth / 2;
            zOffset = _gridLength / 2;

            for (int x = 0; x < _gridWidth; x++)
            {
                for (int z = 0; z < _gridLength; z++)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawCube(new Vector3(x - xOffset, -0.5f ,z - zOffset), new Vector3(0.25f, 0.1f, 0.25f));
                    Handles.Label(new Vector3(x - xOffset + 0.25f , -0.5f ,z - zOffset - 0.25f), $"{x},{z}");
                }
            }
        }
    }
}
