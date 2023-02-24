using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheckTerrain : MonoBehaviour
{
    [SerializeField] Transform restartPoint;
    [SerializeField] GameObject playerPrefab;

 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Debug.Log(other.transform.name);
            Destroy(other.transform.parent.parent.parent.gameObject);
            Instantiate(playerPrefab, restartPoint.position, Quaternion.identity);
        }
    }
}
