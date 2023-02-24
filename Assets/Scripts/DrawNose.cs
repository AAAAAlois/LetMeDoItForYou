using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNose : MonoBehaviour
{
    public float lineSpeed = 1f;
    public float lineWidth = 1f;
    public int maxPositions = 10000;

    private LineRenderer lineRenderer;
    private Vector3[] positions;
    private int currentIndex = 2;
    private Vector3 currentDirection = Vector3.right;



    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        positions = new Vector3[maxPositions];
        positions[0] = new Vector3(-2, 0, 0) + transform.position;
        positions[1] = transform.position;
        lineRenderer.positionCount = 2;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentDirection = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentDirection = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentDirection = Vector3.right;
        }

        // Move the current position of the line based on the current direction and speed
        currentIndex++;
        if (currentIndex >= maxPositions)
        {
            currentIndex = 0;
        }
        positions[currentIndex] = transform.position;
        transform.position += currentDirection * lineSpeed * Time.deltaTime;

        // Set the new positions for the line renderer
        int positionCount = Mathf.Min(lineRenderer.positionCount + 1, maxPositions);
        lineRenderer.positionCount = positionCount;
        lineRenderer.SetPositions(positions);
   
    }

   
}
