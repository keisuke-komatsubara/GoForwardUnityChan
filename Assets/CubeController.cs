using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip se;

    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

	// Use this for initialization
	void Start () {
        this.audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cube" || collision.gameObject.tag == "ground")
        {
            this.audioSource.PlayOneShot(se);
        }       
    }
}
