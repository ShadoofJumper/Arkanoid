using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float screenWidth = 8.0f;
    [SerializeField] private List<Transform>        blockSpots;
    [SerializeField] private List<BlockSettings>    blockSettings;
    [SerializeField] private Ball                   ball;
    [SerializeField] private GameObject             emptyBlock;

    public float SCREEN_WIDTH   => screenWidth;
    public Ball Ball            => ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomBlocks()
    {
        foreach (Transform spot in blockSpots)
        {
            int randomBlockId = Random.Range(0, blockSettings.Count);
            BlockSettings randomBlockSetting = blockSettings[randomBlockId];
        }
    }

    private void SpawnBlock(BlockSettings blockSetting)
    {
        GameObject block = Instantiate(emptyBlock);

        switch (blockSetting.BlockType)
        {
            case BlockTypes.Invencible:
                //CreateBlockInvencible(block);
                break;
            case BlockTypes.GhostEffect:
                //CreateGhostBlock(block);
                break;
            case BlockTypes.PotionDrop:
                //CreatePotionBlock(block);
                break;
        }
    }



    // create gizmo for interacteble object
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Transform spot in blockSpots)
        {
            Gizmos.DrawWireSphere(spot.position, 0.3f);
        }
    }
}
