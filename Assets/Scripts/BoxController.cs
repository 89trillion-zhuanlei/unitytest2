using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxController : MonoBehaviour
{
    public static BoxController Instance;
    public ParticleSystem BoxOpenParticle; //宝箱打开特效
    public GameObject CoinSprite; //金币
    public Transform CoinToPos; //金币要到达的位置
    private Animator BoxAnim;

    private int CoinNum = 0;
    private void Awake()
    {
        BoxOpenParticle.gameObject.SetActive(false);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        BoxAnim = GetComponent<Animator>();
    }

    public void OpenBox(int num)
    {
        BoxAnim.SetBool("IsOpen", true);
        BoxOpenParticle.gameObject.SetActive(true);
        StartCoroutine("CreateAndFly",num);
    }

    IEnumerator CreateAndFly(int CoinNum)
    {
        while (CoinNum>0)
        {
            GameObject coin = Instantiate(CoinSprite, transform);
            coin.transform.DOMove(CoinToPos.position, 0.4f);
            Destroy(coin,0.5f);
            yield return new WaitForSeconds(0.2f);
            CoinNum--;
        }
        BoxAnim.SetBool("IsOpen", false);
        BoxOpenParticle.gameObject.SetActive(false);
    }
    
}
