using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject background;
    public Text dtext;
    private string[] strings;
    private int count = 1;

    bool dialogueActive = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (count == strings.Length)
            {
                background.SetActive(false);
                dialogueActive = false;
                count = 0;
            }
            dtext.text = strings[count];
            count++;
        }
    }

    public bool ShowBox(string[] dialogue)
    {
        dialogueActive = true;
        background.SetActive(true);
        dtext.text = dialogue[0];
        strings = dialogue;
        return true;
    }
}
