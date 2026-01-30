using System.Collections.Generic;


/// Maze generation using Recursive Backtracking algorithm

public class MazeGenerator
{

    private MazeGrid grid;
    private System.Random rng;
    
    // Constructor to initialize the maze generator with a grid and random seed
    public MazeGenerator(MazeGrid grid, int seed)
    {
        this.grid = grid;
        rng = new System.Random(seed);
    }

  
    public void Generate()
    {
        GenerateFromCell(grid.GetCell(0, 0));
    }

    // Recursive function to generate the maze from a given cell
    private void GenerateFromCell(MazeCell cell)
    {
        cell.visited = true;

        List<MazeCell> neighbors = GetUnvisitedNeighbors(cell);

        while (neighbors.Count > 0)
        {
            MazeCell next = neighbors[rng.Next(neighbors.Count)];
            RemoveWall(cell, next);
            GenerateFromCell(next);
            neighbors = GetUnvisitedNeighbors(cell);
        }
    }

    // Retrieves a list of unvisited neighboring cells
    private List<MazeCell> GetUnvisitedNeighbors(MazeCell cell)
    {
        List<MazeCell> list = new List<MazeCell>();

        TryAdd(cell.x + 1, cell.y, list);
        TryAdd(cell.x - 1, cell.y, list);
        TryAdd(cell.x, cell.y + 1, list);
        TryAdd(cell.x, cell.y - 1, list);

        return list;
    }

    // Attempts to add a cell at (x, y) to the list if it is unvisited
    private void TryAdd(int x, int y, List<MazeCell> list)
    {
        MazeCell c = grid.GetCell(x, y);
        if (c != null && !c.visited)
            list.Add(c);
    }

    // Removes the wall between two adjacent cells
    private void RemoveWall(MazeCell a, MazeCell b)
    {
        if (a.x == b.x)
        {
            if (a.y > b.y)
            {
                a.wallBottom = false;
                b.wallTop = false;
            }
            else
            {
                a.wallTop = false;
                b.wallBottom = false;
            }
        }
        else
        {
            if (a.x > b.x)
            {
                a.wallLeft = false;
                b.wallRight = false;
            }
            else
            {
                a.wallRight = false;
                b.wallLeft = false;
            }
        }
    }



}


/*
HOW THIS SCRIPT WORKS:
This script generates the maze structure procedurally
It starts from a random cell, visits neighboring cells, removes walls between them,
and continues until all cells have been visited. The result is a fully connected maze
with a clear path between any two cells
*/
