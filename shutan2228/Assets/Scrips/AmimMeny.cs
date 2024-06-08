
using UnityEngine;

public class AmimMeny : MonoBehaviour
{
     public Animator anim;

     
     private void OnEnable()
     {
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        anim.SetTrigger("animMeny");
        
     }
}
