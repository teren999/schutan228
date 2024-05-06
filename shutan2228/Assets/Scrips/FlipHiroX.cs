using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipHiroX : MonoBehaviour
{
    public SpriteRenderer spriteRendererHiro;
    public SpriteRenderer spriteRendererHat;

   
    public Camera mainCamera;

    
    void Update()
    {
        // Получаем положение курсора в мировых координатах
        Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

       
        if (transform.position.x < cursorPosition.x)
        {
            spriteRendererHat.flipX =false;
            spriteRendererHiro.flipX = false;
        }
        else
        {
            spriteRendererHat.flipX = true;
            spriteRendererHiro.flipX = true;
        }
    }
}
