using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;

    [SerializeField]
    private float initHealth;

    [SerializeField]
    private float initMana;

    protected override void Start()
    {
        health.Initialize(initHealth, initHealth);
        mana.Initialize(initMana, initMana);
        base.Start();
    }

    // Update is called once per frame
    protected override void Update ()
    {
        GetInput();
        base.Update();
	}
    /// <summary>
    /// Listen to the Player's input
    /// </summary>
    public void GetInput()
    {
        direction = Vector2.zero; // Żeby nie nakładały się na siebie (np. zwielokrotniony up)
        // This code is used for debugging only
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.CurrentValue -= 10;
            mana.CurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.CurrentValue += 10;
            mana.CurrentValue += 10;
        }   
        //
        if (Input.GetKey(KeyCode.W))
            direction += Vector2.up;
        if (Input.GetKey(KeyCode.A))
            direction += Vector2.left;
        if (Input.GetKey(KeyCode.S))
            direction += Vector2.down;
        if (Input.GetKey(KeyCode.D))
            direction += Vector2.right;
    }
}
