using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public AudioSource source;
    public AudioClip Clip;  
    private int strawberry = 0;
    public TextMeshProUGUI score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Strawberry")
        {
            Destroy(collision.gameObject);  
            strawberry++;
            score.text = "Strawberry: " + strawberry;
            source.PlayOneShot(Clip);

        }
    }
}
