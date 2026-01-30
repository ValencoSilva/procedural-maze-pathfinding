
/// Manages the maze grid made up of cells
public class MazeGrid
{
    // Dimensions of the maze
    public int width;
    public int height;

    // 2D array of maze cells
    public MazeCell[,] cells;


    // Constructor to initialize the maze grid with given dimensions
    public MazeGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        cells = new MazeCell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cells[x, y] = new MazeCell(x, y);
            }
        }
    }

    // Retrieves the cell at the specified coordinates
    public MazeCell GetCell(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height)
            return null;

        return cells[x, y];
    }
}


/*
HOW THIS SCRIPT WORKS:
This script creates and stores the logical grid of the maze
It initializes all MazeCell objects and provides access to them
Other systems use this grid as the single source of truth for maze data
*/


