using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    //キューブが積み重なるときの効果音
    private AudioSource audioSource;
    public AudioClip se;

    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

	// Use this for initialization
	void Start () {
        //効果音を取得
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

    //キューブが地面とキューブに接触したときに効果音を鳴らす
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cube" || collision.gameObject.tag == "ground")
        {
            this.audioSource.PlayOneShot(se);
        }       
    }
}
