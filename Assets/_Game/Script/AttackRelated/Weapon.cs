using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Character character;

    private void Update()
    {
        WeaponOnOrOff();
    }
    public void WeaponOnOrOff()
    {
        if (character.canAttack == false)
        {
            gameObject.SetActive(false);
        }
    }
}
