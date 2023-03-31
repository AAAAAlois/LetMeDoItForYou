using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionUI : MonoBehaviour
{
    static public CollectionUI Instance;

    public int coinPoint = 0;
    public int crispsPoint = 0;
    private int lastFrameCrispsPoint = 0;
    public int neededCrispsPoint;
    public int allCrispsPoint;

    public bool couldEnterNextLevel = false;

    [SerializeField] private TextMeshProUGUI coinPointText;
    [SerializeField] private Transform crispsContainer;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoint();

        if(crispsPoint == neededCrispsPoint)
        {
            couldEnterNextLevel = true;
        }
    }

    void UpdatePoint()
    {
        coinPointText.text = coinPoint.ToString();

        if(lastFrameCrispsPoint != crispsPoint && crispsPoint <= neededCrispsPoint)
        {
            Transform currentCrisps = crispsContainer.GetChild(crispsPoint-1);
            currentCrisps.GetChild(0).gameObject.SetActive(true);

            lastFrameCrispsPoint = crispsPoint;
        }
        else if(lastFrameCrispsPoint != crispsPoint && crispsPoint <= allCrispsPoint)
        {
            Transform moreCrisps = crispsContainer.GetChild(crispsPoint - 1);
            moreCrisps.gameObject.SetActive(true);
        }
    }
}
