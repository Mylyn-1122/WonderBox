using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartGame : MonoBehaviour
{
    private GameObject start;
    private VideoPlayer player;
    private bool animation2Finished = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start = GameObject.Find("Play");
        player = GameObject.Find("Prologe").GetComponent<VideoPlayer>();
        player.isLooping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(start))
                {
                    player.gameObject.SetActive(true);
                    player.Play();
                }
            }
        }
        if (animation2Finished)
        {
            SceneManager.LoadScene("Room1Final", LoadSceneMode.Single);
        }
        player.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.gameObject.SetActive(false);
        animation2Finished = true;
    }
}
