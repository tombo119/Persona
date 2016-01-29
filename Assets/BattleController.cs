using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour
{

    public static BattleController battleController;
    private PriorityQueue turnOrder = new PriorityQueue();
    private GameObject Player , Enemy, Dick;
    public ArrayList characterList = new ArrayList();

    [SerializeField] public Sprite green;
    [SerializeField] public Sprite red;

    private GameObject currentTurn = null;
    private int currentPriority = 0;

    void Start()
    {
        battleController = this;

        //Create Player and Enemy
        Player = createPlayer("Player", green, 5, 40);
        Enemy = createPlayer("Enemy", red, 0, 20);
        Dick = createPlayer("Dickbutt", red, 2, 100);

        //Add to turnOrder List
        turnOrder.insert(Player, 10);
        turnOrder.insert(Enemy, 20);
        turnOrder.insert(Dick, 20);

    }

    void Update()
    {
        //When previous turn is finished:
        //---Store current minimum priority
        //---Set current turn to top of queue
        //---Begin their turn
        if(currentTurn == null)
        {
            currentPriority = turnOrder.minPriority();
            currentTurn = turnOrder.removeMin();
            currentTurn.GetComponent<PlayerCharacter>().startTurn();
        }
    }

    private GameObject createPlayer(string name ,Sprite sprite , int startNode, int initialHealth)
    {
        GameObject battleChar = new GameObject();

        //Name the Object
        battleChar.name = name;

        //Attach Sprite to GameObject.
        SpriteRenderer renderer = battleChar.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        //Set starting position
        battleChar.transform.position = GraphController.graphController.GetNodeAt(startNode).transform.position;

        //Attach PlayerCharacter Script and set initial health and starting position
        PlayerCharacter playerScript = battleChar.AddComponent<PlayerCharacter>();
        playerScript.setHealth(initialHealth);
        playerScript.setNode(startNode);

        //Add to characterList
        characterList.Add(battleChar);

        return battleChar;
    }

    public void endTurn(int waitTime)
    {
        turnOrder.insert(currentTurn, currentPriority + waitTime);
        currentTurn = null;
    }
}
