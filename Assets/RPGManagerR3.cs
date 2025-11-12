using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;




public class RPGManagerR3 : MonoBehaviour
{
    private Transform tempPlayer;
    private Transform tempEnemy;
    private RPGPlayer player;
    private RPGEnemy enemy;
    private int RoledMultiplier;
    public bool DefP = false;
    private static bool victor;

    private GameObject Attack;
    private GameObject Defend;
    private GameObject Hold;

    private DialogueManager dialogueManager;
    private bool dialogueFinished = true;
    private string[] message = new string[1];

    private bool playerTurn = true;

    private SpriteRenderer Enemy;
    public Sprite Enemy2;
    public Sprite Enemy3;

    private SpriteRenderer endScreen;
    private SpriteRenderer bg;

    public Sprite Lose;

    private bool one;
    private bool two;
    private bool three;

    private GameObject nav;




    // Start is called before the first frame update
    void Start()
    {
        tempPlayer = GameObject.Find("Player").transform;
        tempEnemy = GameObject.Find("Enemy").transform;
        player = tempPlayer.GetComponent<RPGPlayer>();
        enemy = tempEnemy.GetComponent<RPGEnemy>();
        Attack = GameObject.Find("Attack");
        Defend = GameObject.Find("Defend");
        Hold = GameObject.Find("Hold");
        nav = GameObject.Find("Nav");

        dialogueManager = FindFirstObjectByType<DialogueManager>();

        Enemy = GameObject.Find("Enemy").GetComponent<SpriteRenderer>();

        endScreen = GameObject.Find("EndArt").GetComponent<SpriteRenderer>();
        one = false;
        two = false;
        three = false;
        bg = GameObject.Find("background").GetComponent<SpriteRenderer>();

        nav.GetComponent<SpriteRenderer>().enabled = false;
        nav.GetComponent<BoxCollider2D>().enabled = false;
        victor = false;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);


        if (player.getHealth() <= 0)
        {
            endScreen.sprite = Lose;
            Camera.main.transform.position = new Vector3(0, 40, -10);

        }
        else if (enemy.getHealth() <= 0)
        {
            if (one == false)
            {
                one = true;
                enemy.setHealth(-5);
            }
            else {
                if (two == false)
                {
                    two = true;
                    enemy.setHealth(-5);
                }
                else
                {
                    three = true;
                }
            }

            Enemy.GetComponent<SpriteRenderer>().enabled = false;
            nav.GetComponent<SpriteRenderer>().enabled = true;
            nav.GetComponent<BoxCollider2D>().enabled = true;

            player.setHealth(-(100-player.getHealth()));


        }
        if (Input.GetMouseButtonDown(0))
        {
            

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(Attack) && playerTurn == true)
                {
                    enemy.setHealth(player.getAttack());
                    playerTurn = false;
                    message[0] = "The player attacked the enemy with attack power of " + player.getAttack() + ", enemy has " + enemy.getHealth();
                    dialogueFinished = false;
                    player.setAttackMultiplier(0);
                }
                else if (hit.collider.gameObject.Equals(Hold) && playerTurn == true)
                {
                    RoledMultiplier = Random.Range(2, 5);
                    player.setAttackMultiplier(RoledMultiplier);
                    playerTurn = false;
                    message[0] = "The player rolled an attack multiplier of " + RoledMultiplier + ", the player now has an attack multiplier of " + player.getAttackMultiplier();
                    dialogueFinished = false;
                }
                else if (hit.collider.gameObject.Equals(Defend) && playerTurn == true)
                {
                    DefP = true;
                    playerTurn = false;
                    message[0] = "The player has chosen to block the enemy's attack. The enemy has " + enemy.getHealth();
                    dialogueFinished = false;
                }

                if (hit.collider.gameObject.Equals(nav))
                {
                    if (one == true && two == false)
                    {
                        Enemy.sprite = Enemy2;
                        Enemy.GetComponent<SpriteRenderer>().enabled = true;
                        bg.color = new Color32(107, 255, 102, 100);
                        

                    }
                    else if (two == true && three == false)
                    {
                        Enemy.sprite = Enemy3;
                        Enemy.GetComponent<SpriteRenderer>().enabled = true;
                        bg.color = new Color32(0, 111, 231, 255);
                        

                    }
                    else if (three == true)
                    {
                        Camera.main.transform.position = new Vector3(0, 40, -10);
                        victor = true;
                        SaveGameManager.RPG3 = true;
                    }

                    nav.GetComponent<SpriteRenderer>().enabled = false;
                    nav.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }

        if (!playerTurn && dialogueFinished)
        {
            if (DefP == true)
            {
                if (enemy.getAttack() - player.getDefense() < 0)
                {
                    player.setHealth(0);
                }
                else
                {
                    player.setHealth(enemy.getAttack() - player.getDefense());
                }
            }
            else
            {
                player.setHealth(enemy.getAttack());
            }
            message[0] = "The enemy attacked the player, player has " + player.getHealth();
            dialogueFinished = false;
            playerTurn = true;
            DefP = false;
        }

        if (!dialogueFinished)
        {
            dialogueManager.ShowBox(message);
        }
        if (!dialogueFinished && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueFinished = true;
        }



    }

    public static bool getVictor()
    {
        return victor;
    }

    #region Save and Load
    private void ls()
    {
        SceneManager.LoadScene("Room3");
    }

    public void Save(ref RPG3 data)
    {
        data.RPG3Complete = getVictor();
    }

    public void Load(RPG3 data)
    {
        victor = data.RPG3Complete;
    }
    #endregion

}
[System.Serializable]
public struct RPG3
{
    public bool RPG3Complete;
}
