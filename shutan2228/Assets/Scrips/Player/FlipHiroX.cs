using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipHiroX : MonoBehaviour
{
    public SpriteRenderer spriteRendererHiro;
   
   
    public Camera mainCamera;

    
    void Update()
    {
        // Получаем положение курсора в мировых координатах
        Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

       
        if (transform.position.x < cursorPosition.x)
        {
            
            spriteRendererHiro.flipX = false;
        }
        else
        {
            
            spriteRendererHiro.flipX = true;
        }
    }
}
