using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlipY : MonoBehaviour
{
    public Transform wepon;
   

    
    public Camera mainCamera;

   
    void Update()
    {
        
        Vector3 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

       
        if (transform.position.x < cursorPosition.x)
        {
            
            wepon.localScale = new Vector3( wepon.localScale.x,  1,wepon.localScale.z);
          
        }
        else
        {
            
            wepon.localScale = new Vector3( wepon.localScale.x, -1,wepon.localScale.z);
            
        }
    }
}
