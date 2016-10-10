using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaneWarControl : MonoBehaviour
{
	public GameObject[] Enemy;//敌机种类数组
	public GameObject[] Prop;//弹药种类数组
	public bool BoolGameOver = false;//游戏结束变量
	public bool BoolPause = false;//游戏暂停变量

	private GameObject MyBomNumber;//UGUI弹药数显示
	private GameObject MyScore;//UGUI分数显示
	private GameObject MyQuit;//UGUI退出按钮
	private GameObject MyRestart;//UGUI重新开始按钮
	private Text BomNumberText;//UGUI弹药数显示文言
	private Text ScoreText;//UGUI分数显示文言
	private int IntBomNumber = 0;//弹药数
	private int IntScore = 0;//分数
	
	void Awake ()
	{
		Time.fixedDeltaTime = 0.2f;//设置FixedUpdate的更新间隔为1S
		Time.timeScale = 1f;//时间缩放为1
		//获取显示弹药数量的物体
		MyBomNumber = GameObject.Find ("/Canvas/BombNumber/Text");
		//获取显示弹药数量的Text组件
		BomNumberText = MyBomNumber.GetComponent <Text> ();
		//初始化显示数量为0
		BomNumberText.text = "x" + IntBomNumber.ToString ();
		//获取显示分数的物体
		MyScore = GameObject.Find ("/Canvas/Score/Text");
		//获取显示分数的Text组件
		ScoreText = MyScore.GetComponent <Text> ();
		//初始化显示分数为0
		ScoreText.text = IntScore.ToString ();
		//获取退出按钮
		MyQuit = GameObject.Find ("/Canvas/Quit");
		MyQuit.SetActive (false);//隐藏退出按钮 
		//获取重新开始按钮
		MyRestart = GameObject.Find ("/Canvas/Restart");
		MyRestart.SetActive (false);//隐藏重新开始按钮
		BoolGameOver = false;//游戏结束为假
		BoolPause = false;//游戏暂停为假
	}

	// Use this for initialization
	void Start ()
	{
		//每隔3S运行一次InstantiateEnemy0()函数
		InvokeRepeating ("InstantiateEnemy0", 2f, 3f);
		//每隔8S运行一次InstantiateEnemy1()函数
		InvokeRepeating ("InstantiateEnemy1", 3f, 8f);
		//每隔15S运行一次InstantiateEnemy2()函数
		InvokeRepeating ("InstantiateEnemy2", 4f, 15f);
		//每隔10S运行一次InstantiateProp()函数
		InvokeRepeating ("InstantiateProp", 5f, 10f);
	}

	void Update ()
	{
		//如果游戏结束，否则判断是否按下空格键
		if (BoolGameOver) {
			MyQuit.SetActive (true);//显示退出按钮 
			MyRestart.SetActive (true);//显示重新开始按钮
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			BoolPause = !BoolPause;//暂停、开始互换
		}
	}

	//敌机0生成函数
	void InstantiateEnemy0 ()
	{
		//如果非结束非暂停
		if ((!BoolGameOver) && (!BoolPause)) {
			float x = Random.Range (5f, 65f);//随机在5~65返回横坐标
			//克隆敌机0在指定位置
			Instantiate (Enemy [0], new Vector3 (x, 80, 90), new Quaternion (0, 0, 0, 0));
		}
	}

	//敌机1生成函数
	void InstantiateEnemy1 ()
	{
		//如果非结束非暂停
		if ((!BoolGameOver) && (!BoolPause)) {
			float x = Random.Range (5f, 65f);//随机在5~65返回横坐标
			//克隆敌机1在指定位置
			Instantiate (Enemy [1], new Vector3 (x, 100, 90), new Quaternion (0, 0, 0, 0));
		}
	}

	//敌机2生成函数
	void InstantiateEnemy2 ()
	{
		//如果非结束非暂停
		if ((!BoolGameOver) && (!BoolPause)) {
			float x = Random.Range (15f, 55f);//随机在15~55返回横坐标
			//克隆敌机2在指定位置
			Instantiate (Enemy [2], new Vector3 (x, 140, 90), new Quaternion (0, 0, 0, 0));
		}
	}

	//弹药生成函数
	void InstantiateProp ()
	{
		//如果非结束非暂停
		if ((!BoolGameOver) && (!BoolPause)) {
			float x = Random.Range (5f, 65f);//随机在5~65返回横坐标
			int i = Random.Range (0, 100);//随机返回0~100的数
			//如果i大于50则生成弹药1，否则弹药0
			if (i > 50) {
				i = 1;
			} else {
				i = 0;
			}
			//克隆弹药在指定位置
			Instantiate (Prop [i], new Vector3 (x, 180, 90), new Quaternion (0, 0, 0, 0));
		}
	}

	//弹药数量显示函数
	void ChangeBomNumber (int Num)
	{
		IntBomNumber += Num;//弹药数量加Num
		BomNumberText.text = "x" + IntBomNumber.ToString ();//更新显示的弹药数
	}

	//分数显示函数
	void ChangeScore (int Num)
	{
		IntScore += Num;//分数加Num
		ScoreText.text = IntScore.ToString ();//更新显示的分数
	}
}
