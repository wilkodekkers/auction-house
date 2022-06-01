using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed;
    float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;

    // Start is called before the first frame update
    void Start()
    {
        speed = 44f / 30f;
    }

    // Update is called once per frame
    void Update()   
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
    }
}
