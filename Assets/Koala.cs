using UnityEngine;

public class Koala : MonoBehaviour
{
    SpriteRenderer bear;

    public Sprite bearFixed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bear = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ThreadGameManager.winGet())
        {
            bear.sprite = bearFixed;
        }
    }
}
