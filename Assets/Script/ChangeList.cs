using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.SceneManagement;

public class ChangeList : MonoBehaviour {

	private GameObject GOIcon0;
	private GameObject GOIcon1;
	private GameObject GOIcon2;
	private GameObject GamesName;
	private RectTransform RTIcom0;
	private RectTransform RTIcom1;
	private RectTransform RTIcom2;
	private Text GamesNameText;
	
	void Awake () {
		Time.fixedDeltaTime = 0.2f;
		Time.timeScale = 1f;
		GOIcon0 = GameObject.Find ("/Canvas/Icon (0)");
		GOIcon1 = GameObject.Find ("/Canvas/Icon (1)");
		GOIcon2 = GameObject.Find ("/Canvas/Icon (2)");
		RTIcom0 = GOIcon0.GetComponent <RectTransform> ();
		RTIcom1 = GOIcon1.GetComponent <RectTransform> ();
		RTIcom2 = GOIcon2.GetComponent <RectTransform> ();
		RTIcom0.SetSiblingIndex (6);
		RTIcom1.SetSiblingIndex (4);
		RTIcom2.SetSiblingIndex (5);
		GamesName = GameObject.Find ("/Canvas/Panel/Text");
		GamesNameText = GamesName.GetComponent <Text> ();
	}
	
	// Use this for initialization
	void Start ()
	{
		GamesNameText.text = "<b><size=30>俄罗斯方块</size></b>" + "\n\n" +
			"玩法:W旋转、A左移、D右移、S加速下落，每得1000分升一级，并且下落速度增加。ESC键暂停游戏。";
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void ChangeList0 (){
		if (RTIcom0.anchorMin.x < 0.1f) {
			RTIcom0.SetSiblingIndex (6);
			RTIcom0.localPosition = new Vector3 (RTIcom0.localPosition.x,RTIcom0.localPosition.y,0);
			RTIcom0.anchorMin = new Vector2 (0.15f,0.45f);
			RTIcom0.anchorMax = new Vector2 (0.35f,0.8f);
			RTIcom0.offsetMax = new Vector2 (0,0);
			RTIcom0.offsetMin = new Vector2 (0,0);
			RTIcom2.SetSiblingIndex (5);
			RTIcom2.localPosition = new Vector3 (RTIcom1.localPosition.x,RTIcom1.localPosition.y,55);
			RTIcom2.anchorMin = new Vector2 (0.03f,0.45f);
			RTIcom2.anchorMax = new Vector2 (0.23f,0.8f);
			RTIcom2.offsetMax = new Vector2 (0,0);
			RTIcom2.offsetMin = new Vector2 (0,0);
			RTIcom1.SetSiblingIndex (4);
			RTIcom1.localPosition = new Vector3 (RTIcom2.localPosition.x,RTIcom2.localPosition.y,70);
			RTIcom1.anchorMin = new Vector2 (0.22f,0.45f);
			RTIcom1.anchorMax = new Vector2 (0.42f,0.8f);
			RTIcom1.offsetMax = new Vector2 (0,0);
			RTIcom1.offsetMin = new Vector2 (0,0);
			GamesNameText.text = "<b><size=30>俄罗斯方块</size></b>" + "\n\n" +
				"玩法:W旋转、A左移、D右移、S加速下落，每得1000分升一级，并且下落速度增加。ESC键暂停游戏。";
		} else if (RTIcom0.anchorMin.x > 0.18f) {
			RTIcom0.SetSiblingIndex (6);
			RTIcom0.localPosition = new Vector3 (RTIcom0.localPosition.x,RTIcom0.localPosition.y,0);
			RTIcom0.anchorMin = new Vector2 (0.15f,0.45f);
			RTIcom0.anchorMax = new Vector2 (0.35f,0.8f);
			RTIcom0.offsetMax = new Vector2 (0,0);
			RTIcom0.offsetMin = new Vector2 (0,0);
			RTIcom1.SetSiblingIndex (4);
			RTIcom1.localPosition = new Vector3 (RTIcom1.localPosition.x,RTIcom1.localPosition.y,70);
			RTIcom1.anchorMin = new Vector2 (0.22f,0.45f);
			RTIcom1.anchorMax = new Vector2 (0.42f,0.8f);
			RTIcom1.offsetMax = new Vector2 (0,0);
			RTIcom1.offsetMin = new Vector2 (0,0);
			RTIcom2.SetSiblingIndex (5);
			RTIcom2.localPosition = new Vector3 (RTIcom2.localPosition.x,RTIcom2.localPosition.y,55);
			RTIcom2.anchorMin = new Vector2 (0.03f,0.45f);
			RTIcom2.anchorMax = new Vector2 (0.23f,0.8f);
			RTIcom2.offsetMax = new Vector2 (0,0);
			RTIcom2.offsetMin = new Vector2 (0,0);
			GamesNameText.text = "<b><size=30>俄罗斯方块</size></b>" + "\n\n" +
				"玩法:W旋转、A左移、D右移、S加速下落，每得1000分升一级，并且下落速度增加。ESC键暂停游戏。";
		}
	}
	
	public void ChangeList1 (){
		if (RTIcom1.anchorMin.x < 0.1f) {
			RTIcom1.SetSiblingIndex (6);
			RTIcom1.localPosition = new Vector3 (RTIcom1.localPosition.x,RTIcom1.localPosition.y,0);
			RTIcom1.anchorMin = new Vector2 (0.15f,0.45f);
			RTIcom1.anchorMax = new Vector2 (0.35f,0.8f);
			RTIcom1.offsetMax = new Vector2 (0,0);
			RTIcom1.offsetMin = new Vector2 (0,0);
			RTIcom0.SetSiblingIndex (5);
			RTIcom0.localPosition = new Vector3 (RTIcom0.localPosition.x,RTIcom0.localPosition.y,55);
			RTIcom0.anchorMin = new Vector2 (0.03f,0.45f);
			RTIcom0.anchorMax = new Vector2 (0.23f,0.8f);
			RTIcom0.offsetMax = new Vector2 (0,0);
			RTIcom0.offsetMin = new Vector2 (0,0);
			RTIcom2.SetSiblingIndex (4);
			RTIcom2.localPosition = new Vector3 (RTIcom2.localPosition.x,RTIcom2.localPosition.y,70);
			RTIcom2.anchorMin = new Vector2 (0.22f,0.45f);
			RTIcom2.anchorMax = new Vector2 (0.42f,0.8f);
			RTIcom2.offsetMax = new Vector2 (0,0);
			RTIcom2.offsetMin = new Vector2 (0,0);
			GamesNameText.text = "<b><size=30>飞机大战</size></b>" + "\n\n" +
				"玩法:按住鼠标左键控制飞机移动，点击鼠标右键使用炸弹，空格键暂停游戏。";
		} else if (RTIcom1.anchorMin.x > 0.18f) {
			RTIcom1.SetSiblingIndex (6);
			RTIcom1.localPosition = new Vector3 (RTIcom1.localPosition.x,RTIcom1.localPosition.y,0);
			RTIcom1.anchorMin = new Vector2 (0.15f,0.45f);
			RTIcom1.anchorMax = new Vector2 (0.35f,0.8f);
			RTIcom1.offsetMax = new Vector2 (0,0);
			RTIcom1.offsetMin = new Vector2 (0,0);
			RTIcom2.SetSiblingIndex (4);
			RTIcom2.localPosition = new Vector3 (RTIcom0.localPosition.x,RTIcom0.localPosition.y,70);
			RTIcom2.anchorMin = new Vector2 (0.22f,0.45f);
			RTIcom2.anchorMax = new Vector2 (0.42f,0.8f);
			RTIcom2.offsetMax = new Vector2 (0,0);
			RTIcom2.offsetMin = new Vector2 (0,0);
			RTIcom0.SetSiblingIndex (5);
			RTIcom0.localPosition = new Vector3 (RTIcom2.localPosition.x,RTIcom2.localPosition.y,55);
			RTIcom0.anchorMin = new Vector2 (0.03f,0.45f);
			RTIcom0.anchorMax = new Vector2 (0.23f,0.8f);
			RTIcom0.offsetMax = new Vector2 (0,0);
			RTIcom0.offsetMin = new Vector2 (0,0);
			GamesNameText.text = "<b><size=30>飞机大战</size></b>" + "\n\n" +
				"玩法:按住鼠标左键控制飞机移动，点击鼠标右键使用炸弹，空格键暂停游戏。";
		}
	}
	
	public void ChangeList2 (){
		if (RTIcom2.anchorMin.x < 0.1f) {
			RTIcom2.SetSiblingIndex (6);
			RTIcom2.localPosition = new Vector3 (RTIcom2.localPosition.x,RTIcom2.localPosition.y,0);
			RTIcom2.anchorMin = new Vector2 (0.15f,0.45f);
			RTIcom2.anchorMax = new Vector2 (0.35f,0.8f);
			RTIcom2.offsetMax = new Vector2 (0,0);
			RTIcom2.offsetMin = new Vector2 (0,0);
			RTIcom1.SetSiblingIndex (5);
			RTIcom1.localPosition = new Vector3 (RTIcom1.localPosition.x,RTIcom1.localPosition.y,55);
			RTIcom1.anchorMin = new Vector2 (0.03f,0.45f);
			RTIcom1.anchorMax = new Vector2 (0.23f,0.8f);
			RTIcom1.offsetMax = new Vector2 (0,0);
			RTIcom1.offsetMin = new Vector2 (0,0);
			RTIcom0.SetSiblingIndex (4);
			RTIcom0.localPosition = new Vector3 (RTIcom0.localPosition.x,RTIcom0.localPosition.y,70);
			RTIcom0.anchorMin = new Vector2 (0.22f,0.45f);
			RTIcom0.anchorMax = new Vector2 (0.42f,0.8f);
			RTIcom0.offsetMax = new Vector2 (0,0);
			RTIcom0.offsetMin = new Vector2 (0,0);
			GamesNameText.text = "<b><size=30>敬请期待</size></b>";
		} else if (RTIcom2.anchorMin.x > 0.18f) {
			RTIcom2.SetSiblingIndex (6);
			RTIcom2.localPosition = new Vector3 (RTIcom2.localPosition.x,RTIcom2.localPosition.y,0);
			RTIcom2.anchorMin = new Vector2 (0.15f,0.45f);
			RTIcom2.anchorMax = new Vector2 (0.35f,0.8f);
			RTIcom2.offsetMax = new Vector2 (0,0);
			RTIcom2.offsetMin = new Vector2 (0,0);
			RTIcom0.SetSiblingIndex (4);
			RTIcom0.localPosition = new Vector3 (RTIcom1.localPosition.x,RTIcom1.localPosition.y,70);
			RTIcom0.anchorMin = new Vector2 (0.22f,0.45f);
			RTIcom0.anchorMax = new Vector2 (0.42f,0.8f);
			RTIcom0.offsetMax = new Vector2 (0,0);
			RTIcom0.offsetMin = new Vector2 (0,0);
			RTIcom1.SetSiblingIndex (5);
			RTIcom1.localPosition = new Vector3 (RTIcom0.localPosition.x,RTIcom0.localPosition.y,55);
			RTIcom1.anchorMin = new Vector2 (0.03f,0.45f);
			RTIcom1.anchorMax = new Vector2 (0.23f,0.8f);
			RTIcom1.offsetMax = new Vector2 (0,0);
			RTIcom1.offsetMin = new Vector2 (0,0);
			GamesNameText.text = "<b><size=30>敬请期待</size></b>";
		}
	}

	public void GameStart(){
		if (6 == RTIcom0.GetSiblingIndex ()) {
			Application.LoadLevel ("Tetris");
			//SceneManager.LoadScene ("Tetris");
		} else if (6 == RTIcom1.GetSiblingIndex ()) {
			Application.LoadLevel ("PlaneWar");
			//SceneManager.LoadScene ("PlaneWar");
		} else if (6 == RTIcom2.GetSiblingIndex ()) {
			
		}
	}
}
