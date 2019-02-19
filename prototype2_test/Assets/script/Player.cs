using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject Boss;

    public struct Bag
    {
        public int apple_count;
        public int banana_count;
        public int kiwi_count;
        public int pear_count;
        public int stawberry_count;
        public int total_count;
           
    }

    Bag bag;

    private const int move_energy=-1;

    bool gameOverFlag = false;
    
	// Use this for initialization
	void Start () {
        ClearBag();
	}
	
	// Update is called once per frame
	void Update () {
        if( !MainCamera.GetComponent<Scene_Manager>().IsRotated() && gameOverFlag == false)
            MovePlayer();
	}

    void MovePlayer()
    {
        Vector3 player_Position = this.transform.position;
        player_Position.x=Mathf.RoundToInt(player_Position.x);
        player_Position.y=Mathf.RoundToInt(player_Position.y);
        player_Position.z=Mathf.RoundToInt(player_Position.z);
        //print(player_Position.y);
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            if (player_Position.x <= -1.9f)
            {
                this.transform.Translate(-1, -1, 0);
                MainCamera.GetComponent<Scene_Manager>().SetRotateFlag(Scene_Manager.RotateDirection.up);
            }
            else
                this.transform.Translate(-1, 0, 0);
            Boss.GetComponent<Boss>().Energy_update(move_energy);
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            if (player_Position.x >=1.9f)
            {
                this.transform.Translate(1, -1, 0);
                MainCamera.GetComponent<Scene_Manager>().SetRotateFlag(Scene_Manager.RotateDirection.down);
            }
            else
                this.transform.Translate(1, 0, 0);
            Boss.GetComponent<Boss>().Energy_update(move_energy);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            if (player_Position.z <= -1.9f)
            {
                this.transform.Translate(0, -1, -1);
                MainCamera.GetComponent<Scene_Manager>().SetRotateFlag(Scene_Manager.RotateDirection.left);
            }
            else
                this.transform.Translate(0, 0, -1);
            Boss.GetComponent<Boss>().Energy_update(move_energy);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            if (player_Position.z >= 1.9f)
            {
                this.transform.Translate(0, -1, 1);
                MainCamera.GetComponent<Scene_Manager>().SetRotateFlag(Scene_Manager.RotateDirection.right);
            }
            else
            {
                this.transform.Translate(0, 0, 1);
            }
            Boss.GetComponent<Boss>().Energy_update(move_energy);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bin")
        {
            MainCamera.GetComponent<UIManager>().ClearBagImage();
           ClearBag();
            return;
        }
        if (other.gameObject.tag == "boss")
        {
            Boss.GetComponent<Boss>().CheckBag(bag);
            MainCamera.GetComponent<UIManager>().ClearBagImage();
            ClearBag();
            return;
        }
        if (bag.total_count >= 3)
        {
            return;
        }
        string fruit_get = other.gameObject.tag;
        if (fruit_get == "apple")
        {
            MainCamera.GetComponent<FruitManager>().GetFruit(other.gameObject, FruitManager.Fruit._apple);
            MainCamera.GetComponent<UIManager>().SetBagImage(FruitManager.Fruit._apple);
            bag.apple_count++;
            bag.total_count++;
        }
        else if (fruit_get == "banana")
        {
            MainCamera.GetComponent<FruitManager>().GetFruit(other.gameObject, FruitManager.Fruit._banana);
            MainCamera.GetComponent<UIManager>().SetBagImage(FruitManager.Fruit._banana);
            bag.banana_count++;
            bag.total_count++;
        }
        else if (fruit_get == "kiwi")
        {
            MainCamera.GetComponent<FruitManager>().GetFruit(other.gameObject, FruitManager.Fruit._kiwi);
            MainCamera.GetComponent<UIManager>().SetBagImage(FruitManager.Fruit._kiwi);
            bag.kiwi_count++;
            bag.total_count++;
        }
        else if (fruit_get == "pear")
        {
            MainCamera.GetComponent<FruitManager>().GetFruit(other.gameObject, FruitManager.Fruit._pear);
            MainCamera.GetComponent<UIManager>().SetBagImage(FruitManager.Fruit._pear);
            bag.pear_count++;
            bag.total_count++;
        }
        else if (fruit_get == "stawberry")
        {
            MainCamera.GetComponent<FruitManager>().GetFruit(other.gameObject, FruitManager.Fruit._stawberry);
            MainCamera.GetComponent<UIManager>().SetBagImage(FruitManager.Fruit._stawberry);
            bag.stawberry_count++;
            bag.total_count++;
        }

    }

    void ClearBag()
    {
        bag.apple_count = 0;
        bag.banana_count = 0;
        bag.kiwi_count = 0;
        bag.pear_count = 0;
        bag.stawberry_count = 0;
        bag.total_count = 0;
    }

    public void GameOver()
    {
        gameOverFlag = true;
    }
}
