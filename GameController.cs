using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject target;
    GameObject targetUD;
    GameObject tower;
    GameObject tank;
    public int target_destroy = 0;
    public int tower_destroy = 0;
    public int tank_destroy = 0;
    private float def_x = -122;
    private float def_y = -5;
    private float currentTime = 0f;
    private int flag = 0;
    private bool next = false;
    // Start is called before the first frame update
    void Start()
    {
        target = (GameObject)Resources.Load("Target");
        targetUD = (GameObject)Resources.Load("TargetUD");
        tower = (GameObject)Resources.Load("Towe");
        tank = (GameObject)Resources.Load("Tank");

    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;

        //1 seconds 3 targets appear
        if(flag==0 && currentTime > 1f)
        {
            Generate(flag);
            //currentTime = 0f;
            flag = 1;
            Debug.Log(flag);

        }
        if (flag == 1 && currentTime > 10f)
        {
            Generate(flag);
            //currentTime = 0f;
            flag = 2;
            Debug.Log(target_destroy);
        }
        if (flag == 2 && currentTime > 20f)
        {
            Generate(flag);
            //currentTime = 0f;
            flag = 3;
            Debug.Log(target_destroy);
        }

        //if all targets are killed or after 10 seconds
        //
    }
    void Generate(int f)
    {
        if (f == 0)
        {
            Instantiate(target, new Vector3(def_x, def_y, 100f), Quaternion.identity);
            Instantiate(target, new Vector3(def_x+10f, def_y, 130f), Quaternion.identity);
            Instantiate(target, new Vector3(def_x-10f, def_y, 130f), Quaternion.identity);
        }
        if (f == 1)
        {

            Instantiate(targetUD, new Vector3(def_x, def_y, 100f), Quaternion.identity);
            Instantiate(targetUD, new Vector3(def_x+10f, def_y, 100f), Quaternion.identity);
            Instantiate(targetUD, new Vector3(def_x-10f, def_y, 100f), Quaternion.identity);
        }
        if (f == 2)
        {

            Instantiate(tower, new Vector3(def_x, def_y, 130f), Quaternion.identity);
            Instantiate(tower, new Vector3(def_x + 10f, def_y, 130f), Quaternion.identity);
            Instantiate(tower, new Vector3(def_x - 10f, def_y, 130f), Quaternion.identity);
        }
    }
}
