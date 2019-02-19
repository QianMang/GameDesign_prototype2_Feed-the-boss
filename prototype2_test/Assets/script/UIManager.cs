using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour {
    public Image[] bag=new Image[3];
    public GameObject happyEmotion;
    public GameObject angryEmotion;
    public Text energy_text;
    public Text win_text;
    public Text lose_text;
    public Button Retry_btn;
    public GameObject thinking_bubble;
    public GameObject[] boss_bubble = new GameObject[3];

    public Sprite sprite_apple;
    public Sprite sprite_banana;
    public Sprite sprite_kiwi;
    public Sprite sprite_pear;
    public Sprite sprite_stawberry;
    public Sprite sprite_nothing;

    Color emotion_color;

    // Use this for initialization
    void Start () {
        energy_text.text = "Energy:   50/100";
       
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SetBagImage(FruitManager.Fruit fruitName)
    {
        for(int i = 0; i <= 2; i++)
        {
            if (bag[i].GetComponent<Image>().sprite == sprite_nothing)
            {
                switch (fruitName)
                {
                    case FruitManager.Fruit._apple:
                        bag[i].GetComponent<Image>().sprite = sprite_apple;
                        break;
                    case FruitManager.Fruit._banana:
                        bag[i].GetComponent<Image>().sprite = sprite_banana;
                        break;
                    case FruitManager.Fruit._kiwi:
                        bag[i].GetComponent<Image>().sprite = sprite_kiwi;
                        break;
                    case FruitManager.Fruit._pear:
                        bag[i].GetComponent<Image>().sprite = sprite_pear;
                        break;
                    case FruitManager.Fruit._stawberry:
                        bag[i].GetComponent<Image>().sprite = sprite_stawberry;
                        break;
                }
                break;
            }
        }

    }

    public void ClearBagImage()
    {
        for(int i = 0; i <= 2; i++)
        {
            bag[i].GetComponent<Image>().sprite = sprite_nothing;
        }
    }

    public void SetBubbleImage(FruitManager.Fruit[] fruitNames)
    {
        if (fruitNames[0] == FruitManager.Fruit._anythng)
        {
            thinking_bubble.SetActive(true);
            for(int i=0;i<=2;i++)
                boss_bubble[i].SetActive(false);
            return;
        }
        for(int i = 0; i <= 2; i++)
        {
            switch (fruitNames[i])
            {
                case FruitManager.Fruit._apple:
                    boss_bubble[i].GetComponent<SpriteRenderer>().sprite = sprite_apple;
                    break;
                case FruitManager.Fruit._banana:
                    boss_bubble[i].GetComponent<SpriteRenderer>().sprite = sprite_banana;
                    break;
                case FruitManager.Fruit._kiwi:
                    boss_bubble[i].GetComponent<SpriteRenderer>().sprite = sprite_kiwi;
                    break;
                case FruitManager.Fruit._pear:
                    boss_bubble[i].GetComponent<SpriteRenderer>().sprite = sprite_pear;
                    break;
                case FruitManager.Fruit._stawberry:
                    boss_bubble[i].GetComponent<SpriteRenderer>().sprite = sprite_stawberry;
                    break;
            }
            boss_bubble[i].SetActive(true);
            thinking_bubble.SetActive(false);
        }
    }

    public void EnergyUI_update(int energy_value)
    {
        energy_text.text = "Energy:  " + energy_value.ToString()+"/100";
    }

    public void WinText_avtive()
    {
        win_text.gameObject.SetActive(true);
        Retry_btn.gameObject.SetActive(true);
    }

    public void LostText_active()
    {
        lose_text.gameObject.SetActive(true);
        Retry_btn.gameObject.SetActive(true);
    }

    public void SetHappy()
    {
        emotion_color = happyEmotion.GetComponent<SpriteRenderer>().color;
        StartCoroutine(Animation_fade(happyEmotion));
    }

    public void SetAngry()
    {
        emotion_color = angryEmotion.GetComponent<SpriteRenderer>().color;
        StartCoroutine(Animation_fade(angryEmotion));
    }

    IEnumerator Animation_fade(GameObject emotion)
    {
        for (float f = 1.3f; f >= 0; f -= 0.01f)
        {
            emotion_color.a = f;
            emotion.GetComponent<SpriteRenderer>().color = emotion_color;
            yield return null;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
