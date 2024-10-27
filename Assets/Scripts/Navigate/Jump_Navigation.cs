using UnityEngine;
using UnityEngine.EventSystems;

public class Jump_Navigation : MonoBehaviour, IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Vector3 destination;
    private GameObject _cameraTarget;
    [SerializeField] private Camera mainCamera;

    void Start()
    {
        _cameraTarget = GameObject.Find("/CameraTarget");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _cameraTarget.transform.position = new Vector3(destination.x, destination.y, -10);
        mainCamera.GetComponent<Transform>().position = _cameraTarget.transform.position;


    }
}
