using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CardDataImporter : MonoBehaviour
{
    [Header("File Settings")]
    public string filePath = "Assets/AnimalData.txt"; // Path to the input text file
    public string outputFolder = "Assets/CardData/"; // Folder to save ScriptableObjects

    public void ImportAnimalData()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found at path: " + filePath);
            return;
        }

        // Ensure the output folder exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Read all lines from the file
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            // Skip empty lines
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Parse animal data from the line
            string[] fields = line.Split(';');

            if (fields.Length < 7)
            {
                Debug.LogError("Invalid data format in line: " + line);
                continue;
            }

            // Create a new CardData ScriptableObject
            CardData cardData = ScriptableObject.CreateInstance<CardData>();

            // Assign values from the file
            cardData.animalName = fields[0].Trim();
            cardData.description = fields[1].Trim();
            cardData.flyingType = Enum.Parse<FlyingType>(fields[2].Trim(), true);
            cardData.insectType = Enum.Parse<InsectType>(fields[3].Trim(), true);
            cardData.dietType = Enum.Parse<DietType>(fields[4].Trim(), true);
            cardData.groupBehavior = Enum.Parse<GroupBehavior>(fields[5].Trim(), true);
            cardData.reproductionType = Enum.Parse<ReproductionType>(fields[6].Trim(), true);

            // Save the ScriptableObject to the output folder
            string assetPath = Path.Combine(outputFolder, cardData.animalName + ".asset");
            AssetDatabase.CreateAsset(cardData, assetPath);
            Debug.Log("Created CardData for: " + cardData.animalName);
        }

        // Save changes to the AssetDatabase
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Animal data import completed.");
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(CardDataImporter))]
public class CardDataImporterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CardDataImporter importer = (CardDataImporter)target;
        if (GUILayout.Button("Import Animal Data"))
        {
            importer.ImportAnimalData();
        }
    }
}
#endif
