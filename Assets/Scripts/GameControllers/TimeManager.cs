using UnityEngine;

public class TimeManager : MonoBehaviour
{  

    #region Variables

    public float SlowMotionFactor = 0.05f;
    public float SlowMotionLenght = 4f;
    public float ResetTimeScale = 1f;
    
    public bool InSlowMotion;

    #endregion

    #region BuiltInMethods
    
    void Start() 
    {
        ResetTimeScale = Time.timeScale;   
    }

    void Update()
    {
        if(!InSlowMotion)
        {
            Time.timeScale += (1f / SlowMotionLenght) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
        }
    }

    #endregion

    #region CustomMethods

    public void SlowMotion(float slowdownFactor)
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    #endregion

}
