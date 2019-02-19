using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public GameObject MainCamera;
    public GameObject player;
    public FruitManager.Fruit[] requireFruit=new FruitManager.Fruit[3];

    struct RequireCount
    {
        public int apple_count;
        public int banana_count;
        public int stawberry_count;
        public int pear_count;
        public int kiwi_count;
        public int anything_count;
    }
    RequireCount requireCount;

    private int energy=50;
    private const int happy_energy=40;
    private const int purnish_energy = -5;
    private bool anythingFlag = false;

    // Use this for initialization
    void Start () {
        
        ClearRequireCount();
        RequireFoods();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RequireFoods()
    {
        int thinking = Random.Range(0, 10);    
        if (thinking <= 1 && anythingFlag==true)                       //any thing
        {
            for(int i = 0; i <= 2; i ++)
            {
                requireFruit[i] = FruitManager.Fruit._anythng;
                requireCount.anything_count++;
            }
            anythingFlag = false;
        }
        else                                        //specified fruit
        {
            for(int i = 0; i <= 2; i++)
            {
                int random_fruit = Random.Range(0, 5);
                switch (random_fruit)
                {
                    case 0: requireFruit[i] = FruitManager.Fruit._apple; requireCount.apple_count++; break;
                    case 1: requireFruit[i] = FruitManager.Fruit._banana;  requireCount.banana_count++; break;
                    case 2: requireFruit[i] = FruitManager.Fruit._kiwi; requireCount.kiwi_count++; break;
                    case 3: requireFruit[i] = FruitManager.Fruit._pear;requireCount.pear_count++; break;
                    case 4: requireFruit[i] = FruitManager.Fruit._stawberry; requireCount.stawberry_count++; break;
                }
            }
            anythingFlag = true;
        }
        MainCamera.GetComponent<UIManager>().SetBubbleImage(requireFruit);
       
    }

    public void CheckBag(Player.Bag bag)
    {
        //print(bag.total_count);
        if (requireCount.anything_count > 0 && bag.total_count==3)
        {
            //print("right1");
            Energy_update(happy_energy);
            MainCamera.GetComponent<UIManager>().SetHappy();
        }
        else if(bag.apple_count==requireCount.apple_count &&
            bag.banana_count==requireCount.banana_count &&
            bag.kiwi_count==requireCount.kiwi_count &&
            bag.pear_count==requireCount.pear_count &&
            bag.stawberry_count==requireCount.stawberry_count &&
            requireCount.anything_count==0)
        {
            //print("right");
            Energy_update(happy_energy);
            MainCamera.GetComponent<UIManager>().SetHappy();
        }
        else
        {
            //print("wrong");
            Energy_update(purnish_energy);
            MainCamera.GetComponent<UIManager>().SetAngry();
        }
        ClearRequireCount();
        RequireFoods();
      
    }

    void ClearRequireCount()
    {
        requireCount.apple_count = 0;
        requireCount.banana_count = 0;
        requireCount.kiwi_count = 0;
        requireCount.pear_count = 0;
        requireCount.stawberry_count = 0;
        requireCount.anything_count = 0;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void Energy_update(int value)   
    {
        energy = energy + value;
        MainCamera.GetComponent<UIManager>().EnergyUI_update(energy);
        if (energy >= 100)
        {
            MainCamera.GetComponent<UIManager>().WinText_avtive();
            player.GetComponent<Player>().GameOver(); 
          
        }else if (energy <= 0)
        {
            MainCamera.GetComponent<UIManager>().LostText_active();
            player.GetComponent<Player>().GameOver();
            
        }
        
    }
}
