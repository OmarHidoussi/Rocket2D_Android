using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycler : MonoBehaviour
{

    #region Variables

    public Color[] colors;
    public float speed = 1;
    int CurrentIndex = 0;
    Camera cam;
    bool ShouldChange = false;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        cam = GetComponent<Camera>();
        CurrentIndex = Random.Range(0,colors.Length);
        SetColor(colors[CurrentIndex]);
    }

   void Update()
    {
        if(ShouldChange)
        {
            var StartColor = cam.backgroundColor;
            var endColor = colors[0];

            if(CurrentIndex + 1 < colors.Length )
            {
                endColor = colors[CurrentIndex + 1];
            }

            var newColor = Color.Lerp(StartColor,endColor,speed * Time.deltaTime);
            SetColor(newColor);

            if(newColor == endColor)
            {
                ShouldChange = false;

                if(CurrentIndex +1 < colors.Length)
                {
                    CurrentIndex++;
                }
                else
                {
                    CurrentIndex =0;
                }
            }
        }
    }

    #endregion

    #region CustomMethods

    public void SetColor(Color color)
    {
        cam.backgroundColor = color;
    }

    public void Cycle()
    {
        ShouldChange = true;   
    }

    #endregion

}
