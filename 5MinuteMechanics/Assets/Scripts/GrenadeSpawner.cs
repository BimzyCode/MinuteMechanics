using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpawner : MonoBehaviour
{
    public GameObject grenade;
    public Transform spawnPoint;
    public float grenadeForce = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SpawnGrenade();
        }
    }

    private void SpawnGrenade()
    {
        GameObject grenadeObj = Instantiate(grenade, spawnPoint.position, Quaternion.identity);
        grenadeObj.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * grenadeForce, ForceMode.Impulse);
    }
}
