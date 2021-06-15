using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGen : MonoBehaviour
{
    public GameObject ArrowPrefab;
    float currentTime = 0f;
    float Intime = 0f;


    Vector3 cameraAngle;　//カメラの角度を代入する変数
    public GameObject camera; //カメラオブジェクトを格納

    //float Outtime = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Intime =currentTime;
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            GameObject Arrow = Instantiate(ArrowPrefab) as GameObject;
            // transformを取得
            Transform myTransform = Arrow.transform;
            Vector3 worldAngle = GameObject.Find("AliciaSolid/Main Camera").transform.eulerAngles;
            Vector3 localPos = GameObject.Find("AliciaSolid/PracticeBowWithRig").transform.position;
            Debug.Log(worldAngle);
            // ローカル座標を基準に、座標を取得
            //Vector3 localPos = myTransform.localPosition;
            float x = localPos.x;    // ローカル座標を基準にした、x座標が入っている変数
            float y = localPos.y;    // ローカル座標を基準にした、y座標が入っている変数
            float z = localPos.z;    // ローカル座標を基準にした、z座標が入っている変数
            myTransform.localPosition = localPos; // ローカル座標での座標を設定
            myTransform.eulerAngles = worldAngle; // 回転角度を設定
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            //myTransform.eulerAngles = ray.direction;
            //myTransform.eulerAngles = worldDir; // 回転角度を設定
            //Arrow.transform.LookAt(new Vector3(worldDir.x + 0.2f, worldDir.y + 1f, worldDir.z));

            // Arrow.transform.LookAt(worldDir);
            /*
                    //カメラの方向を取得
                    cameraAngle = camera.transform.rotation * Vector3.forward;
                    //アタッチしているオブジェクトをカメラの向きに向けてthrustだけの力をかける
                    //rb.AddForce(cameraAngle * thrust);

                    var ray = new Ray(transform.position, transform.forward);
                    Vector3 worldDir = ray.direction;
                    Vector3 worldAngle = GameObject.Find("AliciaSolid").transform.eulerAngles;
                    Vector3 localPos = GameObject.Find("AliciaSolid/PracticeBowWithRig").transform.position;
                    Debug.Log(worldAngle);
                    // ローカル座標を基準に、座標を取得
                    //Vector3 localPos = myTransform.localPosition;
                    float x = localPos.x;    // ローカル座標を基準にした、x座標が入っている変数
                    float y = localPos.y;    // ローカル座標を基準にした、y座標が入っている変数
                    float z = localPos.z;    // ローカル座標を基準にした、z座標が入っている変数

                    GameObject Arrow = Instantiate(ArrowPrefab, localPos, Quaternion.Euler(worldDir)) as GameObject;
                    Arrow.transform.LookAt(new Vector3(worldDir.x+0.2f,worldDir.y+1f, worldDir.z));
                    //Arrow.transform = myTransform;
                    */
            if (currentTime-Intime > 3f)
            {
                Arrow.GetComponent<StandardizedProjectile>().Shoot(worldDir.normalized * 6000 * 3f);

            }
            else
            {
                Arrow.GetComponent<StandardizedProjectile>().Shoot(worldDir.normalized * 6000 * (currentTime-Intime));

            }
            currentTime = 0f;
            
        }
        
    }
}
