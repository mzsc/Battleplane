using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public Sprite[] mEnemy;//储存敌机每帧的Sprite图片
	public int Lives = 10;//生命值
	public string TriggerTag;//储存子弹的Tag
	public float Velocity;//移动速度

	private int Mode = 0;//显示模式，要播放哪一张Sprite
	private bool Flag = true;//控制被击中时的动画
	private SpriteRenderer mSprite;//要表示的Sprite图片
	private GameObject MyGameControl;//控制台物体
	private PlaneWarControl ScriptPlaneWarControl;//控制台物体上的PlaneWarControl脚本

	void Awake ()
	{
		//获取GameControl物体
		MyGameControl = GameObject.Find ("/GameControl");
		//获取GameControl物体上的PlaneWarControl脚本
		ScriptPlaneWarControl = MyGameControl.GetComponent<PlaneWarControl> ();
	}

	void Start ()
	{
		//获取自身SpriteRenderer组件
		mSprite = gameObject.GetComponent <SpriteRenderer> ();
		mSprite.sprite = mEnemy [0];//显示角标为0的Sprite图片
	}

	void Update ()
	{
		//如果非暂停
		if (!ScriptPlaneWarControl.BoolPause) {
			//以指定速度向下移动
			transform.Translate (Vector3.down * Time.deltaTime * Velocity, Space.World);
			//如果超过下边界
			if (transform.position.y < -85f) {
				Destroy (gameObject);//销毁自身
			}
		}
	}

	void FixedUpdate ()
	{
		//显示模式判断
		if (Mode == 0) {
			mSprite.sprite = mEnemy [0];//显示编号0的Sprite图片
		} else if (Mode == 1) {
			//交替显示编号0和1的Sprite图片，被击中时的动画
			if (Flag) {
				mSprite.sprite = mEnemy [1];
			} else {
				mSprite.sprite = mEnemy [0];
			}
			Flag = !Flag;
			Mode = 0;//回到模式0
		} else if (Mode >= 2) {
			//如果显示模式大于Sprite数组长度
			if (Mode >= mEnemy.GetLength (0)) {
				//判断为哪种敌机
				switch (transform.name) {
				case "Enemy0(Clone)":
					//若为Enemy0(Clone)，则发消息给控制台加100分
					MyGameControl.SendMessage ("ChangeScore", 100);
					break;
				case "Enemy1(Clone)":
					//若为Enemy1(Clone)，则发消息给控制台加200分
					MyGameControl.SendMessage ("ChangeScore", 200);
					break;
				case "Enemy2(Clone)":
					//若为Enemy2(Clone)，则发消息给控制台加400分
					MyGameControl.SendMessage ("ChangeScore", 400);
					break;
				default :
					break;
				}
				DestroyImmediate (gameObject);//销毁自身
			} else {
				mSprite.sprite = mEnemy [Mode];//显示编号为Mode的Sprite图片
			}
			Mode++;//模式自加
		}
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//如果碰撞到子弹
		if (other.gameObject.tag == TriggerTag) {
			Lives--;//生命减1
			//如果生命大于0
			if (Lives > 0) {
				Mode = 1;//动画模式1
			} else if (Lives == 0) {
				Mode = 2;//动画模式2
			}
		}
	}

	//战机使用炸弹时的敌机自毁程序，入参为进入的动画模式，一般为2
	void ClearMe (int i)
	{
		Mode = i;//动画模式i，i一般为2
	}
}
