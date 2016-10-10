using UnityEngine;
using System.Collections;

public class BackScroll : MonoBehaviour
{

	public float ScrollVelocity = 25.0f;//滚动速度
	public float mTop = 150.0f;//上边界
    public float mMiddle = 0;//中点
	public float mBottom = -150.0f;//下边界

	public GameObject mBack1;//背景1
	public GameObject mBack2;//背景2

	void Update ()
	{
        mBack1.transform.Translate(Vector3.down * ScrollVelocity * Time.deltaTime, Space.Self);
		//如果背景1的位置小于下边界
		if (mBack1.transform.position.y <= mBottom) {
			//背景1位置移到上边界
			mBack1.transform.position = new Vector3 (mBack1.transform.position.x, mTop, mBack1.transform.position.z);
            mBack2.transform.position = new Vector3(mBack2.transform.position.x, mMiddle, mBack2.transform.position.z);
        }
        mBack2.transform.Translate(Vector3.down * ScrollVelocity * Time.deltaTime, Space.Self);
        //如果背景2的位置小于下边界
        if (mBack2.transform.position.y <= mBottom) {
			//背景2位置移到上边界
			mBack2.transform.position = new Vector3 (mBack2.transform.position.x, mTop, mBack2.transform.position.z);
            mBack1.transform.position = new Vector3(mBack2.transform.position.x, mMiddle, mBack2.transform.position.z);
        }
	}
}
