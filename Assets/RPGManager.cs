using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;




public class RPGManagerR1 : MonoBehaviour
{
    private Transform tempPlayer;
    private Transform tempEnemy;
    private RPGPlayer player;
    private RPGEnemy enemy;
    private int RoledMultiplier;
    public bool DefP = false;
    private static bool victor;

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

        dialogueManager = FindFirstObjectByType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.getHealth() <= 0)
        {
            victor = false;
            Debug.Log("Player Lost!");
            SaveGameManager.RPG1 = false;
            SceneManager.LoadScene("RPG1");

        }
        else if (enemy.getHealth() <= 0)
        {
            victor = true;
            Debug.Log("Player Won!");
            SaveGameManager.RPG1 = true;
            SceneManager.LoadScene("RPG1");




        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        }
        if (Input.GetKeyDown(KeyCode.A) && playerTurn == true)
        {
            enemy.setHealth(player.getAttack());
            playerTurn = false;
            if (enemy.getHealth() < 1)
            {
                SaveGameManager.RPG1 = true;

                SceneManager.LoadScene("Room1Final");
            }
            message[0] = "The player attacked the enemy with attack power of " + player.getAttack() + ", enemy has " + enemy.getHealth();
            dialogueFinished = false;
            player.setAttackMultiplier(0);
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



    }

    public static bool getVictor() {
        return victor;
    }
    public static void setVictor(bool value)
    {
        victor = value;
    }


    #region Save and Load
    private void ls()
    {
        SceneManager.LoadScene("Room1Final");
    }

    public void Save(ref RPGMusicBox data)
    {
        data.RPG1Complete = getVictor();
    }

    public void Load(RPGMusicBox data)
    {
        victor = data.RPG1Complete;
    }
    #endregion

}

[System.Serializable]
public struct RPGMusicBox
{
    public bool RPG1Complete;
}