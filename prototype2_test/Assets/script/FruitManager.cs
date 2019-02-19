using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour {
    
    public GameObject Apple_object;
    public GameObject Banana_object;
    public GameObject Stawberry_object;
    public GameObject Pear_object;
    public GameObject Kiwi_object;
    public GameObject Nothing;             //control location
    public GameObject GameScene;
    
    public enum Fruit { _apple,_banana, _stawberry, _pear,_kiwi,_anythng};

    Dictionary<Vector3, bool> fruitLocation = new Dictionary<Vector3, bool>();

    //bool isAbleToCreate = true;

    struct AllFruit
    {
        public int apple_count;
        public int banana_count;
        public int stawberry_count;
        public int pear_count;
        public int kiwi_count;
        public int total_count;
    }
    AllFruit allFruit;
    const int maxCount = 2;

    float new_x, new_y, new_z;
    Quaternion new_q;

    // Use this for initialization
    void Start () {
        allFruit.apple_count = 0;
        allFruit.banana_count = 0;
        allFruit.kiwi_count = 0;
        allFruit.pear_count = 0;
        allFruit.stawberry_count = 0;
        allFruit.total_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(allFruit.total_count<maxCount*5  && !this.gameObject.GetComponent<Scene_Manager>().IsRotated())
            CreateFruit();
    }


    void CreateFruit()
    {
        
        if (allFruit.apple_count < maxCount) 
        {
            InstantiateFruit(Apple_object);
            allFruit.apple_count++;
            allFruit.total_count++;
        }
        if( allFruit.banana_count< maxCount)
        {
            InstantiateFruit(Banana_object);
            allFruit.banana_count++;
            allFruit.total_count++;
        }
       if (allFruit.kiwi_count < maxCount)
        {
            InstantiateFruit(Kiwi_object);
            allFruit.kiwi_count++;
            allFruit.total_count++;
        }
        if ( allFruit.pear_count < maxCount)
        {
            InstantiateFruit(Pear_object);
            allFruit.pear_count++;
            allFruit.total_count++;
        }
        if (allFruit.stawberry_count < maxCount)
        {
            InstantiateFruit(Stawberry_object);
            allFruit.stawberry_count++;
            allFruit.total_count++;
        }
        
    }

    void InstantiateFruit(GameObject _fruit)
    {
        
        while (true)
        {
            RandomNewPosition();
            GameObject newNothing=GameObjectPool.GetInstance().Object_Instantiate(Nothing, new_x, new_y, new_z, new_q);
            Vector3 newLocalLocation = newNothing.transform.localPosition;
            
            if (fruitLocation.ContainsKey(newLocalLocation) && fruitLocation[newLocalLocation]==true)
            {
               // print("!!!!!!!"+newLocalLocation);
                GameObjectPool.GetInstance().Object_Disable(newNothing);
                continue;
            }
           //print(newLocalLocation);
            GameObjectPool.GetInstance().Object_Disable(newNothing);
            fruitLocation[newLocalLocation] = true;
            break;
        }
        GameObjectPool.GetInstance().Object_Instantiate(_fruit, new_x, new_y, new_z,new_q);
        
    }

    void RandomNewPosition()
    {
        
        int face=Random.Range(1, 6);
        switch (face)
        {
            case 1:
                new_x = 2.7f;    new_y = Random.Range(-2, 3);    new_z = Random.Range(-2, 3);
                new_q = Quaternion.AngleAxis(-90, Vector3.forward);
                break;
            case 2:
                new_x = -2.7f;   new_y = Random.Range(-2, 3);    new_z = Random.Range(-2, 3);
                new_q = Quaternion.AngleAxis(90, Vector3.forward);
                break;
            case 3:
                new_x = Random.Range(-2, 3);   new_y = Random.Range(-2, 3);    new_z = 2.7f;
                new_q = Quaternion.AngleAxis(90, Vector3.right);
                break;
            case 4:
                new_x = Random.Range(-2, 3);    new_y = Random.Range(-2, 3);   new_z = -2.7f;
                new_q = Quaternion.AngleAxis(-90, Vector3.right);
                break;
            case 5:
                new_x = Random.Range(-2, 3);    new_y = -2.7f;    new_z = Random.Range(-2, 3);
                new_q = Quaternion.AngleAxis(180, Vector3.forward) * Quaternion.AngleAxis(180,Vector3.up);
                break;
        }
        
    }

    public void GetFruit(GameObject _fruit,Fruit fruitName)
    {
        fruitLocation[_fruit.transform.localPosition] = false;
        GameObjectPool.GetInstance().Object_Disable(_fruit);
        switch (fruitName)
        {
            case Fruit._apple: allFruit.apple_count--;
                break;
            case Fruit._banana:allFruit.banana_count--;
                break;
            case Fruit._kiwi:allFruit.kiwi_count--;
                break;
            case Fruit._pear:allFruit.pear_count--;
                break;
            case Fruit._stawberry:allFruit.stawberry_count--;
                break;
        }
        allFruit.total_count--;
    }

    
}
