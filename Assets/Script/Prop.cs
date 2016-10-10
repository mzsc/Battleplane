using UnityEngine;
using System.Collections;

public class Prop : MonoBehaviour
{
	public string TriggerTag;//要碰撞的物体Tag
	private GameObject MyGameControl;//控制台物体
	private PlaneWarControl ScriptPlaneWarControl;//控制台物体上的PlaneWarControl脚本
	
	void Awake ()
	{
		//获取GameControl物体
		MyGameControl = GameObject.Find ("/GameControl");
		//获取GameControl物体上的PlaneWarControl脚本
		ScriptPlaneWarControl = MyGameControl.GetComponent<PlaneWarControl> ();
	}

	void Update ()
	{
		//如果非结束非暂停
		if (!ScriptPlaneWarControl.BoolPause) {
			//弹药以指定速度下落
			transform.Translate (Vector3.down * Time.deltaTime * 10f, Space.World);
			//超过下边界则销毁
			if (transform.position.y < -85f) {
				Destroy (gameObject);//销毁自身
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//如果碰撞到的物体Tag为战机的Tag
		if (other.gameObject.tag == TriggerTag) {
			Destroy (this.gameObject);//销毁自身
		}
	}
}
