using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{

    public Transform verRot;
    public Transform horRot;
    private GameObject mainCamera;              //メインカメラ格納用
    private GameObject playerObject;            //回転の中心となるプレイヤー格納用
    public float rotateSpeed = 3.0f;            //回転の速さ

    // Use this for initialization
    void Start()
    {

        verRot = transform.parent;
        horRot = GetComponent<Transform>();
    }

    


    void Update()
    {

        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        // transformを取得
        Transform myTransform = this.transform;

        // ローカル座標を基準に、回転を取得
        Vector3 localAngle = myTransform.localEulerAngles;
        float local_angle_x = localAngle.x; // ローカル座標を基準にした、x軸を軸にした回転角度
        float local_angle_y = localAngle.y; // ローカル座標を基準にした、y軸を軸にした回転角度
        float local_angle_z = localAngle.z; // ローカル座標を基準にした、z軸を軸にした回転角度
        /*
        if (local_angle_y > 30f && local_angle_y < 40f && Y_Rotation>0)
        {
            Y_Rotation = 0f;
        }
        if (local_angle_y < 330f && local_angle_y > 340f  && Y_Rotation < 0)
        {
            Y_Rotation = 0f;
        }
        */
        verRot.transform.Rotate(0, X_Rotation * 3, 0);
        horRot.transform.Rotate(-Y_Rotation * 3, 0, 0);
        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldDir = ray.direction;
        this.transform.LookAt(worldDir);*/
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()をしようしてメインカメラを回転させる
        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        //mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, angle.y);

    }
}