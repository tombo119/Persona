using UnityEngine;
using System.Collections;

public class GraphController : MonoBehaviour {

    private bool[,] adjacencyMatrix;
    private int Nodes = 9;
    [SerializeField] private GameObject nodePrefab;
    private GameObject[] nodeArray;
    public static GraphController graphController;

    void Start ()
    {
        graphController = this; 
        CreateMatrix();
        InstantiateNodes();
    }
	
	void Update ()
    {

	}

    void CreateMatrix ()
    {
        adjacencyMatrix = new bool [Nodes,Nodes];
        //Set all connections to false
        for(int i = 0; i < Nodes; i++)
        {
            for(int j = 0; j < Nodes; j++)
            {
                adjacencyMatrix[i,j] = false;
            }
        }

        //Fill in adjacency Matrix
        adjacencyMatrix[0,1] = true;
        adjacencyMatrix[1,0] = true;
        adjacencyMatrix[0,3] = true;
        adjacencyMatrix[3,0] = true;
        adjacencyMatrix[0,4] = true;
        adjacencyMatrix[4,0] = true;
        adjacencyMatrix[1,2] = true;
        adjacencyMatrix[2,1] = true;
        adjacencyMatrix[2,4] = true;
        adjacencyMatrix[4,2] = true;
        adjacencyMatrix[2,5] = true;
        adjacencyMatrix[5,2] = true;
        adjacencyMatrix[3,6] = true;
        adjacencyMatrix[6,3] = true;
        adjacencyMatrix[4,6] = true;
        adjacencyMatrix[6,4] = true;
        adjacencyMatrix[4,8] = true;
        adjacencyMatrix[8,4] = true;
        adjacencyMatrix[5,8] = true;
        adjacencyMatrix[8,5] = true;
        adjacencyMatrix[6,7] = true;
        adjacencyMatrix[7,6] = true;
        adjacencyMatrix[7,8] = true;
        adjacencyMatrix[8,7] = true;
    }

    void InstantiateNodes ()
    {
        nodeArray = new GameObject[Nodes];
        for(int i = 0; i < Nodes; i++)
        {
            //Sets positions of the nodes, below is for testing purposes, to be changed later.
            int gap = 3;
            Vector3 nodePosition = new Vector3(-1*(gap) + (gap)*(i % 3) , -1*(gap) + (gap) * (Mathf.Floor(i / 3)) ,  0);

            //Instantiate nodes.
            nodeArray[i] = (GameObject) Instantiate(nodePrefab, nodePosition, Quaternion.identity);
            
        }
    }

    public GameObject GetNodeAt (int index)
    {
        return nodeArray[index];
    }

    public bool nodesConnected(int u, int v)
    {
        return adjacencyMatrix[u, v];
    }

    public int totalNodes()
    {
        return Nodes;
    }

  /*  public bool nodeFree(int Node)
    {
        for(int i = 0; i < BattleController.battleController.characterList.Count; i++)
        {
            if(BattleController.battleController.characterList[i]. == )
        }
    } */
}
