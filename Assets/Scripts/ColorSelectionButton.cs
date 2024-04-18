using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    #region VARIABLES
    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;
    #endregion

    #region METHODS
    public void OnButtonClick() 
    {
        paddleReference.color = uiButton.colors.normalColor;
        if (isColorPlayer)
        {
            SaveController.Instance.colorPlayer = paddleReference.color;
        }
        else 
        {
            SaveController.Instance.colorPlayer2 = paddleReference.color;
        }
    }
    #endregion
}
