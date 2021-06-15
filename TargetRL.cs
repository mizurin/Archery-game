using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRL : MonoBehaviour
{
    private GameObject gameController;
    GameController script;
    private bool killed = false;
    private Transform neutral;
    void Start()
    { 
        neutral = this.transform;
        gameController = GameObject.Find("GameController");
        script = gameController.GetComponent<GameController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (killed == false)
        {
            this.transform.position = new Vector3(neutral.position.x + Mathf.Sin(Time.time) / 30f, neutral.position.y, neutral.position.z);
            //this.transform.position = new Vector3(neutral.position.x, neutral.position.y , neutral.position.z);

        }
    }
    void OnTriggerEnter(Collider collision)
    {
        killed = true;
        GameObject obj = (GameObject)Resources.Load("Explosion");
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(obj, this.transform);
        Destroy(gameObject, 1f);
        script.target_destroy += 1;
    }
}
