using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageScreenController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float health = 100f;

    private float maxIntensity = 0.87f;
    private float minIntensity = -0.03f;
    public  Material screenDamageMat;

    private float GetMapping(float health)
    {
        return (health * (maxIntensity - minIntensity) / 100) + minIntensity;
    }

    void Start()
    {
        screenDamageMat.SetFloat("_Vignette_radius", minIntensity);
    }

    void Update()
    {
        //--------- get health from Player
        health = _player.GetComponent<ThirdPersonController>().health;

        //--------- get intensity from health
        var intensity = GetMapping(health);

        //--------- apply effect
        screenDamageMat.SetFloat("_Vignette_radius", intensity);
    }
}
