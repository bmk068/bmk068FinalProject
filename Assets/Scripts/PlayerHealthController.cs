using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;
    public int maxHealth;

    public float damageInvincibleLength = 1f;
    private float invincibleCount;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCount > 0){
            invincibleCount -= Time.deltaTime;

            if(invincibleCount <= 0){
               PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 1f); 
            }
        }
    }

    public void DamagePlayer(){

        if(invincibleCount <= 0){
            AudioManager.instance.PlaySFX(11);
            currentHealth--;

            invincibleCount = damageInvincibleLength;

            PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, .5f);


            if(currentHealth <= 0){
                PlayerController.instance.gameObject.SetActive(false);

                UIController.instance.deathScreen.SetActive(true);

                AudioManager.instance.PlayGameOver();
                AudioManager.instance.PlaySFX(8);
            }

            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
    }

    public void MakeInvincible(float length){
        invincibleCount = length;
        PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, .5f);

    }

    public void HealPlayer(int healAmount){
        currentHealth += healAmount;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
