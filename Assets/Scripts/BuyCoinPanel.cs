using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCoinPanel : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int clicknum = 0;
    private int createCoinNum;
    private bool canClick = true;//标记是否可以点击，作用：防止出现重复点击的问题

    /// <summary>
    /// 点击购买按钮，执行打开宝箱事件，并开始更新分数
    /// </summary>
    public void ClickShopBtn()
    {
        if (canClick)
        {
            clicknum++;
            createCoinNum = Mathf.Clamp(clicknum * 5, 0, 15);
            BoxController.Instance.OpenBox(createCoinNum);
            StartCoroutine("UpdateScore");
            canClick = false;
        }
    }

    /// <summary>
    /// 更新分数，当分数更新完can Click设置为true
    /// </summary>
    /// <returns></returns>
    IEnumerator UpdateScore()
    {
        while (createCoinNum > 0)
        {
            yield return new WaitForSeconds(0.2f);
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            createCoinNum--;
        }

        canClick = true;
    }
}