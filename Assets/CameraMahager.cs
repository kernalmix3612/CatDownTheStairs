using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMahager : MonoBehaviour
{
    // Start is called before the first frame update
    public float Downspeed;
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
        transform.Translate(0, -Downspeed * Time.deltaTime, 0);
        //if ()
    }
}
