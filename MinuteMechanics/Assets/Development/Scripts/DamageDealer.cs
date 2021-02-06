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

    public void DealBigDamage()
    {
        Character[] characters = FindObjectsOfType<Character>();
        for (int i = 0; i < 1000; i++)
        {
            characters[Random.Range(0, characters.Length)].TakeDamage(Random.Range(10, 31));
        }
    }
}
