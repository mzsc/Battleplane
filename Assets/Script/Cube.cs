using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	public GameObject MyCube;//组成俄罗斯方块的单个方块
	public string[] MyCubes;//决定俄罗斯方块形状的数组
	private GameObject Console;//场景中Console物体，控制台作用
	private Back BackScript;//存储Back脚本
	private static float cWide = 0.5f;//物理横坐标与背景数组y坐标转换差值
	private static float cHigh = 23.5f;//物理纵坐标与背景数组x坐标转换差值

	void Awake ()
	{
		Console = GameObject.Find ("Console");//获取场景中Console物体
		BackScript = Console.GetComponent<Back> ();//获取Console上的Back脚本

		//判断当前物体是否有子物体
		if (transform.childCount == 0) {
			//遍历数组每一行
			for (int i = 0; i < MyCubes.Length; i++) {
				//遍历每一行的每一个元素
				for (int j = 0; j < MyCubes [i].Length; j++) {
					//判断这个元素是否为‘1’
					if (MyCubes [i] [j] == '1') {
						//数组角标转换为小方块的位置坐标
						Vector3 CubePoint = transform.TransformPoint (j - 1.5f, 0.5f - i, 0);
						//克隆小方块到指定位置
						GameObject RussiaCube = Instantiate (MyCube, CubePoint, new Quaternion (0, 0, 0, 0)) as GameObject;
						//将克隆体的父物体设定为当前物体
						RussiaCube.transform.parent = transform;
					}
				}
			}
			Cube CubeScript = gameObject.GetComponent<Cube> ();//获取当前物体上的Cube脚本
			CubeScript.enabled = false;//禁用该脚本
		}
	}

	void Update ()
	{
		//游戏非暂停并且游戏非结束
		if ((!BackScript.Pause) && (!BackScript.GameOver)) {
			//按下W键并且Rotation ()返回真，则旋转
			if (Input.GetKeyDown (KeyCode.W) && Rotation ()) {
				//旋转90度
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 90f);
			}
			//按下A键并且MovingLeft ()返回真，则左移
			if (Input.GetKeyDown (KeyCode.A) && MovingLeft ()) {
				//左移一个单位
				transform.position = new Vector3 (transform.position.x - 1f, transform.position.y, transform.position.z);
			}
			//按下D键并且MovingRight ()返回真，则右移
			if (Input.GetKeyDown (KeyCode.D) && MovingRight ()) {
				//右移一个单位
				transform.position = new Vector3 (transform.position.x + 1f, transform.position.y, transform.position.z);
			}
			//按住S键
			if (Input.GetKey (KeyCode.S)) {
				Time.timeScale = 10f;//时间快10倍
			}
			//松开S键
			if (Input.GetKeyUp (KeyCode.S)) {
				Time.timeScale = BackScript.Integral / 1000 + 1;//时间缩放恢复
			}
		}
	}

	void FixedUpdate ()
	{
		//游戏非暂停并且游戏非结束
		if ((!BackScript.Pause) && (!BackScript.GameOver)) {
			//MovingDown ()返回真，可以下落
			if (MovingDown ()) {
				//下落一个单位
				transform.position = new Vector3 (transform.position.x, transform.position.y - 1f, transform.position.z);
			} else {
				//遍历当前物体的子物体
				foreach (Transform Child in transform) {
					int BackX = Mathf.RoundToInt (cHigh - Child.position.y);//将物理纵坐标转换为背景数组X坐标
					int BackY = Mathf.RoundToInt (cWide + Child.position.x);//将物理横坐标转换为背景数组Y坐标
					BackScript.Backs [BackX, BackY] = 1;//将相应位置的背景数组赋1
					Child.name = "Cube" + BackX.ToString () + BackY.ToString ();//以背景数组角标重命名该小方块
				}
				transform.DetachChildren ();//与子物体分离
				BackScript.CheckBacks ();//调用背景检查函数
				BackScript.AddCube ();//调用增加方块函数
				DestroyImmediate (gameObject);//销毁自己
			}
		}
	}

	//旋转判断函数，返回真则可以旋转
	bool Rotation ()
	{
		//遍历当前物体的子物体，如果旋转之后背景数组的相应位置都不为1，则返回真
		foreach (Transform Child in transform) {
			//计算出该子方块绕其父物体中心点旋转90度之后的物理横坐标
			float RotateX = Child.position.y - transform.position.y + transform.position.x;
			//计算出该子方块绕其父物体中心点旋转90度之后的物理纵坐标
			float RotateY = transform.position.x - Child.position.x + transform.position.y;
			int BackX = Mathf.RoundToInt (cHigh - RotateY);//将物理纵坐标转换为背景数组X坐标
			int BackY = Mathf.RoundToInt (cWide + RotateX);//将物理横坐标转换为背景数组Y坐标
			//如果旋转之后背景数组的相应位置为1，则返回假
			if (BackScript.Backs [BackX, BackY] == 1) {
				return false;
			}
		}
		return true;
	}

	//左移判断函数，返回真则可以左移
	bool MovingLeft ()
	{
		//遍历当前物体的子物体，如果左移之后背景数组的相应位置都不为1，则返回真
		foreach (Transform Child in transform) {
			int BackX = Mathf.RoundToInt (cHigh - Child.position.y);//将物理纵坐标转换为背景数组X坐标
			int BackY = Mathf.RoundToInt (cWide + Child.position.x);//将物理横坐标转换为背景数组Y坐标
			//如果左移之后背景数组的相应位置为1，则返回假
			if (BackScript.Backs [BackX, BackY - 1] == 1) {
				return false;
			}
		}
		return true;
	}
	//右移判断函数，返回真则可以右移
	bool MovingRight ()
	{
		//遍历当前物体的子物体，如果右移之后背景数组的相应位置都不为1，则返回真
		foreach (Transform Child in transform) {
			int BackX = Mathf.RoundToInt (cHigh - Child.position.y);//将物理纵坐标转换为背景数组X坐标
			int BackY = Mathf.RoundToInt (cWide + Child.position.x);//将物理横坐标转换为背景数组Y坐标
			//如果右移之后背景数组的相应位置为1，则返回假
			if (BackScript.Backs [BackX, BackY + 1] == 1) {
				return false;
			}
		}
		return true;
	}

	//下落判断函数，返回真则可以下落
	bool MovingDown ()
	{
		//遍历当前物体的子物体，如果下落之后背景数组的相应位置都不为1，则返回真
		foreach (Transform Child in transform) {
			int BackX = Mathf.RoundToInt (cHigh - Child.position.y);//将物理纵坐标转换为背景数组X坐标
			int BackY = Mathf.RoundToInt (cWide + Child.position.x);//将物理横坐标转换为背景数组Y坐标
			//如果下落之后背景数组的相应位置为1，则返回假
			if (BackScript.Backs [BackX + 1, BackY] == 1) {
				return false;
			}
		}
		return true;
	}
}













