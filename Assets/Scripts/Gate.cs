using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject crispsWarnUI;
    public GameObject successUI;

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
            if (CollectionUI.Instance.couldEnterNextLevel)
            {
                if (successUI.activeInHierarchy == false)
                {
                    successUI.SetActive(true);
                }
                Debug.Log("load next level");
            }
            else
            {
                crispsWarnUI.SetActive(true);
                StartCoroutine(Disappear());
            }
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2f);

        crispsWarnUI.SetActive(false); 
    }
}
