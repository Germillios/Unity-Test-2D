using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    /// <summary>
    /// The Player's or Enemy's movement speed
    /// </summary>
    [SerializeField]
    private float speed;

    private Animator myAnimator;

    /// <summary>
    /// The Player's or Enemy's direction
    /// </summary>
    protected Vector2 direction;

    private Rigidbody2D myRigidbody;

    public bool IsMoving
    {
        get { return direction.x != 0 || direction.y != 0; }
    }

    // Use this for initialization
    protected virtual void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	// Update is called once per frame
	protected virtual void Update ()
    {
        //Move();
        HandleLayers();
	}
    // Fixed Update is called once per manipulation with Rigidbody
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        /* Physics system is frame rate independent, so:
           1) Time.deltaTime isn't needed
           2) The FixedUpdate is used instead Update
        */
        myRigidbody.velocity = direction.normalized * speed;
        //transform.Translate(direction * speed * Time.deltaTime);
    }
    public void HandleLayers()
    {
        if (IsMoving)
        {
            ActivateLayer("WalkLayer");
            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
        }
        else
            myAnimator.SetLayerWeight(1, 0);
    }
    // Turn on one layer and turn off other layers at the same moment
    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
            myAnimator.SetLayerWeight(i, 0);
        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
    }
}
