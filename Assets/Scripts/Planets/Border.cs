using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{

    #region Variables

    public Color color;
    public SpriteRenderer sprite;    

    private EdgeCollider2D col;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        col = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Sensor")
        {
            col.isTrigger = false;
            sprite.color = color;
        }
    }

    #endregion

    #region CustomMethods

    #endregion

}
