using UnityEngine;

//Author: Unity Tutorial
//Modified By: Adriana Arzola
//Date: 04/07/2019
public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
