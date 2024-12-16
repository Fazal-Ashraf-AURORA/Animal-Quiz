using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{

    //public Text animalNameText;      // Reference to the Text for the animal's name
    public Image animalImage;        // Reference to the Image for the animal sprite
    public Button cardButton;        // Reference to the button on the card
    public CardData cardData;        // Reference to the ScriptableObject (CardData)

    // Popup references
    public GameObject descriptionPopup;   // Reference to the popup panel
    public TextMeshProUGUI descriptionText;           // Text inside the popup

    // Method to set the card data
    public void SetCardData(CardData data)
    {
        cardData = data;
        //animalNameText.text = cardData.animalName;
        animalImage.sprite = cardData.animalSprite;
    }

    // Show the description in the popup when the button is clicked
    public void ShowDescription()
    {
        descriptionPopup.SetActive(true);
        descriptionText.text = cardData.description;  // Set the description text to the selected animal's description
    }

    // Close the popup
    public void ClosePopup()
    {
        descriptionPopup.SetActive(false);
    }
}
