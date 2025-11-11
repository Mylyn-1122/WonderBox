using UnityEngine;
using System.Collections;

public class PlayerWaterGame : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            
            direction = Vector3.up * strength;
            gravity = 0;

        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        StartCoroutine(wait());
        gravity = -9.8f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Obs"))
        {
            FindFirstObjectByType<GameManager>().gameOver();
        }else if (other.gameObject.tag.Equals("Scoring"))
        {
            FindFirstObjectByType<GameManager>().incScore();
        }else if (other.gameObject.tag.Equals("Fish"))
        {
            FindFirstObjectByType<GameManager>().setWin();
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
    }
}
