using UnityEngine;

public class spawnStars : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void starOne()
    {
        GameObject obs = Instantiate(star1, transform.position, Quaternion.identity);
        obs.transform.position = new Vector3(27, -16, 0);
        obs.name = "StarB";
        obs.AddComponent<MoveableObject>();
        obs.AddComponent<BoxCollider2D>();

        Vector3 currentScale = transform.localScale;
        Vector3 newScale = new Vector3
        (
            currentScale.x * (float)0.07,
            currentScale.y * (float)0.07,
            currentScale.z * 1
        );
        obs.transform.localScale = newScale;
    }
    public void starTwo()
    {
        GameObject obs = Instantiate(star2, transform.position, Quaternion.identity);
        obs.transform.position = new Vector3(21, -23, 0);
        obs.name = "StarY";
        obs.AddComponent<MoveableObject>();
        obs.AddComponent<BoxCollider2D>();

        Vector3 currentScale = transform.localScale;
        Vector3 newScale = new Vector3
        (
            currentScale.x * (float)0.07,
            currentScale.y * (float)0.07,
            currentScale.z * 1
        );
        obs.transform.localScale = newScale;
    }
    public void starThree()
    {
        GameObject obs = Instantiate(star3, transform.position, Quaternion.identity);
        obs.transform.position = new Vector3(12, -17, 0);
        obs.name = "StarR";
        obs.AddComponent<MoveableObject>();
        obs.AddComponent<BoxCollider2D>();

        Vector3 currentScale = transform.localScale;
        Vector3 newScale = new Vector3
        (
            currentScale.x * (float)0.07,
            currentScale.y * (float)0.07,
            currentScale.z * 1
        );
        obs.transform.localScale = newScale;
    }
}
