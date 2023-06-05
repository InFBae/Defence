using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    Vector3 moveDir;
    private float zoomScroll;

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float padding;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;   
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }


    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void OnPointer(InputValue inputValue)
    {
        //moveDir = inputValue.Get<Vector2>();
        Vector2 mousePos = inputValue.Get<Vector2>();
        
        if (-10 <= mousePos.x && mousePos.x <= padding)
            moveDir.x = -1;
        else if(mousePos.x >= Screen.width - padding && mousePos.x <= Screen.width + 10) 
            moveDir.x = 1;
        else 
            moveDir.x = 0;

        if (-10 <= mousePos.y && mousePos.y <= padding)
            moveDir.y = -1;
        else if (mousePos.y >= Screen.height - padding && mousePos.y <= Screen.height + 10)
            moveDir.y = 1;
        else
            moveDir.y = 0;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * moveDir.y * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * moveSpeed * moveDir.x * Time.deltaTime, Space.World);
    }
    private void OnZoom(InputValue inputValue)
    {
        zoomScroll = inputValue.Get<Vector2>().y;
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward * zoomSpeed * zoomScroll * Time.deltaTime, Space.Self);
    }
}
