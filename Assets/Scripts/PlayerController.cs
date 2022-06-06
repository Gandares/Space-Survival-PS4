using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PS4;

public class PlayerController : MonoBehaviour
{
    private float speed = 6;
    private float passiveUpSpeed = 2.5f;
    public GameObject allyBullet;
    public Transform FirePoint;
    private bool canShoot = true;
    private float delayInSeconds = 0.6f;
    private int life = 3;
    private CanvasScript c;

    void Start() {
        c = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
    }

    void Update()
    {
        // Movimiento horizontal
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0.1f && transform.position.x < 4.85f){
            transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);
        }
        else if (horizontal < 0.1f && transform.position.x > -4.85f){
            transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);
        }

        //Movimiento vertical

        transform.Translate(new Vector3(0,-1,0) * passiveUpSpeed * Time.deltaTime);

        // Disparo

        if(Input.GetButton("Fire1") && canShoot == true){
            Instantiate(allyBullet, FirePoint.position, Quaternion.Euler(0,0,0));
            Debug.Log("Dispara");
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay(){
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet"){
            life--;
            PS4Input.PadSetVibration(0,50,50);
            c.setLifes(life);
            Debug.Log(life);

            // Muerte

            if(life == 0){
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
