using UnityEngine;


/// Responsible for visually rendering the maze based on MazeGrid data
public class MazeRenderer : MonoBehaviour
{
    public GameObject wallPrefab;

    //Size of each cell in the maze
    public float cellSize = 1f;
 
    
    public Vector3 origin = Vector3.zero;


    //Renders the maze based on the given grid
    public void Render(MazeGrid grid)
    {
        Clear();

        for (int x = 0; x < grid.width; x++)
        {
            for (int y = 0; y < grid.height; y++)
            {
                DrawCell(grid.cells[x, y]);
            }
        }
    }

    //Draws the walls of a specific maze cell
    private void DrawCell(MazeCell cell)
    {
        Vector3 pos = new Vector3(cell.x * cellSize, cell.y * cellSize, 0);

        if (cell.wallTop)
            CreateWall(pos + new Vector3(0, cellSize / 2, 0), true);

        if (cell.wallBottom)
            CreateWall(pos + new Vector3(0, -cellSize / 2, 0), true);

        if (cell.wallLeft)
            CreateWall(pos + new Vector3(-cellSize / 2, 0, 0), false);

        if (cell.wallRight)
            CreateWall(pos + new Vector3(cellSize / 2, 0, 0), false);
    }

    //Creates a horizontal or vertical wall
    private void CreateWall(Vector3 pos, bool horizontal)
    {
        GameObject wall = Instantiate(wallPrefab, pos, Quaternion.identity, transform);

        if (horizontal)
            wall.transform.localScale = new Vector3(cellSize, 0.1f, 1);
        else
            wall.transform.localScale = new Vector3(0.1f, cellSize, 1);
    }

    //Removes all previously rendered walls
    private void Clear()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
            Destroy(transform.GetChild(i).gameObject);
    }
}


/*
HOW THIS SCRIPT WORKS:
This script is responsible for drawing the maze visually
It reads the maze grid data and instantiates wall prefabs based on each cell's walls
*/
