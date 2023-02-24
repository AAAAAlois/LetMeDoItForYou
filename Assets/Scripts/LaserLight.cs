using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLight : MonoBehaviour
{
    LineRenderer lineRenderer;

    [Header("Player Reference")]
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform RestartPoint;

    [Header("Move Laser")]
    [SerializeField] bool isLaserMove;
    [SerializeField] float speed;

    Vector3 startPos;
    [SerializeField] Vector3 endPos;
    bool isMovingToEnd = true;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CreateLaser();

        if (isLaserMove)
        {
            LaserMove();
        }

    }

    void CreateLaser()
    {
        lineRenderer.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            if (hit.collider)
            {
                lineRenderer.SetPosition(1, hit.point);
            }

            if (hit.transform.tag == "Player")
            {
                Destroy(hit.transform.parent.gameObject);
                //Destroy(player);
                Instantiate(playerPrefab, RestartPoint.position, Quaternion.identity);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.right * 5000);
        }
    }

    void LaserMove()
    {
        float step = speed * Time.deltaTime;
        if (isMovingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            if (transform.position == endPos)
            {
                isMovingToEnd = false;

            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (transform.position == startPos)
            {
                isMovingToEnd = true;
            }
        }

    }



}
