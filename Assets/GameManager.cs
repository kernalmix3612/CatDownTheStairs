using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartbutton;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        restartbutton.gameObject.SetActive(false);
       
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   

    // Update is called once per frame
    void Update()
    {
        if (CatPlayer.isdead) 
        {
            Player.SetActive(false);
            restartbutton.gameObject.SetActive(true);
        }
    }
}
