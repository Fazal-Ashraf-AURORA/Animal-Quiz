using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;

    [SerializeField]
    private Camera mainCamera; // Assign the main camera in the Inspector, or defaults to Camera.main

    private void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;

        // Automatically assign Main Camera if not set in Inspector
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        // Check for left mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }

        // Check for left mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }

        // Drag the object while the mouse button is held
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            transform.position = mousePosition + offset;
        }
    }

    private void OnMouseDown()
    {
        // Raycast to check if the object is clicked
        Vector3 mousePosition = GetMouseWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            // Calculate the offset between the object and the mouse cursor
            offset = transform.position - mousePosition;
            isDragging = true;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false; // Stop dragging
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered with: " + collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exited with: " + collision.gameObject.name);
    }

    // Helper Method to Get Mouse World Position
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = Mathf.Abs(mainCamera.transform.position.z); // Account for camera distance
        return mainCamera.ScreenToWorldPoint(screenPosition);
    }
}
