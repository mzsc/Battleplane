using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Back : MonoBehaviour
{
	//背景数组0：无方块1：有方块
	public byte[,] Backs = {
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
	};
	public GameObject[] RussiaCubes;//储存6种方快的数组
	public int Integral = 0;//储存分数的变量
	public bool Pause = false;//暂停
	public bool GameOver = false;//游戏结束
	private const int Wide = 11;//背景数组的宽度
	private const int High = 24;//背景数组的高度
	private GameObject RussiaCube;//正在下落的方块
	private GameObject RussiaCubeNext;//下一个下落的方块
	private GameObject Panel;//UGUI组件Panel
	private GameObject mText;//UGUI组件Text
	private Text stateText;//UGUI将要显示的文本
	private UIControl UIScript;//UGUI组件上的UIControl脚本

	void Awake ()
	{
		Time.fixedDeltaTime = 1f;//设置FixedUpdate的更新间隔为1S
		Time.timeScale = 1f;//时间缩放为1
		GameOver = false;//游戏结束为假
		Panel = GameObject.Find ("/Canvas/Panel");//获取游戏对象Panel
		UIScript = Panel.GetComponent<UIControl> ();//获取Panel上的UIControl脚本组件
		mText = GameObject.Find ("/Canvas/Panel/Text");//获取游戏对象Text
		stateText = mText.GetComponent <Text> ();//获取Text上的Text组件
	}

	void Start ()
	{
		int i = Random.Range (0, 6);//返回随机数0~5
		//克隆一个方块放到下一个的位置
		RussiaCubeNext = Instantiate (RussiaCubes [i], new Vector3 (-9, 11, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		AddCube ();//调用增加方块函数
	}

	void Update ()
	{
		//判断游戏是否结束
		if (GameOver) {
			UIScript.Mode = 1;//UGUI模式1，下落
			stateText.text = "大 侠 已 跪";//赋予文本
		} else {
			//捕捉ESC键按下
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Pause = !Pause;//暂停与继续转变
				//判断是否暂停
				if (Pause) {
					Time.timeScale = 1;//时间缩放为1
					UIScript.Mode = 1;//UGUI模式1，下落
					stateText.text = "休 息 一 下";//赋予文本
				} else {
					UIScript.Mode = 2;//UGUI模式2，上升
					stateText.text = "";//赋予文本
					Time.timeScale = Integral / 1000 + 1;//时间缩放恢复
				}
			}
		}
	}

	void OnGUI ()
	{
		//分数GUI，大小以场景宽高计算
		GUI.Box (new Rect (Screen.width / 16f * 2f, Screen.height / 9f, Screen.width / 16f * 3f, Screen.height / 9f / 2f), "分数：" + Integral);
		//下一个GUI，大小以场景宽高计算
		GUI.Box (new Rect (Screen.width / 16f * 2f, Screen.height / 9f * 2.5f, Screen.width / 16f * 3f, Screen.height / 9f / 2f), "下一个");
	}

	//生成新方块函数
	public void AddCube ()
	{
		//判断游戏是否结束
		if (!GameOver) {
			RussiaCube = RussiaCubeNext;//预备方块赋给下落方块
			RussiaCube.transform.position = new Vector3 (5, High - 3, 0);//移动方块到下落初始位置
			Cube CubeScript = RussiaCube.GetComponent<Cube> ();//获得方块上的Cube脚本组件
			CubeScript.enabled = true;//激活Cube脚本
			int i = Random.Range (0, 6);//返回随机数0~5
			int j = Random.Range (1, 3);//返回随机数1~2
			Quaternion mRotation = new Quaternion (0f, 0f, 0f, 0f);//新建方块旋转角度
			//根据j的值改变预备方块的旋转角度
			switch (j) {
			case 1:
				mRotation = Quaternion.Euler (0f, 0f, 90f);//90度
				break;
			case 2:
				mRotation = Quaternion.Euler (0f, 0f, 180f);//180度
				break;
			case 3:
				mRotation = Quaternion.Euler (0f, 0f, 270f);//270度
				break;
			default:
				break;
			}
			//根据i克隆新的预备方快
			RussiaCubeNext = Instantiate (RussiaCubes [i], new Vector3 (-9, 11, 0), mRotation) as GameObject;
		}
	}

	//检查背景数组函数，每一行是否已满
	public void CheckBacks ()
	{
		int x = 0;//纵坐标
		int y = 0;//横坐标
		int[] DeleteX = new int[5];//用来储存要删除的行，一次最多删除4行
		int DeleteLength = 0;//删除的行数

		//从下至上检查每一行
		for (x = High - 1; x > 0; x--) {
			//从左至右检查每一列，背景坐标不为1则跳出
			for (y = 1; (y < Wide) && (Backs [x, y] == 1); y++) {

			}
			//如果以上循环结束后y等于宽度，说明这一行已满
			if (y == Wide) {
				DeleteX [DeleteLength] = x;//记录已满的那行纵坐标
				DeleteLength++;//删除行数加1
			}
		}
		//如果删除行数大于0，则调用删除函数
		if (DeleteLength > 0) {
			DeleteLine (DeleteX, DeleteLength);
		}
		//检查是否溢出，如溢出则游戏结束
		for (y = 1; y < Wide; y++) {
			if (Backs [2, y] == 1) {
				GameOver = true;
			}
		}
	}

	//删除行函数，入参为要删除的行的数组与要删除的行数
	public void DeleteLine (int[] DeleteX, int DeleteLength)
	{
		Integral += 100 * DeleteLength;//分数增加
		Time.timeScale = Integral / 1000 + 1;//改变时间缩放，得分越高下落越快

		//遍历删除行，从上至下删除
		for (int x = DeleteLength - 1; x >= 0; x--) {
			//遍历删除行的每个方块
			for (int y = 1; y < Wide; y++) {
				//按名字查找方块，方块以坐标命名
				GameObject DeleteCube = GameObject.Find ("Cube" + DeleteX [x].ToString () + y.ToString ());
				//不为空则删除方块
				if (DeleteCube != null) {
					DestroyImmediate (DeleteCube);//永久删除方块
				}
				//遍历删除方块之上的方块，用以下落
				for (int UpX = DeleteX [x] - 1; UpX > 0; UpX--) {
					int DownX = UpX + 1;//下落之后的纵坐标
					//获取上一个方块
					GameObject DropCube = GameObject.Find ("Cube" + UpX.ToString () + y.ToString ());
					//判断是否为空
					if (DropCube != null) {
						//物理上下落一个单位
						DropCube.transform.position = new Vector3 (DropCube.transform.position.x, DropCube.transform.position.y - 1f, DropCube.transform.position.z);
						//以下落后的坐标重命名
						DropCube.name = "Cube" + DownX.ToString () + y.ToString ();		
					}
					Backs [DownX, y] = Backs [UpX, y];//将上面的坐标值赋给下面的坐标
				}
				Backs [1, y] = 0;//最上面的坐标值赋为0
			}
		}
	}
}






