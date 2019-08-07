using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform[] rackPositions;
    int index = 0;

    public OVRInput.Button up = OVRInput.Button.Three;
    public OVRInput.Button down = OVRInput.Button.Four;

    void Start()
    {
        SetPosAndRot();
    }

    void Update()
    {
        if (index == 0)
        {
            if (OVRInput.GetDown(up))
            {
                index++;
                SetPosAndRot();
            }
            else if (OVRInput.GetDown(down))
            {
                index = rackPositions.Length - 1;
                SetPosAndRot();
            }
        }
        else if (index > 0 && index < rackPositions.Length - 1)
        {
            if (OVRInput.GetDown(up))
            {
                index++;
                SetPosAndRot();
            }
            else if (OVRInput.GetDown(down))
            {
                index--;
                SetPosAndRot();
            }
        }
        else
        {
            if (OVRInput.GetDown(up))
            {
                index = 0;
                SetPosAndRot();
            }
            else if (OVRInput.GetDown(down))
            {
                index--;
                SetPosAndRot();
            }
        }
    }

    private void SetPosAndRot()
    {
        transform.position = rackPositions[index].position;
        transform.rotation = rackPositions[index].rotation;
    }
}
