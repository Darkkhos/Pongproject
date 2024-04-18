using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveController : MonoBehaviour
{
    #region VARIABLES
    public Color colorPlayer = Color.white;
    public Color colorPlayer2 = Color.white;
    
    public string playerName;
    public string player2Name;

    private string saveWinnerKey = "SavedWinner";
    private static SaveController _instance;
    #endregion

    #region METHODS
    public static SaveController Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }            
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this) 
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? playerName : player2Name;
    }

    public void Reset()
    {
        playerName = "";
        player2Name = "";
        colorPlayer = Color.white;
        colorPlayer2 = Color.white;
    }

    public void SaveWinner(string winner) 
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }

    public string GetLastWinner() 
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }

    public void ClearSave() 
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
}