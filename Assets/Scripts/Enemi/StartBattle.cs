using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.instancie._ActionCan = false;
            SpecialBossLevel3.instnacie.animator.SetBool("GoStage", true);
        }
    }
}
