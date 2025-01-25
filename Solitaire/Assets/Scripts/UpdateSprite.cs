using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Solitaire solitaire;
    private UserInput userInput; 



    void Start()
    {
        List<string> deck = Solitaire.GenerateDeck();
        solitaire = FindObjectOfType<Solitaire>();
        userInput = FindObjectOfType<UserInput>();
        int i = 0;

        foreach(string card in deck)
        {
            if(this.name == card)
            {
                cardFace = solitaire.cardFaces[i];
       
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();

    }

    // Update is called once per frame
    void Update()
    {
        if(selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
          //  GetComponentInChildren<GameObject>().SetActive(true);
        }
        else
        {
            spriteRenderer.sprite = cardBack;
            //GetComponentInChildren<GameObject>().SetActive(false);
        }// cambio de caras cuando estan ocultas (cambiar esto para que haya una ligera animacion) 

        if (userInput.slot1)
        {

            if (name == userInput.slot1.name)
            {
                spriteRenderer.color = Color.yellow;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }//cuando la tenga seleccionada cambiara el color






    }
}
