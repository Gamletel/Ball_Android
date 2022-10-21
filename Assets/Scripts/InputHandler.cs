using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //Считываем координаты движения пальца по экрану
    public Vector2 GetTouchDeltaPos()
    {
        if(Input.touchCount > 0)
            return Input.GetTouch(0).deltaPosition;
        return Vector2.zero;
    }

    //переменная для того, чтобы было ясно есть касание или нет
    public bool isTouched()
    {
        if (Input.touchCount == 1)
            return true;
        else
            return false;

    }
}
