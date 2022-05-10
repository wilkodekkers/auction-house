using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
   float degreesPerSecond = 20;
    // Update is called once per frame
    void Update()
    {
    transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
    }
}
