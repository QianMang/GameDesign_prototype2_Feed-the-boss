using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager : MonoBehaviour {
    
    public GameObject GameScene;
    public GameObject player;
    public GameObject speak_bubble;
    public GameObject boss;
    public GameObject food;

   bool rotateFlag = false;
  

    public enum RotateDirection { left,right,up,down};   

    float timeCount=0;    //[0-1]
    public float rotateSpeed;

    Vector3 bossToBubble;

    Quaternion bubbleQua;
    Quaternion from;
    Quaternion to;
   
    //float time
    // Use this for initialization
    void Start () {
        bubbleQua = speak_bubble.transform.rotation;
        bossToBubble = speak_bubble.transform.position - boss.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotateFlag)
        {
            RotateScene();
        }
	}


    public void RotateScene(){
        GameScene.transform.rotation = Quaternion.Slerp(from, to, timeCount);
       // player.transform.rotation = Quaternion.Slerp(from_player, to_player, timeCount);
        if (timeCount >= 1)
        {
            player.transform.rotation = Quaternion.identity;
            speak_bubble.transform.rotation = bubbleQua;
            speak_bubble.transform.position = boss.transform.position + bossToBubble;
            
            if(speak_bubble.transform.position.y==speak_bubble.transform.localPosition.y)
                speak_bubble.SetActive(true);
            else
                speak_bubble.SetActive(false);
            rotateFlag = false;
        }
        timeCount = timeCount + rotateSpeed;
        
    }

    public void SetRotateFlag(RotateDirection direction)
    {
        timeCount = 0;
        rotateFlag = true;
        from = GameScene.transform.rotation;
        if(direction==RotateDirection.right)
             to = Quaternion.AngleAxis(-90, Vector3.right) * from;
        else if (direction == RotateDirection.left)
            to = Quaternion.AngleAxis(90, Vector3.right) * from;
        else if(direction == RotateDirection.up)
            to = Quaternion.AngleAxis(-90, Vector3.forward) * from;
        else if (direction == RotateDirection.down)
            to = Quaternion.AngleAxis(90, Vector3.forward) * from;
        



    }

    public bool IsRotated()
    {
        return rotateFlag;
    }
}
