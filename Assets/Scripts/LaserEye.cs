using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserEye : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField] float maxDistance;

  

    [Header("Head Move")]
    [SerializeField] Transform camTrans;
    [SerializeField] Transform head;

    AudioSource layserAudio;

    void Awake()
    {


        lineRenderer = GetComponent<LineRenderer>();
        layserAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootLaser();
            lineRenderer.enabled = true;

            if (!layserAudio.isPlaying)
            {
                layserAudio.Play();
            }

        }
        else
        {
            lineRenderer.enabled = false;
            head.forward = Vector3.Lerp(head.forward, head.parent.forward, Time.deltaTime * 5.0f);

            layserAudio.Stop();
        }


    }

    void ShootLaser()
    {
        lineRenderer.SetPosition(0, transform.position);
        RaycastHit hit;

        head.forward = Vector3.Lerp(head.forward, camTrans.right, Time.deltaTime * 5.0f);

        if (Physics.Raycast(transform.position, camTrans.forward, out hit, maxDistance))
        {
            if (hit.collider)
            {
                lineRenderer.SetPosition(1, hit.point);
            }

            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("hit maxwell");
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(100, hit.point, 0.25f);
                    hit.transform.gameObject.GetComponent<Enemy>().HP--;
                }

            }

            if(hit.transform.tag == "Broken")
            {
                //if(cube!=null && fragments != null)
                //{
                //cube.SetActive(false);
                //fragments.SetActive(true);
                //}
                hit.transform.gameObject.SetActive(false);
                //breakWallDict[hit.transform.gameObject].SetActive(true);
                hit.transform.parent.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.right * 5000);
        }
    }
}
