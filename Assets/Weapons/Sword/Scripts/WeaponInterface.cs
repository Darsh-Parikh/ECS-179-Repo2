using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Weapons
{
    public interface I_WeaponInterface
    {
        float GetDamage();

        bool TurnOnCollider();
        bool TurnOffCollider();

        bool TurnOnTrail();
        bool TurnOffTrail();

        bool EnterSpecialMode();
        bool ExitSpecialMode();
    }
}