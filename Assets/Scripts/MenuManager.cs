using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject guideMenu, inSeatMenu, seatSelectMenu;   //Reference for menu items to be shown/hidden

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    //Function for controlling which menu items are visible in each GameState
    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        guideMenu.SetActive(state == GameState.Guide);
        inSeatMenu.SetActive(state == GameState.InSeat);
        seatSelectMenu.SetActive(state == GameState.SelectSeat);
    }
}
