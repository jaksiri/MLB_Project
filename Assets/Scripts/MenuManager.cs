using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject guideMenu, inSeatMenu, seatSelectMenu, moreInfoPanel;   //Reference for menu items to be shown/hidden
    private bool panelStatus = true;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    //Function for controlling which menu items are visible in each GameState
    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        guideMenu.SetActive(state == GameState.Guide);
        inSeatMenu.SetActive(state == GameState.InSeat);
        if (state != GameState.InSeat || state != GameState.SelectSeat)
        {
            moreInfoPanel.SetActive(false);
        }
        seatSelectMenu.SetActive(state == GameState.SelectSeat);
    }

    public void TogglePanel()
    {
        moreInfoPanel.SetActive(panelStatus);
        panelStatus = !panelStatus;
    }
}
