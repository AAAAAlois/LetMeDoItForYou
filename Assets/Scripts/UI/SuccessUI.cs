using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuccessUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectedCoinsPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        StopVoice();

        collectedCoinsPoint.text = CollectionUI.Instance.coinPoint.ToString() + " Coins";
    }

    void StopVoice()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.gameObject != gameObject)
            {
                audioSource.Stop();
            }
        }
    }
}
