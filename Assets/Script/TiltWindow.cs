using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TiltWindow : MonoBehaviour
{
	public Vector2 Range;//倾斜幅度，x横向，y纵向
	Vector2 mRot = Vector2.zero;//倾斜变量
	Transform mTrans;//当前物体transform
	Quaternion mStart;//当前物体旋转角的
	RectTransform mRect;//当前物体RectTransform组件

	void Start ()
	{
		mTrans = transform;//获得当前物体transform
		mStart = mTrans.localRotation;//获得当前物体旋转角的
		mRect = GetComponent <RectTransform> ();//获得当前物体RectTransform组件
	}

	void Update ()
	{
		Vector3 Pos = Input.mousePosition;//获得鼠标位置

		//以像素为单位计算一半宽度
		float halfWidth = (mRect.anchorMax.x - mRect.anchorMin.x) * Screen.width * 0.5f;
		//以像素为单位计算一半宽度
		float halfHeight = (mRect.anchorMax.y - mRect.anchorMin.y) * Screen.height * 0.5f;
		float PivotX = mRect.anchorMin.x * Screen.width + halfWidth;//计算中心点x坐标
		float PivotY = mRect.anchorMin.y * Screen.height + halfHeight;//计算中心点y坐标
		//根据鼠标与中心点距离返回横向幅度，(-1,1)之间
		float x = Mathf.Clamp ((Pos.x - PivotX) / halfWidth, -1f, 1f);
		//根据鼠标与中心点距离返回纵向幅度，(-1,1)之间
		float y = Mathf.Clamp ((Pos.y - PivotY) / halfHeight, -1f, 1f);

		//渐变到指定角度
		mRot = Vector2.Lerp (mRot, new Vector2 (x, y), Time.deltaTime * 5f);
		//改变角度使物体倾斜
		mTrans.localRotation = mStart * Quaternion.Euler (-mRot.y * Range.y, mRot.x * Range.x, 0f);
	}
}
