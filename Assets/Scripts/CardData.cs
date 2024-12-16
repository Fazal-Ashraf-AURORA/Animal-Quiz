using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Quiz/Card Data")]
public class CardData : ScriptableObject
{
    [Header("General Info")]
    public string animalName;       // Name of the animal
    public Sprite animalSprite;     // Sprite for the card
    [TextArea]
    public string description;      // Description of the animal

    [Header("Attributes")]
    public FlyingType flyingType;       // Flying or Non-Flying
    public InsectType insectType;       // Insect or Non-Insect
    public DietType dietType;           // Omnivorous or Herbivorous
    public GroupBehavior groupBehavior; // Lives in Group or Solo
    public ReproductionType reproductionType; // Lays Eggs or Gives Birth
}

// Enums for various attributes
public enum FlyingType
{
    NonFlying,
    Flying
}

public enum InsectType
{
    NonInsect,
    Insect
}

public enum DietType
{
    Omnivorous,
    Herbivorous
}

public enum GroupBehavior
{
    Solo,
    LivesInGroup
}

public enum ReproductionType
{
    LaysEggs,
    GivesBirth
}
