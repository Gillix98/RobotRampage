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
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text pickupText;
    [SerializeField]
    private Text waveText;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private Text waveClearText;
    [SerializeField]
    private Text newWaveText;
    [SerializeField]
    Player player;

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
        SetArmorText(player.armor);
        SetHealthText(player.health);
    }

    public void SetArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
    }

    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }

    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }

    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }

    public void SetWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }

    public void SetEnemyText(int enemy)
    {
        enemyText.text = "Enemies: " + enemy;
    }

    public void ShowWaveClearBonus()
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }

    IEnumerator hideWaveClearbonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }

    public void SetPickUpText(string text)
    {
        pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;

        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }

    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<Text>().enabled = false;
    }

    public void ShowNewWave()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }

    IEnumerator hideNewWave()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
