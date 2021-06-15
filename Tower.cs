using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameObject gameController;

    private float currentTime = 0f;
    GameController script;
    void Start()
    {

        gameController = GameObject.Find("GameController");
        script = gameController.GetComponent<GameController>();
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 10f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        // ここで Particle System を開始します.
        // particle.Play();
        GameObject obj = (GameObject)Resources.Load("Explosion");
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(obj, this.transform);
        Destroy(gameObject, 1f);
        script.tower_destroy += 1;

    }
}