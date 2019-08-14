using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform[] rackPositions;
    int index = 0;

    public GameObject PauseMenu;

    public OVRInput.Button up = OVRInput.Button.Three;
    public OVRInput.Button down = OVRInput.Button.Four;

    Vector3 offset = new Vector3(0, 1, -2f);
    bool gamePaused = false;

    void Start()
    {
        PauseMenu.SetActive(false);
        SetPosAndRot();
    }

    
    void CheckForPause()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            PauseMenu.transform.position = transform.position + offset;
            PauseMenu.transform.LookAt(-transform.forward);
            gamePaused = !gamePaused;
            PauseMenu.SetActive(gamePaused);
            GameManager.instance.Pause(gamePaused);
        }
    }

    void Update()
    {
        CheckForPause();

        // TODO: refactor
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
