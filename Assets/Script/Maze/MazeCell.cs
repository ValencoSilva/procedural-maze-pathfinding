
///Represents a single cell in the maze grid

public class MazeCell
{
    //Coordinates 
    public int x;
    public int y;

    //Whether the cell has been visited during maze generation
    public bool visited;

    //Walls 
    public bool wallTop = true;
    public bool wallBottom = true;
    public bool wallLeft = true;
    public bool wallRight = true;

    //Constructor to initialize the cell at given coordinates
    public MazeCell(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}



/*
HOW THIS SCRIPT WORKS:
This script represents a single cell in the maze grid
It stores its position, wall information, and whether it has been visited during generation
It does not contain logic, only data, and is used by the generator, renderer, and pathfinding systems
*/
