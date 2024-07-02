using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    #region Variables

    public Transform Target;
    public float ZOffset,YOffset,GameStartYOffset;
    public float LerpSpeed; 
    public float PlanetLerpSpeed;
    public float zoomIn,zoomOut,previousZoomIn,ZoomSpeed;
    public float ZoomOutEventzoom;

    [HideInInspector] public Vector3 Planet;
    [HideInInspector] public bool ZoomOutEvent;

    private float xPos;
    private Camera cam;
    private RocketMovement Rocket;
    private Vector2 ScreenBounds;

    #endregion

    #region BuiltInMethods

    void Start() 
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        Rocket = GameManager.Instance.Rocket;
        
        cam = Camera.main;

        YOffset = GameStartYOffset;
        previousZoomIn = zoomIn;
    }

    void FixedUpdate()
    {

        if(Rocket != null)
        {
            CaclulateXPos();

            if(ZoomOutEvent)
            {
                zoomIn = ZoomOutEventzoom;
                transform.position = Vector3.Lerp(transform.position, new Vector3(xPos,Target.position.y - YOffset,-10),LerpSpeed * Time.deltaTime);
                ZoomIn();
            }

            else
            { 
                zoomIn = previousZoomIn;

                if(!Rocket.interact)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(xPos,Target.position.y - YOffset,-10),LerpSpeed * Time.deltaTime);
                    ZoomOut();
                }
                else
                {
                    if(!ZoomOutEvent)
                    {
                        transform.position = Vector3.Lerp(transform.position,new Vector3(Planet.x,Planet.y,-10),PlanetLerpSpeed * Time.deltaTime);
                        ZoomIn();
                    }
                }
            }
        }
    }

    #endregion

    #region CustomMethods

    void CaclulateXPos()
    {
        if(Rocket.transform.position.x > ScreenBounds.x - 2 || Rocket.transform.position.x < -ScreenBounds.x + 2) 
        {
            xPos = Target.position.x;
        }
        else
        {
            xPos = 0;
        }
    }

    public void ZoomIn()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,zoomIn,ZoomSpeed * Time.deltaTime);
    }

    public void ZoomOut()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,zoomOut,ZoomSpeed * Time.deltaTime);
    }

    #endregion
    
}