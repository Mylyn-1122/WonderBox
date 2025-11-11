using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private Transform fish;
    private Vector3 fishPos;
    private static bool win;
    private Vector3 ogFishPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fish = GameObject.Find("Fish").transform;
        fishPos = fish.position;
        ogFishPos = fish.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            ls();
        }
    }

    public void incScore()
    {
        score++;
        fishPos.x -= 1;
        fish.position = fishPos;
    }

    public void gameOver()
    {
        fish.position = ogFishPos;
    }

    public static bool victor()
    {
        return win;
    }

    public void setWin()
    {
        win = true;
    }

    #region Save and Load
    private void ls()
    {
        SceneManager.LoadScene("Room4");
    }

    public void Save(ref WaterGame data)
    {
        data.WaterGameComplete = victor();
    }

    public void Load(WaterGame data)
    {
        win = data.WaterGameComplete;
    }
    #endregion

}

[System.Serializable]
public struct WaterGame
{
    public bool WaterGameComplete;
}

