using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Astroids_Sponer : MonoBehaviour
{

    #region Variables

    public GameObject[] Astroids;
    public float SponeEvery;

    private BoxCollider2D col;
    private Vector2 colOffset;
    private float Xoffset;
    private float Factor;
    private float resetTimer;
    private int i;
    
    #endregion

    #region BuiltInMethods

    void Start()
    {
        
        col = GetComponent<BoxCollider2D>();

        colOffset = col.size;
        Xoffset = colOffset.x;

        resetTimer = SponeEvery;

        i = 0;
        
    }

    void FixedUpdate()
    {
        SponeEvery -= Time.deltaTime;

        if(SponeEvery <= 0)
        {
            float WantedXPosition = GenerateRandomPositionX_Value(Xoffset);
            Debug.Log(WantedXPosition);
            SponeEvery = resetTimer;

            Spone(i,WantedXPosition);
            
            i+=1;
            if(i == Astroids.Length)
            {
                i = 0;
                foreach (GameObject astroid in Astroids)
                {
                    astroid.SetActive(false);
                }
            }
        } 
    }

    #endregion

    #region CustomMethods

    float GenerateRandomPositionX_Value(float MaxValue)
    {
        Factor = Random.Range(transform.position.x-(Xoffset/2) ,
        transform.position.x+(Xoffset/2));

        return Factor;
    }

    void Spone(int index,float Xpos)
    {
        Vector2 Position = new Vector2(Xpos,transform.position.y);

        Astroids[i].transform.position = Position;
        Astroids[i].SetActive(true);
    }

    #endregion

}
