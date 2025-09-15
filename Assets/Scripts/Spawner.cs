using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // Update is called once per frame
    private void Spawn()
    {
        GameObject obs = Instantiate(prefab, transform.position,Quaternion.identity);
        obs.transform.position += Vector3.up * Random.Range(minHeight,maxHeight);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn)); 
    }
}
