using UnityEngine;
using UnityEngine.Events;

public class ClickBehavior : MonoBehaviour
{

    public UnityEvent onClick;

   //Unity Events allow you to generalise your scripts and prevents you from repeating yourself

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(raycast))
            {
                onClick.Invoke();
            }

        }
        //To make a function compatible with a UnityEvent, it must be public and must use one of the basic types; such as int, float, string, etc. (no values, such as Vector's)
    }
}
