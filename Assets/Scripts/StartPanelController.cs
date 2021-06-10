using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartPanelController : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject GamePanel;
    public void ClickStartButton()
    {
        GamePanel.SetActive(true);
        StartPanel.SetActive(false);
    }
}
