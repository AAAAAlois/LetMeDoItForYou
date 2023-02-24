using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chips : MonoBehaviour
{
    BgmPlayer bgmPlayer;

    [SerializeField] float rotationSpeed = 10.0f;
    [SerializeField] GameObject succcessPanel;

    public bool isSuccess = false;

    AudioSource successAudio;

    private void Awake()
    {
        bgmPlayer = FindObjectOfType<BgmPlayer>();
        successAudio = GetComponent<AudioSource>();
        //successAudio.Pause();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        if (succcessPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (isSuccess)
        {
            if (!successAudio.isPlaying)
            {
                successAudio.Play();
            }

            bgmPlayer.GetComponent<AudioSource>().Stop();
        }
        else
        {
            successAudio.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Time.timeScale = 1f;
            succcessPanel.SetActive(true);

            isSuccess = true;
        }
    }
}
