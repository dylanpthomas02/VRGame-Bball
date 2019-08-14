using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    public Transform[] rackPositions;
    int index = 0;

    public OVRInput.Button up = OVRInput.Button.Three;
    public OVRInput.Button down = OVRInput.Button.Four;
    public bool gameStarted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        SetPosAndRot();
    }

    void Update()
    {
        // TODO: refactor
        if (index == 0 && gameStarted)
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
        else if (index > 0 && index < rackPositions.Length - 1 && gameStarted)
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
        else if (gameStarted)
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
