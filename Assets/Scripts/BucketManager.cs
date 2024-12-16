using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BucketManager : MonoBehaviour
{
    [Header("Bucket UI Elements")]
    public TextMeshProUGUI redBucketLabel;    // Text component for the red bucket
    public TextMeshProUGUI blueBucketLabel;   // Text component for the blue bucket

    [Header("Category Pairs")]
    private string[,] categoryPairs = new string[,]
    {
        { "Flying", "Non-Flying" },
        { "Insect", "Non-Insect" },
        { "Omnivorous", "Herbivorous" },
        { "Lives in Group", "Solo" },
        { "Lays Eggs", "Gives Birth" }
    };

    void Start()
    {
        AssignCategoryPair();
    }

    void AssignCategoryPair()
    {
        // Randomly select a pair
        int randomIndex = Random.Range(0, categoryPairs.GetLength(0));

        string redLabel = categoryPairs[randomIndex, 0];
        string blueLabel = categoryPairs[randomIndex, 1];

        // Assign labels to buckets
        redBucketLabel.text = redLabel;
        blueBucketLabel.text = blueLabel;
    }
}
