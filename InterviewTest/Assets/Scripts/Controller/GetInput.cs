using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    [HideInInspector] public bool IsForward = true;
    [HideInInspector] public bool IsRunning = false;
    [HideInInspector] public bool IsBraking = false;
    [HideInInspector] public int direction;

    int left = -1;
    int right = 1;


    public void AccelerationDown()
    {
        IsRunning = true;
        Debug.Log("ON");
    }

    public void AccelerationUp()
    {
        IsRunning = false;
        Debug.Log("OFF");
    }

    public void ChangeDirection()
    {
        IsForward = !IsForward;
    }

    public void BrakeDown()
    {
        IsBraking = true;
    }

    public void BrakeUp()
    {
        IsBraking = false;
    }


    public void SteerLeftDown()
    {
        direction = left;
    }

    public void SteerRightDown()
    {
        direction = right;
    }

    public void SteerLeftUp()
    {
        direction = 0;
    }

    public void SteerRightUp()
    {
        direction = 0;
    }
}
