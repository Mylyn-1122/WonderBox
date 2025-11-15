using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MemoryShards : MonoBehaviour
{
    public List<Sprite> images;
    public List<string> text;
    public static int count;

    private GameObject next;
    private GameObject last;
    private GameObject forget;

    private GameObject pictures;
    private GameObject words;

    public static int max;

    public static bool forgort;

    private int newCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        SaveGameManager.Instance.MemoryShards = this;
    }

    void Start()
    {
        count = 0;
        next = GameObject.FindGameObjectWithTag("NextPage");
        last = GameObject.FindGameObjectWithTag("LastPage");
        forget = GameObject.FindGameObjectWithTag("Forget");

        pictures = GameObject.FindGameObjectWithTag("Picture");

        words = GameObject.FindGameObjectWithTag("Words");

        pictures.GetComponent<Image>().enabled = false;
        words.GetComponent<TextMeshProUGUI>().enabled = false;

        last.GetComponent<Image>().enabled = false;
        last.GetComponent<BoxCollider2D>().enabled = false;

        next.GetComponent<Image>().enabled = false;
        next.GetComponent<BoxCollider2D>().enabled = false;

        forget.GetComponent<Image>().enabled = false;
        forget.GetComponent<BoxCollider2D>().enabled = false;

        pictures.GetComponent<Image>().sprite = images[count];
        words.GetComponent<TextMeshProUGUI>().text = text[count];

        //images = new Sprite[9];
        //text = new string[9];
        max = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (words.GetComponent<TextMeshProUGUI>().enabled)
        {
            last.GetComponent<BoxCollider2D>().enabled = true;
            next.GetComponent<BoxCollider2D>().enabled = true;
            forget.GetComponent<BoxCollider2D>().enabled = true;
        }
        */

        pictures.GetComponent<Image>().sprite = images[count];
        words.GetComponent<TextMeshProUGUI>().text = text[count];

        if (forgort)
        {
            if (images.Count > 1)
            {
                if (count == max)
                {
                    newCount = count - 1;
                }
                images.RemoveAt(count);
                text.RemoveAt(count);
                count = newCount;
            }
            forgort = false;
        }

        //Debug.Log(count);

        pictures.GetComponent<Image>().sprite = images[count];
        words.GetComponent<TextMeshProUGUI>().text = text[count];
    }
        

        
     

    public static void incCount()
    {
        if (count < max)
        {
            count++;

        }
    }

    public static void decCOunt()
    {
        if (count >= 1)
        {
            count--;
            
        }
    }

    public static void forgor()
    {
        forgort = true;

        max--;
        
    }

    #region save and load

    public void Save(ref MemoryData data)
    {
        data.maxData = max;
        
    }

    public void Load(MemoryData data)
    {
        
        
            max = data.maxData;
            
        
    }



    #endregion


}

[System.Serializable]
public struct MemoryData
{
    public int maxData;
    

}
