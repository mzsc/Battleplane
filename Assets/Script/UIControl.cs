using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour
{
	public byte Mode = 0;//窗口模式0：计时1：下落2：上升
	float mPos;//移动变量
	float gameTime;//游戏时间
	RectTransform mRect;//位置组件

	void Start ()
	{
		mRect = GetComponent <RectTransform> ();//获取位置组件
		mRect.offsetMax = new Vector2 (mRect.offsetMax.x, 720f);//设置初始位置
		mRect.offsetMin = new Vector2 (mRect.offsetMin.x, 720f);//设置初始位置
		mPos = mRect.offsetMax.y;//获取初始位置的值
	}

	void Update ()
	{
		//判断模式
		if (Mode == 0) {
			gameTime = Time.realtimeSinceStartup;//记录游戏开始到现在的时间
		} else if (Mode == 1) {
			//根据时间渐变位置，慢快慢
			mPos = Mathf.Lerp (mPos, 0f, (Time.realtimeSinceStartup - gameTime) / 5f);
			//如果位置小于10
			if (mPos < 10f) {
				mPos = 0f;//位置变为0
				Mode = 0;//回到模式0
			}
			mRect.offsetMax = new Vector2 (mRect.offsetMax.x, mPos);//将新位置赋值给下落窗口
			mRect.offsetMin = new Vector2 (mRect.offsetMin.x, mPos);//将新位置赋值给下落窗口
		} else if (Mode == 2) {
			//根据时间渐变位置，慢快慢
			mPos = Mathf.Lerp (mPos, 720f, (Time.realtimeSinceStartup - gameTime) / 5f);
			//如果位置大于710
			if (mPos > 710f) {
				mPos = 720f;//位置变为720
				Mode = 0;//回到模式0
			}
			mRect.offsetMax = new Vector2 (mRect.offsetMax.x, mPos);//将新位置赋值给上升窗口
			mRect.offsetMin = new Vector2 (mRect.offsetMin.x, mPos);//将新位置赋值给上升窗口
		}
	}
}
