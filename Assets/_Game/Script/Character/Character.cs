using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Character : GameUnit
{
    [SerializeField] protected List<Character> listAttack = new List<Character>();
    [SerializeField] protected Character target;
    [SerializeField] protected Bullet currentBullet;
    [SerializeField] protected GameObject weapon;
    [SerializeField] private string currentAnim;
    [SerializeField] protected Animator playerAnimator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float timeResetAtt = 2f;
    [SerializeField] protected WeaponData[] weaponDatas;
    [SerializeField] protected GameObject[] weapons;
    [SerializeField] protected GameObject[] hats;
    [SerializeField] protected Material[] pants;
    [SerializeField] protected Material[] colors;
    [SerializeField] protected GameObject weaponPoint;
    [SerializeField] protected GameObject hatPoint;
    [SerializeField] protected GameObject pantPoint;
    [SerializeField] protected GameObject body;
    [SerializeField] protected Canvas canvasDead;
    protected WeaponData currentWeaponData;
    public Action<Character> OnDeathRemove;

    protected bool isMoving;
    public bool canAttack = true;
    public void RemoveCharacterFromListWhenDeath(Character character)
    {
        if (character == null) return;
        if (!listAttack.Contains(character)) return;
        listAttack.Remove(character);
    }

    public void AddToAttackList(Character character)
    {
        if (!listAttack.Contains(character))
        {
            listAttack.Add(character);
        }
    }

    public void RemoveFromAttackList(Character character)
    {
        if (listAttack.Contains(character))
        {
            listAttack.Remove(character);
            target = null;
        }
    }
    public void ShowTarget()
    {
        Transform targetIndicator = transform.Find(Cache.STRING_TARGET);
        if (targetIndicator != null)
        {
            targetIndicator.gameObject.SetActive(true);
        }
    }
    protected virtual void FindTarget()
    {
        if (listAttack.Count <= 0) return;
        target = listAttack[0];
    }
    public void Attack()
    {
        if (target != null)
        {
            if (canAttack == true)
            {
                Vector3 direction = (target.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = lookRotation;
                Bullet clone = HBPool.Spawn<Bullet>(currentWeaponData.bulletType, transform.position, Quaternion.identity);
                clone.shooter = this;
                clone.Fire(attackPoint.transform.position,target.transform.position);
                canAttack = false;
                weapon.SetActive(false);
                Invoke("EnableWeapon", (timeResetAtt - 0.5f));
                Invoke("ResetAttack", timeResetAtt);
            }
        }
    }
    public void AddToCharacter(GameObject itemPrefab, GameObject Point)
    {
        GameObject itemInstance = Instantiate(itemPrefab, Point.transform.position, Point.transform.rotation);
        itemInstance.transform.parent = Point.transform;
    }
    public void EnableWeapon()
    {
        weapon.SetActive(true);
    }
    public void ResetAttack()
    {
        if (canAttack == false)
        {
            canAttack = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Cache.CACHE_BULLET))
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet != null && bullet.shooter != this)
            {
                OnDeathRemove?.Invoke(this);
                AttackRange attackRange = new AttackRange();
                attackRange.CharacterGetOutList(this.GetComponent<Collider>());
                if (this.CompareTag(Cache.CACHE_BOT))
                {
                    GetComponent<NavMeshAgent>().enabled = false;
                }
                if (this.CompareTag(Cache.CACHE_PLAYER))
                {
                    canvasDead.gameObject.SetActive(true);
                }
                ChangeAnim(Cache.CACHE_ANIM_Dead);
                Invoke("Disappear", 0.8f);
            }
        }
    }
    void Disappear()
    {
        Destroy(this.gameObject);
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            playerAnimator.ResetTrigger(animName);
            currentAnim = animName;
            playerAnimator.SetTrigger(currentAnim);
        }
    }
}
