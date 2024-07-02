using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicBreaker : MonoBehaviour
{
    #region Variables

    public Color color;
    public GameObject DestroyedVersion;

    private CircleCollider2D col;
    private SliderController S_controller;
    private float CosmicBreakerTimer;

    #endregion

    #region BuiltInMethods

    void Start() 
    {
        col = GetComponent<CircleCollider2D>();
        S_controller = GameManager.Instance.controller;
    }

    void FixedUpdate() 
    {
        cosmicBreaker();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Obstacle")
        {
            if(Vector2.Distance(other.transform.position,transform.position) < 5)
            {
                Destroy(other.gameObject);
                Instantiate(DestroyedVersion,other.transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        
        if(other.gameObject.tag == "Obstacle")
        {
            Vector2 RocketToPlanet = other.gameObject.transform.position - transform.position;
            
            float PlanetDistance = RocketToPlanet.magnitude;
            float relativeDistance = (col.radius - PlanetDistance) / col.radius;

            Color Col = other.gameObject.GetComponent<SpriteRenderer>().color;

            other.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(
                other.gameObject.GetComponent<SpriteRenderer>().color ,color,relativeDistance);

        }
        
    }

    public void cosmicBreaker()
    {
        CosmicBreakerTimer = S_controller.C_BreakerTimer;

        if(CosmicBreakerTimer <= 0.04f)
        {
            this.gameObject.SetActive(false);
        }
    }

    #endregion

}
