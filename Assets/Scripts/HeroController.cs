using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    private HeroHeal heroHeal;
    private HeroAttack heroAttack;
    private HeroMove heroMove;
    private GroundCheck groindCheck;

    void Start()
    {
        heroHeal = GetComponent<HeroHeal>();
        heroAttack = GetComponent<HeroAttack>();
        heroMove = GetComponent<HeroMove>();
        groindCheck = GameObject.Find("GroundCheck").GetComponent<GroundCheck>();
    }

    void Update()
    {
        heroMove.Fall(groindCheck.onGround);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("I press heal!");
            heroHeal.GetHealing();
        }


        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("I press attack!");
            heroAttack.Attack();
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("I press dash!");
            heroMove.Dash();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("I press jump!");
            heroMove.Jump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("I press s!");
            heroMove.FallFromPlatform(groindCheck.groundType, groindCheck.ground);
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            heroMove.Move(Input.GetAxisRaw("Horizontal"));
        }
        else heroMove.Move(0f);
    }
}
