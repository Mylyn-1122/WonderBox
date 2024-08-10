using UnityEngine;
using UnityEngine.SceneManagement;

public class Object_Action : MonoBehaviour
{
    [SerializeField] string action;
    [SerializeField] Vector3 destination;
    [SerializeField] string scene;

    private GameObject _cameraTarget;

    void Start()
    {
        _cameraTarget = GameObject.Find("/CameraTarget");
    }

    public void getAction()
    {
       
        if (action == "destine")
        {
            getDestination();
        }
        if (action == "loadScene")
        {
            loadScene();
        }
        if (action == "unloadScene")
        {
            Debug.Log("unload");
        }
        if (action == "changeScene")
        {
            Debug.Log("change");
        }
    }

    private void getDestination()
    {
        _cameraTarget.transform.position = new Vector3 (destination.x,destination.y,destination.z);
        Debug.Log("work");
    }

    public void loadScene()
    {
        
    }

}
