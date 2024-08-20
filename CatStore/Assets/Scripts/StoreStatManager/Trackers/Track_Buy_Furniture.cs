using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Track_Buy_Furniture : MonoBehaviour
{
    public List<Furniture> FurnitureList;
    public List<GameObject> Furniture_options;
    private List<Sprite> furniture_images = new List<Sprite>();
    private List<Image> furniture_slots = new List<Image>();
    private List<TextMeshProUGUI> furniture_count = new List<TextMeshProUGUI>();
    private List<Button> buy_furniture_buttons = new List<Button>();

    private Grid PlacementGrid;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var furniture in FurnitureList)
        {
            furniture_images.Add(furniture.Furniture_Image);
        }

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            furniture_slots.Add(transform.GetChild(i).GetComponent<Image>());
            furniture_slots[i].sprite = furniture_images[i];
            furniture_count.Add(transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>());
            furniture_count[i].text = "$" + FurnitureList[i].Furniture_BuyValue;
            buy_furniture_buttons.Add(transform.GetChild(i).GetChild(1).GetComponent<Button>());
            //Debug.Log(i);
        }

        PlacementGrid = FindAnyObjectByType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < Furniture_options.Count; i++)
        {
            if (StoreStats.store_Money < FurnitureList[i].Furniture_BuyValue)
            {
                buy_furniture_buttons[i].interactable = false;
            }
            else
            {
                buy_furniture_buttons[i].interactable = true;
            }
        }
    }

    public void buyFurniture(int furniture_index)
    {
        GameObject g;
        Vector3 Camerapos = Camera.main.transform.position;
        Vector3 gridPos = PlacementGrid.LocalToCell(Camerapos);

        g = Instantiate(Furniture_options[furniture_index], gridPos, Quaternion.identity);

        StoreStats.store_Money -= FurnitureList[furniture_index].Furniture_BuyValue;
    }
}
