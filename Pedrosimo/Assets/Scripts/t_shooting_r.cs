using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class t_shooting_r : MonoBehaviour
{
    private SteamVR_Action_Boolean t_Shoot;
    private SteamVR_Action_Boolean t_SlowTime;
    private readonly float DesiredInst = 1f;
    private float CurrentInst;
    private bool AllowChange;

    public SteamVR_ActionSet m_Action;
    public Light SlowEffect;
    public Pistol_Shooting_r pistolS_r;

    // Start is called before the first frame update
    void Start()
    {
        t_Shoot = SteamVR_Actions.main_Shoot;
        t_SlowTime = SteamVR_Actions.main_SlowTime;
        CurrentInst = 0f;
        AllowChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (t_SlowTime.GetState(SteamVR_Input_Sources.RightHand))
        {
            SlowingTime();
        }
        if (!t_SlowTime.GetState(SteamVR_Input_Sources.RightHand))
        {
            NormalTime();
        }
        if (t_Shoot.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            pistolS_r.Fire();
        }
    }


    public void SlowingTime()
    {
        if(CurrentInst < DesiredInst && AllowChange == false)
        {
            CurrentInst += 0.1f;
            SlowEffect.intensity = CurrentInst;
        }
        if(CurrentInst >= DesiredInst)
        {
            Time.timeScale = 0.25f;
            AllowChange = true;
        }
    }

    public void NormalTime()
    {
        if (CurrentInst >= 0f)
        {
            CurrentInst -= 0.1f;
            SlowEffect.intensity = CurrentInst;
        }
        if (CurrentInst < 0.1f && AllowChange == true)
        {
            Time.timeScale = 1f;
            AllowChange = false;
        }
    }
}