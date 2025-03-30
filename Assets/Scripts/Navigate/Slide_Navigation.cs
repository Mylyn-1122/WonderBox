using UnityEngine;
using UnityEngine.EventSystems;

public class Slide_Navigation : MonoBehaviour, IPointerClickHandler
{ 
    [SerializeField] Vector3 destination;
    private GameObject _cameraTarget;
    [SerializeField] private Camera mainCamera;


    

    void Start()
    {
        _cameraTarget = GameObject.Find("/CameraTarget");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        mainCamera.GetComponent<Camera_Follor>().enabled = true;
        _cameraTarget.transform.position = new Vector3(destination.x, destination.y, destination.z);

        
    }




   
}
