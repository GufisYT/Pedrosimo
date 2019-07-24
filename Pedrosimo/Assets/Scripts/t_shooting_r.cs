using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class t_shooting_r : MonoBehaviour
{
    public SteamVR_ActionSet m_Action;
    public Light SlowEffect;
    public SteamVR_Action_Boolean t_Shoot;
    private SteamVR_Action_Boolean t_SlowTime;
    public Pistol_Shooting_r pistolS_r;


    // Start is called before the first frame update
    void Start()
    {
        t_Shoot = SteamVR_Actions.main_Shoot;
        t_SlowTime = SteamVR_Actions.main_SlowTime;
        SlowEffect.intensity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (t_SlowTime.GetState(SteamVR_Input_Sources.RightHand))
        {
            SlowingTime();
        }
        if (t_Shoot.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            pistolS_r.Fire();
        }
    }

    public void SlowingTime()
    {
        SlowEffect.intensity -= 0.1f;
    }
}