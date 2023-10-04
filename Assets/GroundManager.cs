using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;// if Unity cannot use Random.Range, Use this code




public class GroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Startfloor;
    public GameObject Brick;
    readonly float initPositionY = 0;
    //readonly float initPositionX = 0;
    readonly float RightBorder = 6f;
    readonly float LeftBorder = -6f;
   [Range(2, 6)] public float spacingY;
    public List<Transform> Grounds;
    readonly int MAX_GROUND_COUNT = 10;
    readonly int MINI_GROUND_COUNT_UNDER_PLAYER = 3;
    static int groundnumber = -1;
    public Transform player;

    void Start()
    {
        
        Grounds = new List<Transform>();
        Instantiate(Startfloor,new Vector3(0,-1f,0),Quaternion.identity);
        for (int i = 1; i < 5; i++) 
        {
            SpawnFloor();
        }
        
    }
    float NewGroundPositionX () //calculate new X axis
    {
        return Random.Range(LeftBorder, RightBorder);
    }

    
    float NewGroundPositionY() //calculate new Y axis
    {
        if (Grounds.Count == 0) 
        {
            return initPositionY;
        }
        int lowerindex = Grounds.Count - 1;
        return Grounds[lowerindex].transform.position.y - spacingY;
    }

    void SpawnFloor() //Generate New Ground
    {
        //float RandomPositionY = initPositionY - spacingY * i;

        Vector3 RandomPosition = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
        GameObject NewGround=Instantiate(Brick, RandomPosition, Quaternion.identity);
        Grounds.Add(NewGround.transform);
    }

    public void ControlGroundCount() 
    {
        if (Grounds.Count > MAX_GROUND_COUNT) 
        {
            Destroy(Grounds[0].gameObject);
            Grounds.RemoveAt(0);
        }
    }

    public void ControlSpawnFloor() 
    {
        int GroundUnderPlayer = 0;
        foreach (Transform grounds in Grounds) 
        {
            if (grounds.position.y < player.transform.position.y) 
            {
                GroundUnderPlayer++;
            }
        }
        if (GroundUnderPlayer < 3) 
        {
            SpawnFloor();
            ControlGroundCount();
            Debug.Log("Generating Floor");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        ControlSpawnFloor();
    }
}
