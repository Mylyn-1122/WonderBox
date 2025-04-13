using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGPlayer : MonoBehaviour
{
    private int health = 100;
    private int attack = 2;
    private int attackMultiplier = 1;
    private int defense = 10;

    public int getHealth()
    {
        return health;
    }
    public void setHealth(int damage)
    {
        health = health - damage;
    }
    public int getAttack()
    {
        return attack * attackMultiplier;
    }
    public int getAttackMultiplier()
    {
        return attackMultiplier;
    }
    public void setAttackMultiplier(int multiplier)
    {
        if (multiplier == 0)
        {
            attackMultiplier = 1;
        }
        else
        {
            attackMultiplier = attackMultiplier + multiplier;
        }
    }
    public int getDefense()
    {
        return defense;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

}
