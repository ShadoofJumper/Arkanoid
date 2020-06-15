using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName = "Potions/Potion")]
public class PotionSettings : ScriptableObject
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private int bonusCoins;
    [SerializeField]
    private int bonusLives;
    [SerializeField]
    private float freezePower;
    [SerializeField]
    private float freezeDelay;
    [SerializeField]
    private int fallSpeed;

    public Color Color          => color;
    public int  BonusCoins      => bonusCoins;
    public int BonusLives       => bonusLives;
    public float FreezePower    => freezePower;
    public float FreezeDelay    => freezeDelay;
    public int FallSpeed        => fallSpeed;
}
