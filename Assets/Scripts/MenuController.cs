using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    #region VARIABLES
    public TextMeshProUGUI uiWinner;
    public TextMeshProUGUI textInputName;
    public TextMeshProUGUI textInputName2;
    #endregion

    #region METHODS
    void Start() 
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLastWinner();

        if (lastWinner != "")
            uiWinner.text = "Last Winner: " + lastWinner;
        else
            uiWinner.text = "";
    }
    #endregion
}
