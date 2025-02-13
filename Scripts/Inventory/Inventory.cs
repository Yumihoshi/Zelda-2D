using System.Collections.Generic;
using Godot;
using LumiVerseFramework;

namespace Zelda2D.Scripts.Inventory;

public partial class Inventory : Node
{
    private CanvasLayerInventoryUi _inventoryUi;

    [ExportGroup("背包配置")]
    public List<InventoryItem> ItemList { get; private set; } = new();

    public override void _Ready()
    {
        _inventoryUi =
            GetNode<CanvasLayerInventoryUi>("../CanvasLayer_InventoryUI");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("OpenInventory"))
        {
            _inventoryUi.Trigger();
        }
    }

    /// <summary>
    /// 拾取物品
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void AddItem(InventoryItem item, int count)
    {
        if (count <= 0)
        {
            ItemList.Add(item);
            // TODO: 更新UI
        }
        else
        {
            int itemIndex = -1;
            // 查找物品是否已经存在
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i] != null && ItemList[i].Name == item.Name)
                {
                    itemIndex = i;
                }
            }

            // 找到物品
            if (itemIndex != -1)
            {
                InventoryItem inventoryItem = ItemList[itemIndex];
                // 检验是否可以叠加物品
                if (inventoryItem.Count + count <= inventoryItem.MaxCount)
                {
                    inventoryItem.Count += count;
                    ItemList[itemIndex] = inventoryItem;
                    // TODO: 更新UI
                }
                // 物品数量超过上限，创建新的物品
                else
                {
                    int newCount = inventoryItem.Count + count -
                                   inventoryItem.MaxCount;
                    InventoryItem newItem =
                        item.Duplicate(true) as InventoryItem;
                    inventoryItem.Count = inventoryItem.MaxCount;
                    // TODO: 更新UI
                    if (newItem != null) newItem.Count = newCount;
                    else
                    {
                        YumihoshiDebug.Error<Inventory>("背包",
                            "物品数量超过上限，创建新的物品失败，复制时为空");
                    }

                    ItemList.Add(newItem);
                    // TODO: 更新UI
                }
            }
            // 没有找到物品，创建新的物品
            else
            {
                item.Count = count;
                ItemList.Add(item);
                // TODO: 更新UI
            }
        }

        YumihoshiDebug.Print<Inventory>("背包", "当前物品数量：" + item.Count);
    }
}
