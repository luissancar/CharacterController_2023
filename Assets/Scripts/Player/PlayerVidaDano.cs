using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerVidaDano : MonoBehaviour
    /// asignar a player
{
    public int vidasMaximas=10;
    public int vida ;
    public bool invencible = false;
    public float tiempoInvencible = 1f;
    public float tiempoDeFrenado = 0.3f;
    private Animator animacion;
    public TextMeshProUGUI textoVidas;
    public GameObject textoGameOver;
    public bool gameOver = false;

    private void Start()
    {
        vida = vidasMaximas;
        animacion = GetComponent<Animator>();
        textoVidas.text = "Vidas: " + vida.ToString("0000");
        textoGameOver.SetActive(false);
    }


    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Principal01"); 
            }
        }
    }

    public void RestarVida(int cantidad)
    {
        if (!invencible && vida > 0)
        {
            vida -= cantidad;
            textoVidas.text = "Vidas: " + vida.ToString("0000");
            if (vida > 0)
            {
                animacion.Play("Damage");
                StartCoroutine(Invulnerable(tiempoInvencible));
                StartCoroutine(PararJugador(tiempoDeFrenado));
            }
            else
            {
                GameOver();
            }
        }

        void GameOver()
        {
            animacion.Play("Muerte");
            StartCoroutine(GameOverCorrutina());
        }

        IEnumerator GameOverCorrutina()
        {
            invencible = true;
            gameOver = true;
            GetComponent<PlayerController>().playerSpeed = 0;
            yield return new WaitForSeconds(4);
            textoGameOver.SetActive(true);
            yield return new WaitForSeconds(6);
          //  SceneManager.LoadScene("Principal01");
        }

        IEnumerator Invulnerable(float tiempo)
        {
            invencible = true;
            yield return new WaitForSeconds(tiempo);
            invencible = false;
        }

        IEnumerator PararJugador(float tiempo)
        {
            var velocidadActual = GetComponent<PlayerController>().playerSpeed;
            GetComponent<PlayerController>().playerSpeed = 0;
            yield return new WaitForSeconds(tiempo);
            GetComponent<PlayerController>().playerSpeed = velocidadActual;
        }
    }
}