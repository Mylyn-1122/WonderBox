using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class SaveGameManager : MonoBehaviour
{
    private static SaveGameManager instance;

    public static SaveGameManager Instance
    {
        get
        {
            if (!Application.isPlaying)
            {
                return null;
            }

            if (instance == null)
            {
                Instantiate(Resources.Load<SaveGameManager>("SaveGameManager"));
            }

            return instance;
        }
    }

    public Collectable Collectable { get; set; }
    public StainedGlassWindowGame StainedGlassWindowGame { get; set; }
    public SceneData SceneData { get; set; }
    public SceneLoad SceneLoad { get; set; }

    public OldTelescope OldTelescope { get; set; }
    public TVR2 TVR2 { get; set; }
    public KeyShardGame KeyShardGame { get; set; }
    public R2SaveMan saveManR2 { get; set; }

    public WaterGame WaterGame { get; set; }

    public ClockRotGame ClockRotGame { get; set; }
    public LockGameR3 LockGameR3 { get; set; }
    public saveManR3 saveManR3 { get; set; }

    public ThreadGameMan ThreadGameMan { get; set; }
    public watchGame watchGame { get; set; }
    public R5Collect R5Collect { get; set; }

    public skeleGameManager skeleMan { get; set; }
    public TrashGame TrashGame { get; set; }
    public R6SaveData R6SaveData { get; set; }

    public StarGameR7 StarGameR7 { get; set; }
    public R7SaveData R7SaveData { get; set; }

    public R8StarGame StarGameR8 { get; set; }
    public Projector_Game projectorR8 { get; set; }
    public R9_Trash_Game trashR8 { get; set; }
    public R8SaveData R8SaveData { get; set; }

    public LockGameR4 LockGameR4 { get; set; }
    public R4_ShardGame R4ShardGame { get; set; }
    public saveManR4 saveManR4 { get; set; }

    public Rope_Code Rope_Code { get; set; }

    public R9_ShardGame R9Shard { get; set; }
    public R9SaveData R9SaveData {get;set;}

    public Mirror_Shard_Game MirrorShard { get; set; }
    public Suitcase_Case_Code Suitcase { get; set; }
    public Ticket_Shard_Minigame TicketShard { get; set; }
    public TVR10 TVR10 { get; set; }

    public static bool SaveSignal = false;
    public static bool RPG1 = false;
    public static bool[] R1Stars = new bool [3];
    public static bool JustFinRPG1 = false;
    public static bool LoadSignal = false;
    public static bool RPG3 = false;
    public static bool RPG3Fin = false;
    public static bool wg = false;
    public static bool wgFin = false;
    public static bool R5Ticket = false;
    public static bool R5Watch = false;


    public static bool R1 = false;
    public static bool R2 = false;
    public static bool R3 = false;
    public static bool R4 = false;
    public static bool R5 = false;
    public static bool R6 = false;
    public static bool R7 = false;
    public static bool R8 = false;
    public static bool R9 = false;
    public static bool R10 = false;

    public static bool Boss = false;

    private bool _isSaving;
    private bool _isLoading;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
       


    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.numpad0Key.wasPressedThisFrame)
        {
            SaveSignal = true;
        }

        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            LoadSignal = true;
        }

        //Debug.Log(RPG1);

        if (SaveSignal && !_isSaving)
        {
            SaveAsync();
            SaveSignal = false;
        }

        if (LoadSignal && !_isLoading)
        {
            LoadAsync();
            LoadSignal = false;
        }
    }

    public void saveGame()
    {
        SaveSignal = true;
    }

    public void loadGame()
    {
        LoadSignal = true;
    }

    public async void SaveAsync()
    {
        _isSaving = true;
        await SaveSystem.SaveAsynchronously();
        _isSaving = false;
    }
    public async void LoadAsync()
    {
        _isLoading = true;
        await SaveSystem.LoadAsync();
        _isLoading = false;
    }
}

