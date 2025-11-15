using UnityEngine;

public class Finale_Dialogue : MonoBehaviour
{
    private DialogueManager dMan;
    public InventoryManager inventoryManager;
    private bool idk = true;
    private string[] R1 = {"Ouch, where am I-","Oh my god. What is that?!"};
    private bool text1 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (idk == true)
        {
            if (!text1)
            {
                text1 = dMan.ShowBox(R1);
                idk = false;
            }
         }
        
        
    }
}
