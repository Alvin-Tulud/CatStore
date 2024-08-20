using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFurnitureMode : MonoBehaviour
{
    private bool deletingFurniture;
    public GameObject SpawnDeleteSelect;
    private GameObject DeleteSelect = null;
    private Grid PlacementGrid;

    [SerializeField]
    private LayerMask OtherObjectMask;

    // Start is called before the first frame update
    void Start()
    {
        deletingFurniture = false;
        PlacementGrid = FindAnyObjectByType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deletingFurniture)
        {
            deletemode();
        }
        else
        {
            if (DeleteSelect != null)
            {
                Destroy(DeleteSelect);
            }
        }
    }

    public void deletingfurnituretoggle()
    {
        deletingFurniture = !deletingFurniture;
    }

    private void deletemode()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gridPos = PlacementGrid.LocalToCell(mousePos);

        if (DeleteSelect == null)
        {
            GameObject g;
            g = Instantiate(SpawnDeleteSelect);
            DeleteSelect = g;
        }

        DeleteSelect.transform.position = gridPos;

        if (Physics2D.OverlapPoint(DeleteSelect.transform.position, OtherObjectMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D furniture = Physics2D.OverlapPoint(DeleteSelect.transform.position, OtherObjectMask);

                StoreStats.store_Money += furniture.GetComponent<Furniture_Data>().furniture.Furniture_BuyValue;
                Destroy(furniture.gameObject);
            }
        }
    }
}
