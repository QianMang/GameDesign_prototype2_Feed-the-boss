using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
	}

    void MovePlayer()
    {
        Vector3 player_Position = this.transform.position;
        player_Position.x=Mathf.RoundToInt(player_Position.x);
        player_Position.y=Mathf.RoundToInt(player_Position.y);
        player_Position.z=Mathf.RoundToInt(player_Position.z);
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            if (player_Position.x <= -1.9f)
            {
                this.transform.Translate(-1, -1, 0);
                GameObject.FindWithTag("MainCamera").GetComponent<SceneManager>().SetRotateFlag(SceneManager.RotateDirection.up);
            }
            else
                this.transform.Translate(-1, 0, 0);
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            if (player_Position.x >=1.9f)
            {
                this.transform.Translate(1, -1, 0);
                GameObject.FindWithTag("MainCamera").GetComponent<SceneManager>().SetRotateFlag(SceneManager.RotateDirection.down);
            }
            else
                this.transform.Translate(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            if (player_Position.z <= -1.9f)
            {
                this.transform.Translate(0, -1, -1);
                GameObject.FindWithTag("MainCamera").GetComponent<SceneManager>().SetRotateFlag(SceneManager.RotateDirection.left);
            }
            else
                this.transform.Translate(0, 0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            if (player_Position.z >= 1.9f)
            {
                this.transform.Translate(0, -1, 1);
                GameObject.FindWithTag("MainCamera").GetComponent<SceneManager>().SetRotateFlag(SceneManager.RotateDirection.right);
            }
            else
            {
                this.transform.Translate(0, 0, 1);
            }
        }

    }

   


}
