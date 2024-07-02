using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class RocketInfo : MonoBehaviour
{

    #region Variables

    [HideInInspector] public List<Vector3> Positions;
    [HideInInspector] public float Ypos;

    [SerializeField] private CircleCollider2D col;
   
   
    public GameObject ExplusionParticle;
    public Animator FadeInAnim;

    private const string Tag = "Interactable";

    private float Distance;
    private float width;

    RocketGrappler Grappler;
    RocketMovement rocket;
    CameraFollow cam;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        rocket = GetComponent<RocketMovement>();
        Positions = new List<Vector3>();
        cam = Camera.main.GetComponent<CameraFollow>();
        Grappler = GetComponent<RocketGrappler>();
        width = Grappler.LineWidth;

        FadeInAnim = GameManager.Instance.FadeInAnim;
    }

    void FixedUpdate() 
    {
        Ypos = transform.position.y;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag) 
        {

            rocket.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            
            cam.Planet = collision.gameObject.transform.position;

            Grappler.GrappleTo = collision.gameObject.transform;

            Grappler.Grapple();

            Vector2 RocketToPlanet = collision.gameObject.transform.position - transform.position;

            float PlanetDistance = RocketToPlanet.magnitude;

            float relativeDistance = (col.radius - PlanetDistance) / col.radius;
                    
            Grappler.lineRenderer.startWidth = 0.075f;
                    
            Grappler.lineRenderer.endWidth = relativeDistance / width;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == Tag) 
        {
            rocket.connectedBody = null;
            
            Grappler.GrappleTo = null;

            Grappler.lineRenderer.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.GetComponent<PlanetRotation>())
        {
            FadeInAnim.enabled = true;            
            Instantiate(ExplusionParticle,transform.position,Quaternion.identity);

            this.gameObject.SetActive(false);
        }
    }

    #endregion
    
}