using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Coin : MonoBehaviour
{

    #region Variables

    public GameObject Particle;
    
    public bool InMagnet;
    public bool IsCoin;
    public float Speed;

    private RocketAudio rocketAudio;
    private float LerpSpeed;

    #endregion
    
    void Start() 
    {
        LerpSpeed = 0;

        if(!IsCoin)
        {
            rocketAudio = GameManager.Instance.Rocket.gameObject.GetComponent<RocketAudio>();
        }
    }

    #region BuiltInMethods

    void Update()
    {
        if(InMagnet)
        {
            if(GameManager.Instance.Rocket)
            {
                LerpSpeed = Mathf.Lerp(LerpSpeed,Speed,10f*Time.deltaTime);

                transform.position = Vector2.MoveTowards(transform.position,
                GameManager.Instance.Rocket.transform.position,LerpSpeed * Time.deltaTime); 
            }  
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Sensor")
        {
            if(IsCoin)
            {
                GameManager.Instance.CollectedCoins += 1;
            }
            else
            {
                rocketAudio.playItemPickUpSound();                
            }

            if(Particle)
            {
                Particle.SetActive(true);
                Particle.transform.SetParent(null);
            }

            Destroy(gameObject);
        }
    }

    #endregion

    #region CustomMethods

    #endregion

}
