using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void OnPointerEnter(PointerEventData eventData){
       animator.SetBool("isMouseOver",true);
   }

    public void OnPointerExit(PointerEventData eventData){
       animator.SetBool("isMouseOver",false);
   }

}
