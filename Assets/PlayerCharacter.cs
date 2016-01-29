using UnityEngine;
using System.Collections;
using System;

public class PlayerCharacter : BattleCharacter {

    private int targetNodeID;
    private GameObject targetNode;
    private int[] reachableNodes;
    private GameObject currentNode;
    bool targetChosen = false;

    void Start () {
        
	}
	
	void Update ()  {
        if(myTurn == true)
        {
            //---TEST-CODE---
            reachableNodes = new int[GraphController.graphController.totalNodes()];
            int counter = 0;
            

            while (targetChosen == false)
            {
                for (int i = 0; i < GraphController.graphController.totalNodes(); i++)
                {
                    if (GraphController.graphController.nodesConnected(currentNodeID, i))
                    {
                        reachableNodes[counter] = i;
                        counter++;
                    }
                }

                if (counter == 0)
                {
                    targetNodeID = currentNodeID;
                    targetNode = GraphController.graphController.GetNodeAt(targetNodeID);
                    currentNode = GraphController.graphController.GetNodeAt(currentNodeID);
                    targetChosen = true;
                }
                else
                {
                    targetNodeID = reachableNodes[UnityEngine.Random.Range(0, counter)];
                    targetNode = GraphController.graphController.GetNodeAt(targetNodeID);
                    currentNode = GraphController.graphController.GetNodeAt(currentNodeID);
                    targetChosen = true;

                }

               

            }

            if(Vector3.Distance(targetNode.transform.position , this.transform.position) <= 0.1f)
            {
                this.transform.position = targetNode.transform.position;
                currentNodeID = targetNodeID;
                currentNode = targetNode;
                targetChosen = false;

                myTurn = false;
                BattleController.battleController.endTurn(UnityEngine.Random.Range(0, 20));

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, 1f * Time.deltaTime);
            }

            //---END---
        }
	}

    public override void startTurn()
    {
        print(this.name + ": Its my turn");
        myTurn = true;
    }

}
