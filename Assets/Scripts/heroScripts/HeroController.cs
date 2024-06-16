using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    private HeroHeal heroHeal;
    private HeroMana heroMana;
    private HeroAttack heroAttack;
    private HeroMove heroMove;
    private GroundCheck groundCheck;
    private SaveManager saveManager;
    private HeroStates heroStates;
    private Magic magic;

    private InterfaceController interfaceController;

    void Start()
    {
        heroHeal = GetComponent<HeroHeal>();
        heroMana = GetComponent<HeroMana>();
        heroAttack = GetComponent<HeroAttack>();
        heroMove = GetComponent<HeroMove>();
        heroStates = GetComponent<HeroStates>();
        magic = GetComponent<Magic>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        groundCheck = GameObject.Find("GroundCheck").GetComponent<GroundCheck>();
        interfaceController = GameObject.Find("Interface").GetComponent<InterfaceController>();
    }

    void Update()
    {
        heroMove.Fall(groundCheck.onGround);

        if (heroStates.HeroEmploymentCheck() && !interfaceController.isStoreActiv && !interfaceController.levelUpWinActiveState && !heroStates.isDied)
        {
            if (Input.GetKeyDown(KeyCode.F) && !heroStates.IsHeroInActiveZone())
            {
                if (interfaceController.inventoryItemNumber == 0)
                {
                    heroHeal.GetHealed();
                }
                if (interfaceController.inventoryItemNumber == 1)
                {
                    heroMana.GetMana();
                }
            }


            if (Input.GetButtonDown("Fire2") && saveManager.currentHeroMP >= 20)
            {
                magic.StartCast();
            }


            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("I press attack!");
                heroAttack.Attack();
            }


            if (Input.GetKeyDown(KeyCode.LeftShift) && groundCheck.onGround)
            {
                Debug.Log("I press dash!");
                heroMove.Dash();
            }


            if (Input.GetKeyDown(KeyCode.Space) && groundCheck.onGround)
            {
                Debug.Log("I press jump!");
                heroMove.Jump();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("I press s!");
                heroMove.FallFromPlatform(groundCheck.groundType, groundCheck.ground);
            }


            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !heroStates.isDashing && !heroStates.isHealing && !heroStates.isDrinkingMana && !magic.isCasting && !heroStates.isAttacking)
            {
                heroMove.Move(Input.GetAxisRaw("Horizontal"));
            }
            else if (!heroStates.isDashing)
            {
                heroMove.Move(0f);
            }
        }
    }
}
