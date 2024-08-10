using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    private Camera _mainCamera;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = Camera.main;
        //_cameraTarget = GameObject.Find("/CameraTarget");
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        
        var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayhit.collider) return;

        //_navigate_value = rayhit.collider.gameObject.GetComponent<Navigate_Value>();
        
        
        rayhit.collider.gameObject.GetComponent<Object_Action>().getAction();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
