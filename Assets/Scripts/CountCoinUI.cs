using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCoinUI : MonoBehaviour
{
    private int Clicknum = 0;
    public Text ScoreText;
    private int CreateCoinNum;
    private bool CanClick = true;
    public void ClickShopBtn()
    {
        
        if (CanClick)
        {
            Clicknum++;
            CreateCoinNum = Mathf.Clamp(Clicknum * 5, 0, 15);
            BoxController.Instance.OpenBox(CreateCoinNum);
            StartCoroutine("UpdateScore");
            CanClick = false;
        }
    }

    IEnumerator UpdateScore()
    {
        while (CreateCoinNum>0)
        {
            yield return new WaitForSeconds(0.2f);
            ScoreText.text = (int.Parse(ScoreText.text) + 1).ToString();
            CreateCoinNum--;
        }

        CanClick = true;
    }
}