using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunEquipper : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;

    public static string activeWeaponType;

    public GameObject pistol;
    public GameObject assaultrifle;
    public GameObject shotgun;

    GameObject activeGun;
    // Start is called before the first frame update
    void Start()
    {
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;
    }

    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultrifle.SetActive(false);
        shotgun.SetActive(false);

        weapon.SetActive(true);
        activeGun = weapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("2"))
        {
            loadWeapon(assaultrifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateReticle();
        }
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
