using UnityEngine;
using System.Collections.Generic;

public class DeckSelection : MonoBehaviour
{
    int maxCards = 7;
    int actualCard = 0;
    DeckScriptBase deck;

    void Awake()
    {
        deck = gameObject.GetComponent<DeckScriptBase>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Debug Button 1"))
        {
            SetBaseState();
        }

        if(Input.GetButtonDown("LeftHandCard") && actualCard > 0) MoveToLeft();
        if(Input.GetButtonDown("RightHandCard") && actualCard < maxCards-1) MoveToRight();
        if(Input.GetButtonDown("Fire1")) ShootSelected();
    }

    void ShootSelected()
    {
        GameObject card = deck.GetHandCard(actualCard);
        card.GetComponent<shootScript>().Shoot();
    }

    public void SetBaseState()
    {
        List<GameObject> hand = deck.GetHand();
        Vector3 pos = new Vector3(220, 30, 0);
        maxCards = hand.Count;
        if (actualCard > maxCards-1) actualCard = maxCards-1;
        for (int i = 0; i < maxCards; i++)
        {
            pos = hand[i].GetComponent<RectTransform>().position = pos;
            pos.x += 80;
        }
        SetSelectedCard();
    }

    void MoveToRight()
    {
        GameObject card = deck.GetHandCard(actualCard);
        Vector3 vec = card.GetComponent<RectTransform>().position;
        vec.y -= 60;
        
        card.GetComponent<RectTransform>().position = vec;
        actualCard++;
        SetSelectedCard();
    }

        void MoveToLeft()
    {
        GameObject card = deck.GetHandCard(actualCard);
        Vector3 vec = card.GetComponent<RectTransform>().position;
        vec.y -= 60;
        
        card.GetComponent<RectTransform>().position = vec;
        actualCard--;
        SetSelectedCard();
    }

    void SetSelectedCard() 
    {
        GameObject card = deck.GetHandCard(actualCard);
        Vector3 vec = card.transform.position;
        vec.y += 60;
        card.GetComponent<RectTransform>().position = vec;
    }
}
