using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlayer : MonoBehaviour
{
    public static BgmPlayer instance = null;


    private void KeepBGM()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
