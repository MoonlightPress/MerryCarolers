using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public float merrimentValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            MerrimentController.IncreaseMerriment(merrimentValue);
            this.gameObject.SetActive(false);
        }
    }
}
