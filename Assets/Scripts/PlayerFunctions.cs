using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    public GameState state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function use for changing GameState through Unity Event System when using buttons
    public void ChangeGameState(int i)
    {
        /*Had to do this because for some reason the OnClick 
         on buttons does not allow me to call UpdateGameState
         from the GameManager*/
        switch (i)
        {
            case 0:
                state = GameState.Guide;
                break;
            case 1:
                state = GameState.InSeat;
                break;
            case 2:
                state = GameState.SelectSeat;
                break;
            default:
                Debug.Log("Invalid State");
                break;
        }
        GameManager.Instance.UpdateGameState(state);

    }
}
