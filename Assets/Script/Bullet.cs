using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	public string TriggerTag;//储存碰撞体Tag
	private float mhight = 70f;//上边界
	private GameObject MyGameControl;//控制台物体
	private PlaneWarControl ScriptPlaneWarControl;//控制台物体的PlaneWarControl脚本
	
	void Awake ()
	{
		//获取控制台物体
		MyGameControl = GameObject.Find ("/GameControl");
		//获取控制台物体的PlaneWarControl脚本
		ScriptPlaneWarControl = MyGameControl.GetComponent<PlaneWarControl> ();
	}

	void Update ()
	{
		//如果游戏非暂停
		if (!ScriptPlaneWarControl.BoolPause) {
			//如果子弹超过边界则销毁
			if (transform.position.y > mhight) {
				Destroy (this.gameObject);//销毁子弹
			}
			//子弹以指定速度向上移动
			transform.Translate (Vector3.up * Time.deltaTime * 80f, Space.World);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//如果碰撞物体的Tag为TriggerTag储存的名字
		if (other.gameObject.tag == TriggerTag) {
			Destroy (this.gameObject);//销毁子弹
		}
	}
}
