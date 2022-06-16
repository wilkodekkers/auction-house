using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveModel : MonoBehaviour
{
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("model"));
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);

            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                var rotation = new Vector3(0f, -touch0.deltaPosition.x, 0f);
                GameObject.Find("Pivot").transform.Rotate(rotation * 0.1f);
            }
        }
    }
}
