using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseCollision : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;

    public bool isGameOver = false;
    public bool isReachExit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setNoseCollision(lineRenderer);
    }

    void setNoseCollision(LineRenderer line)
    {
        MeshCollider collider = GetComponent<MeshCollider>();

        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }


        Mesh mesh = new Mesh();
        line.BakeMesh(mesh, true);

        collider.sharedMesh = mesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag != "Exit")
        {
            Debug.Log("over");
            isGameOver = true;
        }
        else
        {
            Debug.Log("Exit");
            isReachExit = true;
        }
    }


}
