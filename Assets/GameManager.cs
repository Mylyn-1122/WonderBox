using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private Transform fish;
    private Vector3 fishPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fish = GameObject.Find("Fish").transform;
        fishPos = fish.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incScore()
    {
        score++;
        fishPos.x -= 1;
        fish.position = fishPos;
    }

    public void gameOver()
    {
       // Debug.Log("Game Over");
    }

    public void win()
    {
       // Debug.Log("You won!");
    }
}
