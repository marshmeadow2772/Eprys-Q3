using UnityEngine;

public class Curve : MonoBehaviour
{
   public CurveVariables variables;

    public void Update()
    {
        float theta = Time.time;
        float x = (Mathf.Sin(theta * variables.speed) * variables.width) + variables.xOffset;
        float y = (Mathf.Cos(theta * variables.speed) * variables.height) + variables.yOffset;
        transform.position = new(x, y);
    }


}
