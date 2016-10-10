using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hero : MonoBehaviour
{
	public Sprite[] mHero;//储存战机Sprite图片的数组
	public GameObject[] mBullet;//储存子弹种类的数组
	public string PropTag1;//弹药1的tag
	public string PropTag2;//弹药2的tag
	public string EnemyTag;//敌机的tag

	private int BulletNumber = 99;//弹药1的数量
	private int CannonballNumber = 0;//弹药2的数量
	private int IntHeroMode = 0;//动画模式
	private SpriteRenderer mSprite;//要显示的Sprite图片
	private Vector3 mPos;//鼠标位置
	private float HorizontalPos;//战机位置横向
	private float VerticalPos;//战机位置纵向
	private GameObject[] Enemys;//用来储存敌机的数组
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
		//每隔0.15S运行一次InstantiateBullet()函数
		InvokeRepeating ("InstantiateBullet", 0f, 0.15f);
	}

	void Update ()
	{
		//如果非结束非暂停
		if ((!ScriptPlaneWarControl.BoolGameOver) && (!ScriptPlaneWarControl.BoolPause)) {
			//按住鼠标左键
			if (Input.GetMouseButton (0)) {
				mPos = Input.mousePosition;//获取鼠标位置
				//控制鼠标位置在屏幕宽度0.5~0.78范围内
				if (mPos.x < Screen.width * 0.5f) {
					mPos.x = Screen.width * 0.5f;
				} else if (mPos.x > Screen.width * 0.78f) {
					mPos.x = Screen.width * 0.78f;
				}
				//计算出战机横坐标
				HorizontalPos = 70f * ((mPos.x - Screen.width * 0.5f) / (Screen.width * 0.28f));
				//计算出战机纵坐标
				VerticalPos = 68f * ((mPos.y - Screen.height * 0.5f) / (Screen.height * 0.5f));
				//赋予战机位置
				transform.position = new Vector3 (HorizontalPos, VerticalPos, transform.position.z);
			}
			//按下鼠标右键
			if (Input.GetMouseButtonDown (1)) {
				//如果弹药2的数量大于0
				if (CannonballNumber > 0) {
					CannonballNumber--;//弹药2数量减1
					MyGameControl.SendMessage ("ChangeBomNumber", -1);//发消息给控制台使显示数减1
					ClearEnemys ();//调用清除敌机函数
				}
			}
		}
	}

	void FixedUpdate ()
	{
		//判断动画模式；0,1切换为飞行效果；2为被击毁效果
		if (IntHeroMode == 0) {
			mSprite.sprite = mHero [0];//显示sprite[0]
			IntHeroMode = 1;//动画模式1
		} else if (IntHeroMode == 1) {
			mSprite.sprite = mHero [1];//显示sprite[1]
			IntHeroMode = 0;//动画模式0
		} else if (IntHeroMode >= 2) {
			//如果显示模式大于Sprite数组长度
			if (IntHeroMode >= mHero.GetLength (0)) {
				ScriptPlaneWarControl.BoolGameOver = true;//游戏结束为真
				DestroyImmediate (this.gameObject);//销毁自身
			} else {
				mSprite.sprite = mHero [IntHeroMode];//显示编号为IntHeroMode的Sprite图片
				IntHeroMode++;//自加
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//判断碰撞的物体，依次为弹药1、弹药2、敌机
		if (other.gameObject.tag == PropTag1) {
			BulletNumber = 99;//弹药1数量变为99
			CancelInvoke ();//结束所有InvokeRepeating()
			//每隔0.15S运行一次InstantiateBulletAdd()函数
			InvokeRepeating ("InstantiateBulletAdd", 0f, 0.15f);
		} else if (other.gameObject.tag == PropTag2) {
			CannonballNumber++;//弹药2加1
			MyGameControl.SendMessage ("ChangeBomNumber", 1);//发消息给控制台使显示数加1
		} else if (other.gameObject.tag == EnemyTag) {
			IntHeroMode = 2;//进入显示模式2
		}
	}

	//默认子弹发射函数
	void InstantiateBullet ()
	{
		//如果非结束非暂停
		if ((!ScriptPlaneWarControl.BoolGameOver) && (!ScriptPlaneWarControl.BoolPause)) {
			//在战机前面克隆子弹
			Instantiate (mBullet [0], new Vector3 (transform.position.x, transform.position.y + 10f, 90f), 
				new Quaternion (0, 0, 0, 0));
		}
	}

	//弹药1发射函数
	void InstantiateBulletAdd ()
	{
		//如果非结束非暂停
		if ((!ScriptPlaneWarControl.BoolGameOver) && (!ScriptPlaneWarControl.BoolPause)) {
			//在战机两侧克隆弹药1
			Instantiate (mBullet [1], new Vector3 (transform.position.x - 4f, transform.position.y + 10f, 90f), 
				new Quaternion (0, 0, 0, 0));
			Instantiate (mBullet [1], new Vector3 (transform.position.x + 4f, transform.position.y + 10f, 90f), 
				new Quaternion (0, 0, 0, 0));
			BulletNumber--;//弹药1数量减1
			//如果弹药1数量不足
			if (BulletNumber <= 0) {
				CancelInvoke ();//结束所有InvokeRepeating()
				//每隔0.15S运行一次InstantiateBullet()函数
				InvokeRepeating ("InstantiateBullet", 0f, 0.15f);
			}
		}
	}

	//清除敌机函数，销毁屏幕上的所有敌机
	void ClearEnemys ()
	{
		Enemys = GameObject.FindGameObjectsWithTag ("Enemy");//获得所有敌机
		//遍历所有敌机
		foreach (GameObject MyEnemy in Enemys) {
			//如果位置小于70，也就是在屏幕以内
			if (MyEnemy.transform.position.y < 70) {
				MyEnemy.SendMessage ("ClearMe", 2);//发消息给敌机的自毁函数
			}
		}
	}
}
