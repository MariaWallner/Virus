using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private bool isShowing;
   
   // Update is called once per frame
   void Update()
   {
       if (LevelManager.instance.currentLevel == 1 && !isShowing && Random.value < 0.007)
       {
           // ChaosMonkeyController chaosMonkey = GameObject.Find("ChaosMonkeyRight").GetComponent<ChaosMonkeyController>();
           //chaosMonkey.show();
           StartCoroutine(Show());
       }
   }

   private IEnumerator Show()
   {
       isShowing = true;
       float startTime = Time.time;
       Vector2 force;

       if (gameObject.name.EndsWith("RightPhysics"))
       {
           force = Vector2.left * 180f;
       }
       else if (gameObject.name.EndsWith("LeftPhysics"))
       {
           force = Vector2.right * 180f;
       }
       else
       {
           force = Vector2.zero;
       }

       do
       {
           GetComponent<Rigidbody2D>().AddForce(force * Time.deltaTime * 50, ForceMode2D.Force);
           yield return null;
       } while (Time.time - startTime < Random.Range(1, 3));
       isShowing = false;
   }
}
