using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartPanelController : MonoBehaviour
{
    [SerializeField]private GameObject startPanel;
    [SerializeField]private GameObject gamePanel;
    /// <summary>
    /// 点击开始界面开始按钮
    /// </summary>
    public void ClickStartButton()
    {
        gamePanel.SetActive(true);
        startPanel.SetActive(false);
    }
}
