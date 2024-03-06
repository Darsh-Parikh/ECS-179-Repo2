using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingWeapon : MonoBehaviour
{

    [SerializeField]
    private Transform weaponPoint;

    [SerializeField]
    private Transform weaponPivot;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 weaponOffset = transform.position - weaponPivot.position;
        
        transform.SetParent(weaponPoint);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        transform.gameObject.SetActive(true);
    }

    internal void Equip()
    {
        transform.gameObject.SetActive(true);
    }

    internal void UnEquip()
    {
        transform.gameObject.SetActive(false);
    }
}
