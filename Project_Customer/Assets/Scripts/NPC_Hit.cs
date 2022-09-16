using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Hit : MonoBehaviour
{
    [HideInInspector]
    public bool hit = false;
    private void OnMouseOver()
    {
        hit = true;
    }
    private void OnMouseExit()
    {
        hit = false;
    }
}
