using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGEnemy : MonoBehaviour
{
    private int health = 50;
    private int attack = 5;
    private int attackMultiplier = 1;

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
        attack = attack * attackMultiplier;
        return attack;
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
            attackMultiplier = attack * multiplier;
        }
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
