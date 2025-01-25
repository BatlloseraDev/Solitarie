using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject highScorePanel;
    public GameObject OptionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void PlayAgain()
    {
        highScorePanel.SetActive(false);
        ResetScene();
    }

    public void Options()
    {
        OptionsPanel.SetActive(true);

    }
    public void GameModeEasy()
    {
        Solitaire game = FindObjectOfType<Solitaire>();
        game.GameMode = 1;
        OptionsPanel.SetActive(false);
        ResetScene();


    }
    public void GameModeHard()
    {
        Solitaire game = FindObjectOfType<Solitaire>();
        game.GameMode = 3;
        OptionsPanel.SetActive(false);
        ResetScene();


    }


    public void ResetScene()
    {

        UpdateSprite[] cards = FindObjectsOfType<UpdateSprite>();
        foreach(UpdateSprite card in cards)
        {
            if (card.name != "Card")
            {
                Destroy(card.gameObject);
            }
            
        }
        ClearTopValues();

        FindObjectOfType<Solitaire>().PlayCards();

    }

    void ClearTopValues()
    {
        Selectable[] selectables = FindObjectsOfType<Selectable>();
        foreach(Selectable selectable in selectables)
        {
            if (selectable.CompareTag("Top"))
            {
                selectable.suit = null;
                selectable.value = 0;
            }
        }
    }
}
