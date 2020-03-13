using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    healthPotion,
    orbs,
}
public class Collectable : MonoBehaviour
{
    public CollectableType type = CollectableType.orbs;

    SpriteRenderer sprite;
    CircleCollider2D itemCollider;
    public bool hasBeenCollected = false;
    public int value = 1;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();
    }

   void Show()
    {
        sprite.enabled = true;
        itemCollider.enabled = true;
        hasBeenCollected = false;
    }

    void Hide()
    {
        sprite.enabled = false;
        itemCollider.enabled = false;
    }

    void Collect()
    {
        Hide();
        hasBeenCollected = true;

        switch (this.type)
        {
            case CollectableType.orbs:
                GameManager.sharedInstance.CollectObject(this);
                GetComponent<AudioSource>().Play();
                break;

            case CollectableType.healthPotion:
                // logica de la health potion
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collect();
        }
    }
}
