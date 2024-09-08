using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    // jumpForce lực nhảy
    public float jumpForce;
    // bool trả về giá trị đúng or sai
    private bool levelStart;
    public GameObject gameController;
    public GameObject message;
    private int score;
    public Text scoreText;
    private void Awake()
    //hàm đầu tiên
    {
        //this là một con trỏ trỏ tới rig
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        rigidbody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;

        //kiểm tra
        //if(rigibody != null)
        //{
        //    Debug.Log("Da tim thay Rigidbody2D");
        //}
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    this.gameObject.GetComponent<Rigidbody2D>();
    //}

    // Update is called once per frame
    //update chay lien tuc moi frame
    void Update()
    {
        //kiem tra xem phim space co dc bam ko
        //Getkeydown bam phim 1 laan duy nha
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundController.instance.PlayThisSound("wing", 0.5f);
            if (levelStart == false)
            {
                levelStart = true;
                rigidbody.gravityScale = 6;
                gameController.GetComponent<PipeGenerator>().enableGenratePipe = true;
                message.GetComponent<SpriteRenderer>().enabled = false;

            }
            //Debug.Log("space pressed");
            BirdMoverUP();
        }

    }
    //lam chim bay len 1 khoang
    private void BirdMoverUP()
    {
        //velocity vecto van toc huong mui ten
        //rigidbody.Velocity = Vector2.up * jumpForce;
        rigidbody.velocity = Vector2.up * jumpForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSound("hit", 0.5f);
        //Debug.Log("Va cham!");
        ReloadScene();
        score = 0;
        scoreText.text = score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundController.instance.PlayThisSound("point", 0.5f);
        //Debug.Log("+1");
        //tang diem
        score += 1;
        scoreText.text = score.ToString();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("gameplay");
    }
}


