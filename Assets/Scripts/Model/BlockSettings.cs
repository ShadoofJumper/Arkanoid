using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block", menuName = "Block/Block")]
public class BlockSettings : ScriptableObject
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private BlockTypes blockType;

    [Header("Params for 'potion' block type")]
    [SerializeField] private PotionSettings potionSettings;
    [Header("Params for 'destroyable' block types")]
    [SerializeField]  private float blockHealth;

    public Color Color  => color;
    public float Health => blockHealth;
    public PotionSettings PotionSettings => potionSettings;
    public BlockTypes BlockType => blockType;
}

public enum BlockTypes
{
    Invencible,
    GhostEffect,
    PotionDrop
}