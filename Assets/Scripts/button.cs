using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField]Material green;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("jump button");
            GameObject button = transform.parent.gameObject;
            Renderer renderer = button.GetComponent<Renderer>();
            renderer.material = green;

            if(button.transform.GetChild(1).gameObject.active == false)
            {
                button.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}
