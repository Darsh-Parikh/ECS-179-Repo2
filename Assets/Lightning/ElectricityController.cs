using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class ElectricityController : MonoBehaviour
{

    [SerializeField] private bool inTesting;
    [SerializeField] private AudioClip thunderSound;

    [SerializeField] private float height;
    [SerializeField] private float start_x;
    [SerializeField] private float start_z;
    [SerializeField] private float radius;

    private ParticleSystem electricity;
    private AudioSource audioSource;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        electricity = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = thunderSound;
        StopElectricity();

        ChangeLocation(start_x, start_z);
        ChangeHeight(height);
        ChangeRadius(radius);

        if (inTesting)
        {
            time = 9f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inTesting)
        {
            time += Time.deltaTime;
            if (time > 10f)
            {
                ChangeLocation(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                Debug.Log("Electricity about to start!");
                
                StartElectricity();
                time = 0f;
            }
        }
    }

    public void StartElectricity()
    {
        electricity.Play();
        audioSource.Play();
    }

    public void StopElectricity()
    {
        electricity.Stop();
        audioSource.Stop();
    }

    public void ChangeLocation(float x, float z)
    {
        transform.position = new Vector3(x, transform.position.y, z);
    }

    public void ChangeHeight(float height)
    {
        transform.position = new Vector3(transform.position.x, height, transform.position.z);

        var sh = electricity.shape;
        sh.scale = new Vector3(sh.scale.x, sh.scale.y, height * 0.033f);

        /**
         * The 0.033 factor was determined by tested at PositionY=1
         * and then changing the scaleZ while observing the cone's spread from the side view
         * And repeating the same for PositionY=2, PositionY=3, etc.
         * ScaleZ ~= 0.033 * PositionY  ,  where radius is measured in Unity units
         */
    }

    public void ChangeRadius(float radius)
    {
        var sh = electricity.shape;
        sh.angle = radius / 1.9f;

        /**
         * The 1.9 factor was determined by tested at Height=1, ScaleZ=0.033
         * and then changing the angle while observing the cone's spread from the top view
         * Angle ~= 1.9 * radius  ,  where radius is measured in Unity units
         */
    }
}
