using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RPGManagerR1 : MonoBehaviour
{
    private Transform tempPlayer;
    private Transform tempEnemy;
    private RPGPlayer player;
    private RPGEnemy enemy;
    private int RoledMultiplier;
    public bool DefP = false;

    private DialogueManager dialogueManager;
    private bool dialogueFinished = true;
    private string[] message = new string[1];

    private bool playerTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        tempPlayer = GameObject.Find("Player").transform;
        tempEnemy = GameObject.Find("Enemy").transform;
        player = tempPlayer.GetComponent<RPGPlayer>();
        enemy = tempEnemy.GetComponent<RPGEnemy>();

        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider.gameObject.tag == "Attack" && playerTurn == true)
            {
                enemy.setHealth(player.getAttack());
                playerTurn = false;
                if (enemy.getHealth() < 1)
                {
                    SceneManager.LoadScene("Room3");
                }
                message[0] = "The player attacked the enemy with attack power of " + player.getAttack() + ", enemy has " + enemy.getHealth();
                dialogueFinished = false;
                player.setAttackMultiplier(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) && playerTurn == true)
        {
            RoledMultiplier = Random.Range(2, 5);
            player.setAttackMultiplier(RoledMultiplier);
            playerTurn = false;
            message[0] = "The player rolled an attack multiplier of " + RoledMultiplier + ", the player now has an attack multiplier of " + player.getAttackMultiplier();
            dialogueFinished = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && playerTurn == true)
        {
            DefP = true;
            playerTurn = false;
            message[0] = "The player has chosen to block the enemy's attack" + enemy.getHealth();
            dialogueFinished = false;
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

        if (player.getHealth() <= 0)
        {
            SceneManager.LoadScene("Room1");
            Debug.Log("Player Lost");
        }
        else if (enemy.getHealth() <= 0)
        {
            SceneManager.LoadScene("Room1");
            Debug.Log("Player Won!");

        }

    }

}
