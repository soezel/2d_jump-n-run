using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int geld;
    public Text money;
    
    void Start()
    {
        //geld = PlayerPrefs.GetInt("Money", 0);
        geld = 0;
    }

    void Update()
    {
        //money.text = PlayerPrefs.GetInt("Money", 0).ToString();
        money.text = geld.ToString();
    }

    public void AddMoney()
    {
        geld++;
        PlayerPrefs.SetInt("Money", geld);
    }
}