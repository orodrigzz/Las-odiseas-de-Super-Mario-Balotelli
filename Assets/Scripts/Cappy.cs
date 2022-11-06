using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cappy : MonoBehaviour
{
    public float velocity;
    public float movingTime;
    public float time;
    
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(0, 0, velocity * Time.deltaTime);

        if (time >= movingTime)
        {
            velocity = 0;
        }

        if (velocity == 0)
        {
            Destroy(this.gameObject);
            time = 0;
        }
    }
}
