using UnityEngine;

public class R6_RPG_Game : MonoBehaviour
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

    
    private SpriteRenderer Enemy;
    private Sprite Enemy1;
    private Sprite Enemy2;
    private Sprite Enemy3;
    private Sprite Enemy4;

    private bool one;
    private bool two;
    private bool three;
    private bool four;
    
    private GameObject nav;

    private GameObject Attack;
    private GameObject Defend;
    private GameObject Hold;
    

    // Start is called before the first frame update
    void Start()
    {
        tempPlayer = GameObject.Find("Player").transform;
        tempEnemy = GameObject.Find("Enemy").transform;
        nav = GameObject.Find("nav");
        Attack = GameObject.Find("Attack");
        Defend = GameObject.Find("Defend");
        Hold = GameObject.Find("Hold");
        player = tempPlayer.GetComponent<RPGPlayer>();
        enemy = tempEnemy.GetComponent<RPGEnemy>();

        dialogueManager = FindFirstObjectByType<DialogueManager>();

        nav.GetComponent<SpriteRenderer>().enabled = false;
        nav.GetComponent<BoxCollider2D>().enabled = false;
        one = false;
        two = false;
        three = false;
        four = false;
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
            one = false;
            two = false;
            three = false; 
            four = false;

            Enemy.sprite = Enemy1;
            enemy.setHealth(-50);

        }
        else if (enemy.getHealth() <= 0)
        {
             if (one == false)
            {
                one = true;
                enemy.setHealth(-75);
            }
            else {
                if (two == false)
                {
                    two = true;
                    enemy.setHealth(-95);
                }
                else
                {
                    if (three == false){
                        three = true;
                    }
                    
                    else{
                             four = true;
                        }
                }
            }
            }
            Enemy.GetComponent<SpriteRenderer>().enabled = false;
            nav.GetComponent<SpriteRenderer>().enabled = true;
            nav.GetComponent<BoxCollider2D>().enabled = true;
            player.setHealth(-(100-player.getHealth()));
        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider.gameObject.Equals(nav))
            {
                if (one == true && two == false)
                {
                    Enemy.sprite = Enemy2;
                    Enemy.GetComponent<SpriteRenderer>().enabled = true;


                }
                else if (two == true && three == false)
                {
                    Enemy.sprite = Enemy3;
                    Enemy.GetComponent<SpriteRenderer>().enabled = true;


                }
                else if (three == true && four == false)
                {
                    Camera.main.transform.position = new Vector3(0, 40, -10);
                }
                else if (four == true)
                {
                    victor = true;
                    Enemy.sprite = Enemy4;
                    Enemy.GetComponent<SpriteRenderer>().enabled = true;

                }


                nav.GetComponent<SpriteRenderer>().enabled = false;
                nav.GetComponent<BoxCollider2D>().enabled = false;
            }

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
                message[0] = "The player has chosen to block the enemy's attack" + enemy.getHealth();
                dialogueFinished = false;
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
   
    
    /*
    // Edit for room 6
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



    // Edit for room 6
    [System.Serializable]
    public struct RPGMusicBox
    {
     public bool RPG1Complete;
    }
    */
}