using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoord;
    public Vector2Int StartCoord { get {return startCoord;}}
    [SerializeField] Vector2Int destinationCoord;
    public Vector2Int DestinationCoord { get {return destinationCoord;}}

    Node startNode;
    Node destinationNode;

    Node currentSearchNode;

    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    Queue<Node> frontier = new Queue<Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    void Awake() {
        gridManager = FindObjectOfType<GridManager>();

        if (gridManager != null) {
            grid = gridManager.Grid;
            startNode = grid[startCoord];
            destinationNode = grid[destinationCoord];
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        BreadthFirstSearch();
        return BuildPath();
    }

    private void ExploreNeighbours()
    {
        List<Node> neighbours = new List<Node>();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighbourCoordinates))
            {
                neighbours.Add(grid[neighbourCoordinates]);
            }
        }

        foreach (Node neighbour in neighbours)
        {
            if (!reached.ContainsKey(neighbour.coordinates) && neighbour.isWalkable) {
                neighbour.connectedTo = currentSearchNode;
                reached.Add(neighbour.coordinates, neighbour);
                frontier.Enqueue(neighbour);
            }
        }
    }

    void BreadthFirstSearch() {
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;

        frontier.Clear();
        reached.Clear();
        
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoord, startNode);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;

            ExploreNeighbours();

            if (currentSearchNode.coordinates == destinationCoord) {
                isRunning = false;
            }
        }
    }

    List<Node> BuildPath() {
        gridManager.ResetNodes();
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while (currentNode.connectedTo != null) {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;  
        }

        path.Reverse();
        
        return path;
    } 

    public bool WillBlockPath(Vector2Int coordinates) {
        
        if (grid.ContainsKey(coordinates)) {
            bool previousState = grid[coordinates].isWalkable;

            grid[coordinates].isWalkable = false;
            List<Node> newpath = GetNewPath();
            grid[coordinates].isWalkable = previousState;

            if (newpath.Count <= 1) {
                GetNewPath();
                return true; 
            }
        }

        return false;
    }
}
