using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    [SerializeField]
    Sprite redReticle;
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Sprite yellowReticle;
    [SerializeField]
    Image Reticle;

    public void UpdateReticle()
    {
        switch (GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                Reticle.sprite = redReticle;
                break;
            case Constants.Shotgun:
                Reticle.sprite = yellowReticle;
                break;
            case Constants.AssaultRifle:
                Reticle.sprite = blueReticle;
                break;
            default:
                return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
