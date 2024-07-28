using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache
{
    public const string STRING_CHARACTER = "Character";
    public const string STRING_WEAPON = "Weapon";
    public const string STRING_TARGET = "TargetIndicator";
    public const string CACHE_ANIM_IDLE = "Idle";
    public const string CACHE_ANIM_Run = "Run";
    public const string CACHE_ANIM_Dead = "Dead";
    public const string CACHE_ANIM_Attack = "Attack";
    public const string CACHE_BULLET = "Bullet";
    public const string CACHE_BOT = "Bot";
    public const string CACHE_PLAYER = "Player";


    private static Dictionary<Collider, Character> characters = new Dictionary<Collider, Character>();

    public static Character GetCharacter(Collider collider)
    {
        if (!characters.ContainsKey(collider))
        {
            characters.Add(collider, collider.GetComponent<Character>());
        }
        return characters[collider];
    }
}

