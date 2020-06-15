using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float screenWidth          = 8.0f;
    [SerializeField] private float screenBottomRedLine  = 3.0f;
    [SerializeField] private List<Transform>    blockSpots;
    [SerializeField] private Transform          blockFolder;
    [SerializeField] private List<GameObject>   blockPrefabs;
    [SerializeField] private List<Color>        blockColors;
    [SerializeField] private Color              invincibleBlockColor;
    [SerializeField] private Ball               ball;
    private int destroyebleBlockSpawned;

    public float SCREEN_WIDTH   => screenWidth;
    public Ball Ball            => ball;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // --------------- spawn blocks logic ---------------
    private void SpawnRandomBlocks()
    {
        foreach (Transform spot in blockSpots)
        {
            int randomBlockId = Random.Range(0, blockPrefabs.Count);
            GameObject randomBlockObject = blockPrefabs[randomBlockId];
            SpawnBlock(randomBlockObject, spot.position);
        }
        MainManager.inst.GameManager.CurrentBlockLive = destroyebleBlockSpawned;
    }

    private void SpawnBlock(GameObject blockObjectOrigin, Vector3 position)
    {
        GameObject blockObject          = Instantiate(blockObjectOrigin, blockFolder);
        Block block                     = blockObject.GetComponent<Block>();
        bool isDestroyable              = CheckBlockDestroyable(block);
        blockObject.transform.position  = position;
        SetBlockRandomColor(block, isDestroyable);
        if (isDestroyable)
            destroyebleBlockSpawned += 1;
    }

    private void SetBlockRandomColor(Block block, bool isDestroyable)
    {
        Color randomColor;
        //check is block invincible
        if (!isDestroyable)
        {
            randomColor = invincibleBlockColor;
        }
        else
        {
            int randomColorId = Random.Range(0, blockColors.Count);
            randomColor = blockColors[randomColorId];
        }
        block.SetColor(randomColor);
    }

    private bool CheckBlockDestroyable(Block block)
    {
        return block as DestroyedBlock == null ? false : true;
    }

    // ------------------------------------------------------


    // create gizmo for interacteble object
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Transform spot in blockSpots)
        {
            Gizmos.DrawWireSphere(spot.position, 0.55f);
        }
    }
}
