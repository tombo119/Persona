using UnityEngine;
using System.Collections;

public abstract class BattleCharacter: MonoBehaviour
{
    protected int Health;
    protected bool myTurn = false;
    protected int currentNodeID;

    public void setHealth(int Health)
    {
        this.Health = Health;
    }

    public void setNode(int Node)
    {
        this.currentNodeID = Node;
    }

    public abstract void startTurn();
}
