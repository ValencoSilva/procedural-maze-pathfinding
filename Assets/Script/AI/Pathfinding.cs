using System.Collections.Generic;
using UnityEngine;


/// Implementation of Pathfinding algorithms (DFS, BFS and A*)
///respecting the real walls of the maze

public class Pathfinding
{
    private MazeManager maze;

    // Maze dimensions
    private int width;
    private int height;


   
    public Pathfinding(MazeManager maze)
    {
        this.maze = maze;
        this.width = maze.width;
        this.height = maze.height;
    }


    // Main method to find path using the selected algorithm
    public List<Vector2Int> FindPath(
        Vector2Int start,
        Vector2Int end,
        PathfindingType type)
    {
        switch (type)
        {
            case PathfindingType.DFS:
                return DFS(start, end);

            case PathfindingType.BFS:
                return BFS(start, end);

            case PathfindingType.AStar:
                return AStar(start, end);
        }

        return null;
    }

    //BFS 
    //Explores all neighbors at the present depth prior to moving on to nodes at the next depth level
    private List<Vector2Int> BFS(Vector2Int start, Vector2Int end)
    {
        Queue<Node> queue = new Queue<Node>();
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

        Node startNode = new Node(start);
        queue.Enqueue(startNode);
        visited.Add(start);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (current.position == end)
                return BuildPath(current);

            foreach (Vector2Int dir in Directions())
            {
                Vector2Int nextPos = current.position + dir;

                if (!IsValid(current.position, nextPos))
                    continue;

                if (visited.Contains(nextPos))
                    continue;

                Node nextNode = new Node(nextPos);
                nextNode.parent = current;

                visited.Add(nextPos);
                queue.Enqueue(nextNode);
            }
        }

        return null;
    }


    // DFS 
    //Explores as far as possible along each branch before backtracking
    private List<Vector2Int> DFS(Vector2Int start, Vector2Int end)
    {
        Stack<Node> stack = new Stack<Node>();
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

        Node startNode = new Node(start);
        stack.Push(startNode);

        while (stack.Count > 0)
        {
            Node current = stack.Pop();

            if (visited.Contains(current.position))
                continue;

            visited.Add(current.position);

            if (current.position == end)
                return BuildPath(current);

            foreach (Vector2Int dir in Directions())
            {
                Vector2Int nextPos = current.position + dir;

                if (!IsValid(current.position, nextPos))
                    continue;

                if (visited.Contains(nextPos))
                    continue;

                Node nextNode = new Node(nextPos);
                nextNode.parent = current;

                stack.Push(nextNode);
            }
        }

        return null;
    }

    // A* 
    //Combines features of BFS and DFS using heuristics to find the shortest path efficiently
    private List<Vector2Int> AStar(Vector2Int start, Vector2Int end)
    {
        List<Node> openSet = new List<Node>();
        HashSet<Vector2Int> closedSet = new HashSet<Vector2Int>();

        Node startNode = new Node(start);
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node current = openSet[0];

            foreach (Node node in openSet)
            {
                if (node.FCost < current.FCost)
                    current = node;
            }

            openSet.Remove(current);
            closedSet.Add(current.position);

            if (current.position == end)
                return BuildPath(current);

            foreach (Vector2Int dir in Directions())
            {
                Vector2Int nextPos = current.position + dir;

                if (!IsValid(current.position, nextPos))
                    continue;

                if (closedSet.Contains(nextPos))
                    continue;

                int tentativeG = current.gCost + 1;

                Node neighbor = openSet.Find(n => n.position == nextPos);

                if (neighbor == null)
                {
                    neighbor = new Node(nextPos);
                    openSet.Add(neighbor);
                }
                else if (tentativeG >= neighbor.gCost)
                {
                    continue;
                }

                neighbor.parent = current;
                neighbor.gCost = tentativeG;
                neighbor.hCost = Heuristic(nextPos, end);
            }
        }

        return null;
    }

    // Validates if movement from one cell to another is possible
    private bool IsValid(Vector2Int from, Vector2Int to)
    {
        if (to.x < 0 || to.y < 0 || to.x >= width || to.y >= height)
            return false;

        return maze.CanMove(from, to);
    }

    // Reconstructs the path from the end node to the start node
    private List<Vector2Int> BuildPath(Node endNode)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Node current = endNode;

        while (current != null)
        {
            path.Add(current.position);
            current = current.parent;
        }

        path.Reverse();
        return path;
    }

    // Heuristic function for A* (Manhattan distance)
    private int Heuristic(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    // Possible movement directions (up, down, left, right)
    private Vector2Int[] Directions()
    {
        return new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };
    }
}


/*
HOW THIS SCRIPT WORKS:
This script calculates a path from a start cell to an end cell inside the maze.
It analyzes neighboring cells, checks if movement is allowed, and builds a list of nodes
until the target is reached. Once completed, it reconstructs the path by following
the parent nodes back to the start.
*/
