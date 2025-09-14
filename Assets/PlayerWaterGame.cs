using UnityEngine;

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
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

}
