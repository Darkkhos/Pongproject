using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    #region VARIABLES
    public float speed = 5f;

    public Vector3 limits = new Vector3(-4.5f, 4.5f);

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;
    #endregion

    #region METHODS
    private void Start()
    {
        if (isPlayer)
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        else
            spriteRenderer.color = SaveController.Instance.colorPlayer2;
     
    }

    void Update()
    {
        // Movement "y" Vertical
        float moveInput = Input.GetAxis("Vertical");

        // New Position Paddle
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;    

        // Limit "Y" Position
        newPosition.y = Mathf.Clamp(newPosition.y, limits.x, limits.y);
        transform.position = newPosition;

      
    }
    #endregion
}
