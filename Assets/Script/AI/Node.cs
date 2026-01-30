using UnityEngine;


///Represents a node used in Pathfinding

public class Node
{
    //Node position on the grid
    public Vector2Int position;
    //Parent node for path reconstruction
    public Node parent;

    //Costs for the A* algorithm
    public int gCost;
    public int hCost;

    //Total cost (g + h)
    public int FCost => gCost + hCost;


    //Node constructor
    public Node(Vector2Int position)
    {
        this.position = position;
        gCost = 0;
        hCost = 0;
        parent = null;
    }
}


/*
HOW THIS SCRIPT WORKS:
This script represents a single node used by the pathfinding algorithm
Each node stores its grid position, movement cost values, and a reference to its parent node
These nodes are used to reconstruct the final path once the algorithm reaches the goal
*/
