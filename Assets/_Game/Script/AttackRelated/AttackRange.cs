using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private Character owner;
    [SerializeField] private LayerMask characterLayer;

    public void CharacterGetInList(Collider other)
    {
        if (!IsInLayerMask(other.gameObject, characterLayer))
        {
            return;
        }
        Character character = Cache.GetCharacter(other);
        if (character != null && character != owner)
        {
            owner.AddToAttackList(character);
            character.OnDeathRemove += owner.RemoveCharacterFromListWhenDeath;
        }
    }

    public void CharacterGetOutList(Collider other)
    {
        if (!IsInLayerMask(other.gameObject, characterLayer)) return;
        Character characters = Cache.GetCharacter(other);
        if (characters != null && characters != owner)
        {
            owner.RemoveFromAttackList(characters);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterGetInList(other);
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterGetOutList(other);
        if (other.CompareTag(Cache.CACHE_BOT))
        {
          Enemy bot = other.gameObject.GetComponent<Enemy>();
            if (bot != null)
            {
                bot.HideTarget();
            }
        }
    }
    private bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return (layerMask == (layerMask | (1 << obj.layer)));
    }
}