using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using TMPro;
public class SpellManager : MonoBehaviour
{
    public Animator animator;

    public bool isAbleToAttack = true;

    public int spellIndex;
    public GameObject[] spellDisplay;
    public float[] spellCosts;
    public int spellCount = 15;

    public float manaCost = 10;
    public float playerMana = 0;
    public float playerMana2 = 0;
    public float playerMana3 = 0;
    public float manaGainRate = 0;
    public float manaGainRate2 = 0;
    public float manaGainRate3 = 0;
    public Slider manaBar;
    public int fireCount, waterCount, airCount, earthCount;
    public TMP_Text manaCostDisplay;

    public Button Summon;


    public GameObject projectileCaster;

    public GameObject[] ElementIcon1;
    
  //  public GameObject[] ElementIcon2;

  //  public GameObject[] ElementIcon3;

  //  public GameObject[] ElementIcon4;
    public Button[] elementButtons;
    public int[] DisplayIcons; //5 is nothing selected
    public int numberOfElements = 4;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        manaBar.value = playerMana;
        if (playerMana <= 100f)
        {
            playerMana += manaGainRate * Time.deltaTime;

        }
        
        displaySpellIcon(calculateSpellUse());
        manaCostDisplay.text = spellCosts[calculateSpellUse()].ToString();
        manaCost = spellCosts[calculateSpellUse()];
        if (playerMana >= manaCost && calculateSpellUse() != 15 && isAbleToAttack)
        {
            Summon.interactable = true;
        }
        else
        {
            Summon.interactable = false;
        }
    }

    public void summonButton()
    {
        if (playerMana >= manaCost && calculateSpellUse() != 15 && isAbleToAttack)
        {
            Debug.Log("Casting a spell");

            playerMana -= manaCost;
            projectileCaster.GetComponent<PlayerSpellSpawner>().summonSpell(calculateSpellUse());
            //projectileCaster.GetComponent<projectileCaster>()
        }
    }
    public int calculateSpellUse()
    {
        int index = 0;
        if (fireCount == 1 && waterCount == 0 && airCount == 0 && earthCount == 0)
        {
            index = 0;
        }
        else if (fireCount == 0 && waterCount == 1 && airCount == 0 && earthCount == 0)
        {

            index = 1;
        }
        else if (fireCount == 0 && waterCount == 0 && airCount == 1 && earthCount == 0)
        {
            index = 2;
        }
        else if (fireCount == 0 && waterCount == 0 && airCount == 0 && earthCount == 1)
        {
            index = 3;
        }
        //===================== end of the single statements
        else if (fireCount == 1 && waterCount == 1 && airCount == 0 && earthCount == 0)
        {
            index = 4;

        }
        else if (fireCount == 1 && waterCount == 0 && airCount == 1 && earthCount == 0)
        {
            index = 5;
        }
        else if (fireCount == 1 && waterCount == 0 && airCount ==0 && earthCount ==1)
        {
            index = 6;
        }
        else if (fireCount == 0 && waterCount == 1&& airCount == 1 && earthCount ==0)
        {
            index = 7;
        }
        else if (fireCount == 0 && waterCount == 1 && airCount == 0 && earthCount == 1)
        {
            index = 8;
        }
        else if (fireCount == 0 && waterCount == 0 && airCount == 1 && earthCount == 1)
        {
            index = 9;
        }
        //end of 2 thingy statements. 
        else if (fireCount == 1 && waterCount == 1 && airCount == 1 && earthCount == 0)
        {
            index = 10;
        }
        else if (fireCount == 1 && waterCount == 1 && airCount == 0 && earthCount == 1)
        {
            index = 11;
        }
        else if (fireCount == 1 && waterCount == 0 && airCount ==1 && earthCount == 1)
        {
            index = 12;

        }
        else if (fireCount == 0 && waterCount == 1 && airCount == 1 && earthCount == 1)
        {
            index = 13;
        }
        //============================ end of triples
        else if(fireCount == 1 && waterCount == 1 && airCount == 1 && earthCount == 1)
        {
            index = 14;
        }
        else
        {
            index = 15;
        }
        return index;
    }


    public void displaySpellIcon(int index)
    {
        for (int a = 0; a < spellCount; a++)
        {
            if(index == a)
            {
                spellDisplay[a].SetActive(true);
            }
            else
            {
                spellDisplay[a].SetActive(false);
            }
        }
    }
    public void handleButton1()
    {
        if(fireCount == 0)
        {
            FireSelect();
        }
        else
        {
            Remove1();
        }
    }
    public void handleButton2()
    {
        if (waterCount == 0)
        {
            WaterSelect();
        }
        else
        {
            Remove2();
        }
    }
    public void handleButton3()
    {
        if (airCount == 0)
        {
            AirSelect();
        }
        else
        {
            Remove3();
        }
    }
    public void handleButton4()
    {
        if (earthCount == 0)
        {
            EarthSelect();
        }
        else
        {
            Remove4();
        }
    }
    public void FireSelect()
    {
        fireCount = 1;

        DisplayIcons[0] = 1;
        ElementIcon1[0].SetActive(true);
        UpdateElementIcons();
        //CheckIfAdd(1);
    }
    public void WaterSelect()
    {
        waterCount = 1;

        DisplayIcons[0] = 2;
        ElementIcon1[1].SetActive(true);
        UpdateElementIcons();
        //CheckIfAdd(2);
    }
    public void AirSelect()
    {
        airCount = 1;

        DisplayIcons[0] = 3;
        ElementIcon1[2].SetActive(true);
        UpdateElementIcons();
        //CheckIfAdd(3);
    }
    public void EarthSelect()
    {
        earthCount = 1;
 
        DisplayIcons[0] = 4;
        ElementIcon1[3].SetActive(true);
        UpdateElementIcons();
        //CheckIfAdd(4);
    }

    public void CheckIfAdd(int indexElementAdd)
    {
        /*
        for (int a = 0; a < 4; a++)
        {
            if (DisplayIcons[a] == 5)
            {
                DisplayIcons[a] = indexElementAdd-1;
                break;
            }
        }
        UpdateElementIcons();*/
    }

    public void Remove1()
    {
        fireCount = 0;
    
        DisplayIcons[0] = 5;
        ElementIcon1[0].SetActive(false);
        UpdateElementIcons();
    }
    public void Remove2()
    {
        waterCount = 0;
    
        DisplayIcons[1] = 5;
        ElementIcon1[1].SetActive(false);
        UpdateElementIcons();
        Debug.Log("removing xingqiu");
    }
    public void Remove3()
    {
        airCount = 0;

        DisplayIcons[2] = 5;
        ElementIcon1[2].SetActive(false);
        UpdateElementIcons();
    }
    public void Remove4()
    {
        earthCount = 0;
   
        ElementIcon1[3].SetActive(false);
        DisplayIcons[3] = 5;
        
    }

    public void UpdateElementIcons()
    {
        /*
        for (int b = 0; b < numberOfElements; b++)
        {

            if (DisplayIcons[b] == 1)
            {
                ElementIcon1[DisplayIcons[0]].SetActive(true);
            }
            else
            {
                ElementIcon1[b].SetActive(false);
                //Debug.Log(b);
            }
        }
        /*
        for (int b = 0; b < numberOfElements; b++)
        {

            if (b == DisplayIcons[1])
            {
                ElementIcon2[DisplayIcons[1]].SetActive(true);
            }
            else
            {
                ElementIcon2[b].SetActive(false);
            }
        }
        for (int b = 0; b < numberOfElements; b++)
        {

            if (b == DisplayIcons[2])
            {
                ElementIcon3[DisplayIcons[2]].SetActive(true);
            }
            else
            {
                ElementIcon3[b].SetActive(false);
            }
        }
        for (int b = 0; b < numberOfElements; b++)
        {

            if (b == DisplayIcons[3])
            {
                ElementIcon4[DisplayIcons[3]].SetActive(true);
            }
            else
            {
                ElementIcon4[b].SetActive(false);
            }
        }*/
        /*
        fireCount = 0;
        waterCount = 0;
        airCount = 0;
        earthCount = 0;
        if(DisplayIcons[0] == 1)
        {
            fireCount = 1;
        }
        if (DisplayIcons[1] == 1)
        {
            waterCount = 1;
        }
        if (DisplayIcons[2] == 1)
        {
            airCount = 1;

        }
        if (DisplayIcons[3] == 1)
        {
            earthCount = 1;
        }*/
        /*
        for(int b = 0; b < 4; b++)
        {
            if(DisplayIcons[b] == 0)
            {
                fireCount++;
            }
        }

        for (int b = 0; b < 4; b++)
        {
            if (DisplayIcons[b] == 1)
            {
                waterCount++;
            }
        }
        for (int b = 0; b < 4; b++)
        {
            if (DisplayIcons[b] == 2)
            {
                airCount++;
            }
        }
        for (int b = 0; b < 4; b++)
        {
            if (DisplayIcons[b] == 3)
            {
                earthCount++;
            }
        }*/
    }
    public void UpdateMana1()
    {
        manaGainRate = manaGainRate2;
        playerMana = playerMana2;
    }
    public void UpdateMana2()
    {
        manaGainRate = manaGainRate3;
        playerMana = playerMana3;
    }
}

