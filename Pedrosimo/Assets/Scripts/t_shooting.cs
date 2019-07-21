using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class t_shooting : MonoBehaviour
{
    public Light XrayEffect;
    public Material m_Xray;
    public SteamVR_Action_Boolean t_Shoot;
    public SteamVR_Action_Boolean t_Xray;
    public SteamVR_Input_Sources t_hand;
    public Pistol_Shooting pistolS;
    

    // Start is called before the first frame update
    void Start()
    {
        t_Shoot.AddOnStateDownListener(TriggerDown, t_hand);
        t_Xray.AddOnStateDownListener(XrayOn, t_hand);
        t_Xray.AddOnStateUpListener(XrayOff, t_hand);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void XrayOff(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        XrayEffect.intensity = 0f;
        m_Xray.SetFloat("Vector1_545B4A0A", 0f);
    } 

    public void XrayOn(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        XrayEffect.intensity = 1.25f;
        m_Xray.SetFloat("Vector1_545B4A0A", 0.5f);
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        pistolS.Fire();
    }
}
