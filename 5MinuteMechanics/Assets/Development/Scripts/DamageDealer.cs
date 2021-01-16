using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public void DealRandomDamage()
    {
        Character[] characters = FindObjectsOfType<Character>();
        characters[Random.Range(0, characters.Length)].TakeDamage(Random.Range(10, 31));
    }
}
