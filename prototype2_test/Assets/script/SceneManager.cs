using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    public GameObject GameScene;
    public GameObject player;
    bool rotateFlag = false;

    public enum RotateDirection { left,right,up,down};

    float timeCount=0;    //[0-1]
    public float rotateSpeed;

    Quaternion from;
    Quaternion to;
    Quaternion from_player;
    Quaternion to_player;
    //float time
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (rotateFlag)
        {
            //print(rotateFlag);
            RotateScene();
        }
        
	}


    public void RotateScene(){
        GameScene.transform.rotation = Quaternion.Slerp(from, to, timeCount);
       // player.transform.rotation = Quaternion.Slerp(from_player, to_player, timeCount);
        if (timeCount >= 1)
        {
            player.transform.rotation = Quaternion.identity;
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
        // from_player = player.transform.rotation;



    }
}
