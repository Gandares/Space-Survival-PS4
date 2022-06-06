using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;
    private int health = 3;
    public Text points;
    private int numPoints = 0;
    public GameObject trophymanager;

    void Start()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        points = GetComponentInChildren<Text>();
        points.text=numPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        switch(health){
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            default:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
        }
    }

    public void setPoints(int newPoints){
        numPoints += newPoints;
        points.text = numPoints.ToString();
        if (numPoints >= 100)
            trophymanager.GetComponent<TrophyManager>().UnlockTrophy(0);
        if (numPoints >= 1000)
            trophymanager.GetComponent<TrophyManager>().UnlockTrophy(1);
        if (numPoints >= 3000)
            trophymanager.GetComponent<TrophyManager>().UnlockTrophy(2);
        if (numPoints >= 7000)
            trophymanager.GetComponent<TrophyManager>().UnlockTrophy(3);
    }

    public void setLifes(int lifes){
        health = lifes;
    }
}
