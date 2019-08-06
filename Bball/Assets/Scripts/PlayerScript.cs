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
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                transform.position = rackPositions[index++].position;
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                transform.position = rackPositions[rackPositions.Length].position;
            }
        }
        if (index > 0 && index < rackPositions.Length)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                transform.position = rackPositions[index + 1].position;
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                transform.position = rackPositions[index - 1].position;
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                transform.position = rackPositions[0].position;
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                transform.position = rackPositions[index - 1].position;
            }
        }
    }
}
