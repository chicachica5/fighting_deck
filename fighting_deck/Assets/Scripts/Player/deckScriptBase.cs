using UnityEngine;
using System;
using System.Collections.Generic;

public class DeckScriptBase : MonoBehaviour
{
    // Base is where the cards are before the hand, where they can be player
    //Discarded are the cards already played
    List<GameObject> deckBase;
    List<GameObject> deckDiscarded;
    private GameObject realDeck;

    //Is linked to cardHolder, an UI gameObject that is the hand, where cards are played
    [SerializeField] GameObject canvasHandUI;

    //Just for now
    int numOfHandCards = 0;
    List<GameObject> deckHand;

    DeckSelection deckManager;

    void Awake()
    {
        realDeck = GameObject.Find("GigaDeck");
        deckBase = new List<GameObject>();
        deckDiscarded = new List<GameObject>();
        deckHand = new List<GameObject>();

        AddCardsToDeck();
    }
    
    void Start()
    {
        deckManager = gameObject.GetComponent<DeckSelection>();
        DeckToHand();
    }

    void Update()
    {
        //Debugs to call on processes that are not yet automatized
        if(Input.GetButtonDown("Debug Deck 1")) 
        {
            DeckToHand();
        }

        if(Input.GetButtonDown("Debug Deck 2"))
        {
            AddCardsToDeck();
        }

        if(Input.GetButtonDown("Debug Deck 3"))
        {
            ReturnToDeck();
        }
    }

    //Called externally for cards to return from hand to discardPile
    public void AddToDiscarded(GameObject obj)
    {
        obj.transform.SetParent(null);
        
        deckDiscarded.Add(obj);
        numOfHandCards--;
        int objID = obj.GetComponent<IDScript>().id;

        for(int i = 0; i < deckHand.Count; i++) 
        {
            if(deckHand[i].GetComponent<IDScript>().id == objID)    
            {
                deckHand.RemoveAt(i);
                break;
            }
        }

        DeckToHand();
    }

    //Check if ReturnToDeck should be called
    void CheckDeck()
    {
        if(deckBase.Count == 0) ReturnToDeck();
    }

    //Return cards from discard to predrawn deck
    void ReturnToDeck()
    {
        for(int i = 0; i < deckDiscarded.Count; i ++)
        {
            deckBase.Add(deckDiscarded[i]);
        }
        deckDiscarded.Clear();
    }

    //Add cards from initial deck to ingame(here), called at start
    void AddCardsToDeck() 
    {
        List<GameObject> l = realDeck.GetComponent<GigaDeck>().GetList();
        GameObject aux;

        for (int i = 0; i < l.Count; i++)
        {
            aux = Instantiate(l[i]);
            aux.GetComponent<IDScript>().id = i;
            deckBase.Add(aux);
        }
    }

    //Refill hand up to seven cards each time
    void DeckToHand()
    {
        for (int i = 0; i < 7-numOfHandCards; i++) 
        {
            deckBase[i].SetActive(true);
            deckHand.Add(deckBase[i]);
            deckBase[i].transform.SetParent(canvasHandUI.transform);            
        }

        deckBase.RemoveRange(0, 7-numOfHandCards);

        numOfHandCards = 7;
        deckManager.SetBaseState();
        CheckDeck();
    }

    //Tells how many cards in some lists
    void PrintState() 
    {
        //Print debug state of deck for very unimportant knowledge of the world
        Debug.Log(deckBase.Count);
    
        Debug.Log(deckDiscarded.Count);
    }

    public List<GameObject> GetHand() 
    {
        return deckHand;
    }

    public GameObject GetHandCard(int i)
    {
        return deckHand[i];
    }
}
