using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxController : MonoBehaviour
{
    public static BoxController Instance;
    [SerializeField]private ParticleSystem boxOpenParticle; //宝箱打开特效
    [SerializeField]private GameObject coinSprite; //金币
    [SerializeField]private Transform coinToPos; //金币要到达的位置
    [SerializeField] private Animator boxAnim;

    private int CoinNum = 0;
    private void Awake()
    {
        boxOpenParticle.gameObject.SetActive(false);
        Instance = this;
    }

    /// <summary>
    /// 打开宝箱，并开启创建金币方法
    /// </summary>
    /// <param name="num"></param>
    public void OpenBox(int num)
    {
        boxAnim.SetBool("IsOpen", true);
        boxOpenParticle.gameObject.SetActive(true);
        StartCoroutine("CreateAndFly",num);
    }

    /// <summary>
    /// 0.2秒生成一个金币，生成coinnum次
    /// 结束后，播放关闭动画，关闭粒子特效
    /// </summary>
    /// <param name="coinNum"></param>
    /// <returns></returns>
    IEnumerator CreateAndFly(int coinNum)
    {
        while (coinNum>0)
        {
            GameObject coin = Instantiate(coinSprite, transform);
            coin.transform.DOMove(coinToPos.position, 0.4f);
            Destroy(coin,0.5f);
            yield return new WaitForSeconds(0.2f);
            coinNum--;
        }
        boxAnim.SetBool("IsOpen", false);
        boxOpenParticle.gameObject.SetActive(false);
    }
    
}
