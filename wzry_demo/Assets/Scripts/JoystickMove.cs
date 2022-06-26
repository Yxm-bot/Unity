using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Transform handlerTran;
    public Vector2 downPoint;
    public float Maxradius;
    public static Vector3 moveInput;
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 distance = eventData.position - downPoint;
        float move = Mathf.Clamp(distance.magnitude, 0f, Maxradius);
        Vector2 actualMove = distance.normalized * move;
        handlerTran.localPosition = actualMove;
        moveInput = new Vector3(distance.normalized.x,0, distance.normalized.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        downPoint = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handlerTran.localPosition = Vector3.zero;
        moveInput = Vector3.zero;
    }
}
