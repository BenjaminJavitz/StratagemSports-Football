using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGrid : MonoBehaviour
{
 
    public int rows;
    public int columns;

    public Vector2 GridSize;
    public Vector2 GridOffset;

    public Sprite CellSprite;
    private Vector2 CellSize;
    private Vector2 CellScale;


     // Start is called before the first frame update
     void Start()
    {
        InitializeCells();
    }

    // Update is called once per frame
    void InitializeCells()
    {
        GameObject CellObject = new GameObject( );

        CellObject.AddComponent<SpriteRenderer>( ).sprite = CellSprite;

       

        CellSize = CellSprite.bounds.size;

        Vector2 NewCellSize = new Vector2(GridSize.x / (float)columns, GridSize.y / (float)rows);

        CellScale.x = NewCellSize.x / CellSize.y;
        CellScale.y = NewCellSize.y / CellSize.x;

        CellSize = NewCellSize;

        CellObject.transform.localScale = new Vector2(CellScale.x, CellScale.y);

        GridOffset.x = -(GridSize.x / 2) + CellSize.x / 2;
        GridOffset.y = -(GridSize.y / 2) + CellSize.y / 2;

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector3 pos = new Vector3(column * CellSize.x + GridOffset.x + transform.position.x, 
                    row * CellSize.y + GridOffset.y + transform.position.y);

                GameObject CO = Instantiate(CellObject, pos, Quaternion.identity) as GameObject;

                CO.transform.parent = transform;
            }
        }

        Destroy(CellObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, GridSize);
    }

}
