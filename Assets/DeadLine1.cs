using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            CatPlayer.isdead = true;
            Debug.Log("Dead");
            //Debug.Break();
        }
    }
}
