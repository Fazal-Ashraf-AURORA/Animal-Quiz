using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;  // Reference to the CardPrefab
    public Transform cardHolder;  // The parent holder for all cards
    public CardData[] cardDataArray;  // Array of ScriptableObjects (CardData)

    // Popup references
    public GameObject descriptionPopup;  // Reference to the popup panel
    public TextMeshProUGUI descriptionText;         // Text inside the popup

    void Start()
    {
        PopulateCards();
    }

    void PopulateCards()
    {
        // Loop through each CardData and instantiate a card
        for (int i = 0; i < cardDataArray.Length; i++)
        {
            // Instantiate the card
            GameObject card = Instantiate(cardPrefab, cardHolder);

            // Get the Card script on the instantiated card
            Card cardScript = card.GetComponent<Card>();

            // Set the card data
            cardScript.SetCardData(cardDataArray[i]);

            // Set the popup reference for each card
            cardScript.descriptionPopup = descriptionPopup;
            cardScript.descriptionText = descriptionText;

            // Set up button to show description when clicked
            Button cardButton = card.GetComponent<Button>();
            cardButton.onClick.AddListener(cardScript.ShowDescription);
        }
    }
}
