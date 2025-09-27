using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

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
            SaveSystem.Save();
            Debug.Log("saved");
            Debug.Log(Application.persistentDataPath);
        }

        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            SaveSystem.Load();
            Debug.Log("loaded");
        }
    }
}
