using System;
using UnityEngine;

public class PropsButton : PokeButton
{
    enum PressType { LEFT, RIGHT, CONFIRM };
    [SerializeField] PressType pressType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Press()
    {
        base.Press();
        switch (pressType)
        {
            case PressType.LEFT:
                ControlPanel.instance.ChangePropIndex(-1);
            break;
            case PressType.RIGHT:
                ControlPanel.instance.ChangePropIndex(11);
            break;
            case PressType.CONFIRM:
                ControlPanel.instance.SpawnPropBox();
            break;
        }
    }
}
