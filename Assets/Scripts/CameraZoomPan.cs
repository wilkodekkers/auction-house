using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomPan : MonoBehaviour
{
    public Camera Camera;
    protected Plane plane;

    private void Awake()
    {
        if(Camera == null)
        {
            Camera = Camera.main;
        }
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            plane.SetNormalAndPosition(transform.up, transform.position);
        }
        var Delta1 = Vector3.zero;
        var Delta2 = Vector3.zero;

        //move
        if (Input.touchCount >= 2)
        {
            Delta1 = PlanePositionDelta(Input.GetTouch(0));
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Camera.transform.Translate(Delta1, Space.World);
            }
        }

        //zoom
        if (Input.touchCount == 2)
        {
            var pos1 = PlanePosition(Input.GetTouch(0).position);
            var pos2 = PlanePosition(Input.GetTouch(1).position);

            var pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
            var pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

            var zoom = Vector3.Distance(pos1, pos2) /
                Vector3.Distance(pos1b, pos2b);


            if(zoom == 0 || zoom > 10)
            {
                return;
            }
            Camera.transform.position = Vector3.LerpUnclamped(pos1, Camera.transform.position, 1 / zoom);
        }
    }

    protected Vector3 PlanePositionDelta(Touch touch)
    {
        if(touch.phase != TouchPhase.Moved)
        {
            return Vector3.zero;
        }

        var rayBefore = Camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = Camera.ScreenPointToRay(touch.position);

        if(plane.Raycast(rayBefore, out var enterBefore) && plane.Raycast(rayNow, out var enterNow))
        {
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);
        }
        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        var rayNow = Camera.ScreenPointToRay(screenPos);

        if(plane.Raycast(rayNow, out var enterNow))
        {
            return rayNow.GetPoint(enterNow);
        }
        return Vector3.zero;
    }
}
