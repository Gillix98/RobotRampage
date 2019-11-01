using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pickups;

    //1
     void spawnPickups()
    {
        // instantiate a random pickup
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    //2
    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickups();
    }

    //3
    // Start is called before the first frame update
    void Start()
    {
        spawnPickups(); 
    }

    //4
    // Update is called once per frame
    public void PickupWasPickedUp()
    {
        StartCoroutine("respawnPickup"); 
    }
}
