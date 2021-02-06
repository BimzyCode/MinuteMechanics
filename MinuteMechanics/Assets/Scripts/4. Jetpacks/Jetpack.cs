using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public float maxFuel = 4f;
    public float thrustForce = 0.5f;
    public Rigidbody rigid;
    public Transform groundedTransform;
    public ParticleSystem effect;

    private float curFuel;

    // Start is called before the first frame update
    void Start()
    {
        curFuel = maxFuel; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") > 0f && curFuel > 0f)
        {
            curFuel -= Time.deltaTime;
            rigid.AddForce(rigid.transform.up * thrustForce, ForceMode.Impulse);
            effect.Play();
        }
        else if(Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, LayerMask.GetMask("Grounded")) && curFuel < maxFuel)
        {
            curFuel += Time.deltaTime;
            effect.Stop();
        }
        else
        {
            effect.Stop();
        }
    }
}
