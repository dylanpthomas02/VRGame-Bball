using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform[] rackPositions;
    int index = 0;

    void Start()
    {
        transform.position = rackPositions[0].position;
    }

    void Update()
    {
        if (index == 0)
        {
            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                index++;
                transform.position = rackPositions[index].position;
            }
            else if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                index = rackPositions.Length - 1;
                transform.position = rackPositions[index].position;
            }
        }
        else if (index > 0 && index < rackPositions.Length - 1)
        {
            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                index++;
                transform.position = rackPositions[index].position;
            }
            else if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                index--;
                transform.position = rackPositions[index].position;
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                index = 0;
                transform.position = rackPositions[index].position;
            }
            else if (OVRInput.GetDown(OVRInput.Button.Four))
            {
                index--;
                transform.position = rackPositions[index].position;
            }
        }
    }
}
