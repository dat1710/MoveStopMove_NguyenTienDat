using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float range;
    [SerializeField] private GameObject targetIndicator;

    private Vector3 destPoint;
    private bool walkPointSet;
    private GameManager gameManager;

    private void Start()
    {
        Invoke("FindGameManager", 0.6f);
        RandomSkin();
    }
    private void Find()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        FindTarget();
        Patrol();
        if (listAttack.Count != 0)
        {
            walkPointSet = false;
        }
    }

    public void Patrol()
    {
        if (!walkPointSet)
        {
            if (listAttack.Count != 0)
            {
                ChangeAnim(Cache.CACHE_ANIM_Attack);
                Invoke("Attack", 0.8f);
            }
            else
            {
                Invoke("SearchForDest", 2f);
                ChangeAnim(Cache.CACHE_ANIM_IDLE);
            }
        }
        if (walkPointSet)
        {
            agent.SetDestination(destPoint);
            ChangeAnim(Cache.CACHE_ANIM_Run);
        }
        if (Vector3.Distance(transform.position, destPoint) < 0.1) walkPointSet = false;
    }

    public void HideTarget()
    {
   
        if (targetIndicator.activeSelf)
        {
            targetIndicator.SetActive(false);
        }
    }
    public void SearchForDest()
    {
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(destPoint, out hit, range, NavMesh.AllAreas))
        {
            destPoint = hit.position;
            walkPointSet = true;
        }
    }
    public void RandomSkin()
    {
        Material randomPant = pants[Random.Range(0, pants.Length)];
        currentWeaponData = weaponDatas[Random.Range(0, weaponDatas.Length)];
        GameObject randomHat = hats[Random.Range(0, hats.Length)];
        Material randomColor = colors[Random.Range(0, colors.Length)];
        currentWeaponData.weaponPrefab.transform.localScale = new Vector3(70, 70, 70);
        AddToCharacter(currentWeaponData.weaponPrefab, weaponPoint);

        randomHat.transform.localScale = new Vector3(1, 1, 1);
        AddToCharacter(randomHat, hatPoint);
        
        SkinnedMeshRenderer skin = body.GetComponent<SkinnedMeshRenderer>();
        skin.material = randomColor;
        SkinnedMeshRenderer skinnedMeshRenderer = pantPoint.GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.material = randomPant;
    }
}
