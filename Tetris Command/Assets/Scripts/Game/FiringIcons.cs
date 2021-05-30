using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiringIcons : MonoBehaviour
{

    [SerializeField] Image[] firingIcons = new Image[3];
    Color opaque = new Color(1, 1, 1, 0.3f);
    [SerializeField]Barrel barrel;

    public void UpdateIcons(int n)
    {
        for(int i=0; i < firingIcons.Length; i++)
        {
            if (i == n)
            {
                firingIcons[i].color = Color.white;
            }
            else
            {
                firingIcons[i].color = opaque;
            }
        }
    }
}
