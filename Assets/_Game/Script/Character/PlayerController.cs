using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private CharacterController characterController;
    private Vector3 _move;
    private GameObject currentWeapon;

    private void Update()
    {
        Move();
        FindTarget();
    }
    void Move()
    {
        float horizontal = _joystick.Horizontal;
        float vertical = _joystick.Vertical;
        if (horizontal == 0f && vertical == 0f)
        {
            if (listAttack.Count  != 0 )
            {
                ChangeAnim(Cache.CACHE_ANIM_Attack);
                Invoke("Attack", 0.8f);
            }
            else
            {
                ChangeAnim(Cache.CACHE_ANIM_IDLE);
            }
        }
        else
        {
            ChangeAnim(Cache.CACHE_ANIM_Run);
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            Quaternion newRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = newRotation;
        }
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection.Normalize();
        characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);
    }
    protected override void FindTarget()
    {
        base.FindTarget();
        foreach (Enemy i in listAttack)
        {
            i.HideTarget();
            if (i == target)
            {
                i.ShowTarget();
            }
        }
    }
    public void EquipItem(WeaponData newWeaponData)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }
        currentWeapon = Instantiate(newWeaponData.weaponPrefab, weaponPoint.transform.position, weaponPoint.transform.rotation);
        currentWeapon.transform.parent = weaponPoint.transform;
        currentWeapon.transform.localScale *= 3;
        currentWeaponData = newWeaponData;
    }
    public void EquipItem(GameObject newGameObject)
    {

    }
}
