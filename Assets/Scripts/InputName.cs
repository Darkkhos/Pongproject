using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputName : MonoBehaviour
{
    #region VARIABLES
    public bool isPlayer;
    public TMP_InputField inputField;
    #endregion

    #region METHODS
    private void Start()
    {
        inputField.onValueChanged.AddListener(UpdateName);
    }
    public void UpdateName(string name)
    {
        if (isPlayer)
            SaveController.Instance.playerName = name;
        else
            SaveController.Instance.player2Name = name;
    }
    #endregion
}
