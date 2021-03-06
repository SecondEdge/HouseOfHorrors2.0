using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		if (GlobalControl.Instance.TransitionTarget != null)
			gameObject.transform.position = GlobalControl.Instance.TransitionTarget.position;

		if (GlobalControl.Instance.IsSceneBeingLoaded)
		{
			PlayerState.Instance.localPlayerData = GlobalControl.Instance.LocalCopyOfData;

			transform.position = new Vector3(
				GlobalControl.Instance.LocalCopyOfData.PositionX,
				GlobalControl.Instance.LocalCopyOfData.PositionY,
				GlobalControl.Instance.LocalCopyOfData.PositionZ + 0.1f);

			GlobalControl.Instance.IsSceneBeingLoaded = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.F5))
		{
			PlayerState.Instance.localPlayerData.SceneID = Application.loadedLevel;
			PlayerState.Instance.localPlayerData.PositionX = transform.position.x;
			PlayerState.Instance.localPlayerData.PositionY = transform.position.y;
			PlayerState.Instance.localPlayerData.PositionZ = transform.position.z;

			GlobalControl.Instance.SaveData();
		}

		if (Input.GetKey(KeyCode.F9))
		{
			GlobalControl.Instance.LoadData();
			GlobalControl.Instance.IsSceneBeingLoaded = true;

			int whichScene = GlobalControl.Instance.LocalCopyOfData.SceneID;

			Application.LoadLevel(whichScene);
		}
	}
}

