using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed;
    float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;

    void Start()
    {
        speed = 44f / 30f;
    }

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.SetPositionAndRotation(pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction), pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction));
    }
}
