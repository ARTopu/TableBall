using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToClick : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;

    int score = 0;
    int life = 10;
    public GameObject winText;
    public GameObject loseText;
    public GameObject restartBtn;
    public GameObject exitBtn;
    public GameObject totalScore;
    public int winScore;
    public int dieScore;
    public Text scoreText;
    public Text lifeText;
    public Text TotalScore;
    

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        } 
       transform.position = Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Green")
        {
            score++;
            scoreText.text = score.ToString();
            

            Destroy(collision.gameObject);
            

            if (score >=winScore) 
            {
                winText.SetActive(true);
                restartBtn.SetActive(true); 
                exitBtn.SetActive(true);
                TotalScore.text = score.ToString();
                totalScore.SetActive(true);
                speed = 0;
            }
        }

        if (collision.gameObject.tag == "Red")
        {
            life--;
            lifeText.text = life.ToString();

            Destroy(collision.gameObject);

            if (life == dieScore)
            {
                loseText.SetActive(true);
                restartBtn.SetActive(true);
                exitBtn.SetActive(true);
                TotalScore.text = score.ToString();
                totalScore.SetActive(true);
                speed = 0;
            }
        }

        if (collision.gameObject.tag == "Bound")
        {
            loseText.SetActive(true);
            restartBtn.SetActive(true);
            exitBtn.SetActive(true);
            TotalScore.text = score.ToString();
            totalScore.SetActive(true);
            speed = 0;

        }

    }
}
