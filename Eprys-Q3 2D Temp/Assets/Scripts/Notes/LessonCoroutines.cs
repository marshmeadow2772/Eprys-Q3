using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LessonCoroutines : MonoBehaviour
{
    
    void Start()
    {

        string[] messages = { "Omnis", "Vir", "Lupis" };
        StartCoroutine(PrintMessages(messages, 1.5f));
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine(Move(Random.onUnitSphere * 5, 8));
    //    }
    //}


    //IEnumerator Move(Vector2 destination, float speed)
    //{

    //    while (transform.position != destination)
    //    {

    //        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    //        yield return null;
    //    }
    //}

    IEnumerator PrintMessages(string[] messages, float delay)
    {
        foreach (string msg in messages)
        {
            print(msg);
            yield return new WaitForSeconds (delay);
        }
    }
   
}
