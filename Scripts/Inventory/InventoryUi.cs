using System.Collections.Generic;
using System.Linq;
using Godot;
using LumiVerseFramework.Common;

namespace Zelda2D.Scripts.Inventory;

public partial class InventoryUi : CanvasLayer
{
    private GridContainer _gridContainer;
    private PackedScene _inventorySlotPrefab;
    [ExportGroup("背包槽位设置")] [Export] public int Size { get; set; } = 8;
    [Export] public int Column { get; set; } = 4;

    public override void _Ready()
    {
        InitNode();
        Init();
    }

    private void InitNode()
    {
        _gridContainer = GetNode<GridContainer>("%GridContainer");
        _inventorySlotPrefab =
            ResourceLoader.Load<PackedScene>(
                "res://Prefabs/UI/InventorySlot.tscn");
    }

    private void Init()
    {
        // 初始化
        YumihoshiDebug.Print<InventoryUi>("初始化", "设置列数为" + Column + "列");
        _gridContainer.Columns = Column;
        for (int i = 0; i < Size; i++)
        {
            Node inventorySlot = _inventorySlotPrefab.Instantiate();
            _gridContainer.AddChild(inventorySlot);
        }
    }

    /// <summary>
    /// 切换显示状态
    /// </summary>
    public void Trigger()
    {
        Visible = !Visible;
    }

    /// <summary>
    /// 添加物品到UI中
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(InventoryItem item)
    {
        // 获取所有空的槽位
        IEnumerable<Node> slots = _gridContainer.GetChildren()
            .Where(slot =>
            {
                InventorySlot iSlot = slot as InventorySlot;
                if (iSlot == null) return false;
                return iSlot.IsEmpty;
            });
        // 获取第一个空的槽位
        InventorySlot firstSlot = slots.First() as InventorySlot;
        firstSlot.AddItem(item);
    }

    public void UpdateStackAtSlotIndex(int stackValue, int inventorySlotIndex)
    {
        if (inventorySlotIndex == -1) return;
        InventorySlot slot =
            _gridContainer.GetChild<InventorySlot>(inventorySlotIndex);
        slot.LabelCount.Text = stackValue.ToString();
    }
}
