using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class SwordController : MonoBehaviour, I_WeaponInterface
    {
        public float damage;
        public GameObject swordCollider;
        public Behaviour swordTrail;                                            // TODO

        private bool inSpecialMode  = false;
        private float standardDamage    = 10f;
        private float specialDamage = 20f;

        public bool TurnOnCollider()
        {
            swordCollider.GetComponent<BoxCollider>().enabled = true;
            return true;
        }

        public bool TurnOffCollider()
        {
            swordCollider.GetComponent<BoxCollider>().enabled = false;
            return true;
        }

        public bool TurnOnTrail()
        {
            swordTrail.enabled = true;                                          // TODO
            return true;
        }

        public bool TurnOffTrail()
        {
            swordTrail.enabled = false;                                         // TODO
            return true;
        }

        public float GetDamage()
        {
            return damage;
        }

        public bool EnterSpecialMode()
        {
            inSpecialMode = true;
            damage = specialDamage;
            return true;
        }

        public bool ExitSpecialMode()
        {
            inSpecialMode = false;
            damage = standardDamage;
            return true;
        }

        //-+-+-+-+-+-+-+-+-

        void Start()
        {
            swordCollider = GameObject.Find("Sword_Collider");
            swordTrail.enabled = false;
            inSpecialMode = false;
            damage = standardDamage;
        }

        void Update()
        {
            // To VFX
        }

        //-+-+-+-+-+-+-+-+-

        public void DoDamage(GameObject enemy)
        {
            // TODO: Damage enemy
        }
    }
}