using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameState State;
    public GameState previousState;

    public static event Action<GameState> OnGameStateChanged;   //Event triggered when changing gamestates
    public static event Action<GameObject> OnCameraChanged;     //Event triggered when a seat is selected in SelectSeat()

    [SerializeField]
    private DataRecord[] seatDataArray;     //Used for adding seating POV in inspector
    private DataRecord seatData;
    private int seatSelected = 0;

    [SerializeField]
    private GameObject sectionText, rowText, seatText, priceText;   //Used to reference UI text for displaying seat data

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Guide);
        SelectSeat(0);      //Seat is selected so that the seat info UI updates
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateGameState(GameState newState)
    {
        previousState = State;
        State = newState;
        switch (newState)
        {
            case GameState.Guide:
                HandleGuide();
                break;
            case GameState.InSeat:
                HandleInSeat();
                break;
            case GameState.SelectSeat:
                HandleSelectSeat();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleSelectSeat()
    {
        
    }

    private void HandleInSeat()
    {

    }

    private void HandleGuide()
    {

    }

    //Function for selecting seat from the seatDataArray, moving camera position, setting seat info text
    public void SelectSeat(int seat)
    {
        if(seat < seatDataArray.Length)
        {
            seatSelected = seat;
            seatData = getSeatData(seatSelected);
            //Set Camera position to seat
            OnCameraChanged?.Invoke(seatData.Marker);

            //Set UI text to match seat info
            sectionText.GetComponent<TextMeshProUGUI>().text= seatData.section;
            rowText.GetComponent<TextMeshProUGUI>().text = seatData.row.ToString();
            seatText.GetComponent<TextMeshProUGUI>().text = seatData.seat.ToString();
            priceText.GetComponent<TextMeshProUGUI>().text = seatData.price.ToString();


        }
        else
        {
            Debug.Log("Invalid Seat. Out of Range");
            throw new InvalidSeatException("Seat out of range");
        }

    }

    //Getter for seatData
    private DataRecord getSeatData(int seat)
    {
        return seatDataArray[seat];
    }

}
public enum GameState
{
    Guide, InSeat, SelectSeat
}

public class InvalidSeatException : Exception
{
    public InvalidSeatException()
    {

    }

    public InvalidSeatException(string message) : base(message)
    {

    }
}