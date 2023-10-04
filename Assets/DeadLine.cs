using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeadLine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            CatPlayer.isdead = true;
            Debug.Log("Dead");
            //Debug.Break();
        }
    }
}
