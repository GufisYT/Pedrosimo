using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class t_shooting_r : MonoBehaviour
{
    public SteamVR_Action_Boolean t_Shoot;
    public SteamVR_Action_Boolean t_SlowTime;
    public SteamVR_Input_Sources t_hand;
    public Pistol_Shooting_r pistolS_r;
    

    // Start is called before the first frame update
    void Start()
    {
        t_Shoot.AddOnStateDownListener(TriggerDown, t_hand);
        t_SlowTime.AddOnStateDownListener(GripDown, t_hand);
        t_SlowTime.AddOnStateUpListener(GripUp, t_hand);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GripDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Time.timeScale = 0.25f;
    }

    public void GripUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) 
    {
        Time.timeScale = 1f;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        pistolS_r.Fire();
    }
}
