using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public ShieldState shieldState;

    [SerializeField] SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShieldStateMachine();
    }

    void ShieldStateMachine()
    {
        switch (shieldState)
        {
            case ShieldState.Triangle:

                spr.color = Color.red;

                if(Input.GetAxis("Mouse ScrollWheel") > 0f) //scroll up
                {
                    shieldState = ShieldState.Circle;
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0f) //scroll down
                {
                    shieldState = ShieldState.Square;
                }

                break;

            case ShieldState.Square:

                spr.color = Color.magenta;

                if (Input.GetAxis("Mouse ScrollWheel") > 0f) //scroll up
                {
                    shieldState = ShieldState.Triangle;
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0f) //scroll down
                {
                    shieldState = ShieldState.Circle;
                }

                break;

            case ShieldState.Circle:

                spr.color = Color.blue;

                if (Input.GetAxis("Mouse ScrollWheel") > 0f) //scroll up
                {
                    shieldState = ShieldState.Square;
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0f) //scroll down
                {
                    shieldState = ShieldState.Triangle;
                }

                break;
        }
    }
}

public enum ShieldState
{
    Triangle,
    Square,
    Circle
}