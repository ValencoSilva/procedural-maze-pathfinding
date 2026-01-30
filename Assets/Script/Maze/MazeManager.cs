using UnityEngine;

//Manages maze creation and coordinates its main systems
public class MazeManager : MonoBehaviour
{
    //Maze dimensions
    public int width;
    public int height;

    
    public MazeRenderer renderer;

    //Start and end points of the maze
    public Vector2Int startPoint;
    public Vector2Int endPoint;

    public MazeGrid Grid { get; private set; }


    //it has to be Awake to setup before BallController Start
    void Awake()
    {
        width = GameManager.Instance.GetMazeDimension();
        height = width;

        int seed = GameManager.Instance.GetSeed();
        PathfindingType ai = GameManager.Instance.selectedAI;

        //Debug.Log($"MazeManager -> Size: {width} | AI: {ai} | Seed: {seed}");

        GenerateMaze(seed);
        SetStartAndEnd();

        CameraController camCtrl = Camera.main.GetComponent<CameraController>();
        if (camCtrl != null)
            camCtrl.AdjustCamera(width, height);
    }

    //Generates the maze using the specified seed
    private void GenerateMaze(int seed)
    {
        Grid = new MazeGrid(width, height);
        MazeGenerator generator = new MazeGenerator(Grid, seed);
        generator.Generate();

        renderer.Render(Grid);
    }

    //Sets random start and end points on opposite sides of the maze
    private void SetStartAndEnd()
    {
        startPoint = new Vector2Int(0, Random.Range(0, height));
        endPoint = new Vector2Int(width - 1, Random.Range(0, height));
    }

    //Checks if movement between two cells is possible (no walls in between)
    public bool CanMove(Vector2Int from, Vector2Int to)
    {
        MazeCell fromCell = Grid.cells[from.x, from.y];
        MazeCell toCell = Grid.cells[to.x, to.y];

        Vector2Int dir = to - from;

        if (dir == Vector2Int.up) return !fromCell.wallTop && !toCell.wallBottom;
        if (dir == Vector2Int.down) return !fromCell.wallBottom && !toCell.wallTop;
        if (dir == Vector2Int.left) return !fromCell.wallLeft && !toCell.wallRight;
        if (dir == Vector2Int.right) return !fromCell.wallRight && !toCell.wallLeft;

        return false;
    }

    //Converts cell coordinates to world position
    public Vector3 CellToWorld(Vector2Int cell)
    {
        return new Vector3(cell.x, cell.y, 0);
    }
}
/*
HOW THIS SCRIPT WORKS:
This script acts as the main coordinator of the maze system
It loads game settings, generates the maze, defines start and end points,
and provides movement rules to other systems such as pathfinding and player control
*/
