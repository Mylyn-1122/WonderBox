using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Finale_RPG_Game : MonoBehaviour
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

    private GameObject Attack;
    private GameObject Defend;
    private GameObject Hold;

    private bool win1;
    private bool win2;

    private static int health;

    private VideoPlayer videoG;
    private VideoPlayer videoB;
    private bool animation2Finished = false;


    private GameObject home;

    // Start is called before the first frame update
    void Start()
    {
        tempPlayer = GameObject.Find("Player").transform;
        tempEnemy = GameObject.Find("Enemy").transform;
        Attack = GameObject.Find("Attack");
        Defend = GameObject.Find("Defend");
        Hold = GameObject.Find("Hold");
        player = tempPlayer.GetComponent<RPGPlayer>();
        enemy = tempEnemy.GetComponent<RPGEnemy>();

        dialogueManager = FindFirstObjectByType<DialogueManager>();

        videoG = GameObject.Find("GoodEnd").GetComponent<VideoPlayer>();
        videoG.isLooping = false;

        videoB = GameObject.Find("BadEnd").GetComponent<VideoPlayer>();
        videoB.isLooping = false;
        win1 = false;
        win2 = false;

        home = GameObject.Find("home");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        if (player.getHealth() <= 0)
        {
            victor = false;
            Debug.Log("Player Lost!");

            videoB.gameObject.SetActive(true);
            videoB.Play();

            if (animation2Finished)
            {
                SceneManager.LoadScene("Room1Final", LoadSceneMode.Single);
            }
            videoB.loopPointReached += EndReached;
            

        }
        else if (enemy.getHealth() <= 0)
        {
            if (!victor)
            {
                if (win2)
                {
                    victor = true;
                    Debug.Log("Player Won!");

                    videoG.gameObject.SetActive(true);
                    videoG.Play();

                    if (animation2Finished)
                    {
                        Camera.main.transform.position = new Vector3(0, 20, -10);
                    }
                    videoG.loopPointReached += EndReached;
                    Camera.main.transform.position = new Vector3(0, 20, -10);

                }
                if (win1 && !win2)
                {
                    win2 = true;
                    health = -100;
                    enemy.setHealth(health);
                    player.setHealth(-(100 - player.getHealth()));
                    message[0] = "You: We lost our dreams, hopes, any possible life we may have had where we are happy…what's the point of going back?" + "\n" +
                        "It’s still worth it to try! We can’t change the past but we lose our future if we only wallow in our memories! I know it hurts, but we have to try! Even if it’s scary, even if we might fail again. This can’t be the end."
                        ;
                    dialogueFinished = false;

                }
                if (!win1)
                {
                    win1 = true;
                    health = -75;
                    enemy.setHealth(health);
                    player.setHealth(-(100 - player.getHealth()));

                    message[0] = "Creature: Who are you anymore! We replaced ourselves, can you still recognize the person in the mirror?" + "\n" + "You: I can’t say I do, but that's fine! Nothing stays the same forever; isn’t that the point of life? To change and grow until we can look back and be proud of ourselves?";
                    dialogueFinished = false;

                }
            }
            
            

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
                    if (enemy.getHealth() < 1)
                    {
                        // fix this
                    }
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
                    message[0] = "The player has chosen to block the enemy's attack" + enemy.getHealth();
                    dialogueFinished = false;
                }else if(hit.collider.gameObject.Equals(home)){
                    SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
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

    public static bool getVictor() {
        return victor;
    }
    public static void setVictor(bool value)
    {
        victor = value;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.gameObject.SetActive(false);
        animation2Finished = true;
    }

    public static void setH()
    {
        health = -200;
    }
}
/*
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

} (remove its for the public class)

[System.Serializable]
public struct RPGMusicBox
{
    public bool RPG1Complete;
}
*/
