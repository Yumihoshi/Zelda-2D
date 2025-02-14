using System;
using System.Text.RegularExpressions;
using Godot;
using LumiVerseFramework.Common;

namespace Zelda2D.Scripts.Inventory;

public partial class InventorySlot : VBoxContainer
{
    private MenuButton _btnMenu;
    private Button _btnOnClick;
    private bool _isSelected;
    private Label _labelName;
    private Label _labelPrice;

    [Signal]
    public delegate void EquipEventHandler(InventoryItem.SlotType slotType);

    [ExportGroup("背包物品UI槽")] [Export] private bool _singleBtnPress;
    [Export] private string _startLabel;
    [Export] private Texture2D _startTexture;

    private TextureRect _textureRect;
    private InventoryItem.SlotType _type = InventoryItem.SlotType.NotEquipable;
    public Label LabelCount { get; private set; }
    public bool IsEmpty { get; set; } = true;

    public override void _Ready()
    {
        InitNode();
        InitProperty();
        InitSignal();
    }

    /// <summary>
    /// 初始化节点
    /// </summary>
    private void InitNode()
    {
        _textureRect =
            GetNode<TextureRect>(
                "NinePatchRect/MenuButton/CenterContainer/TextureRect");
        _labelName = GetNode<Label>("Label_Name");
        LabelCount = GetNode<Label>("NinePatchRect/Label_Count");
        _btnOnClick = GetNode<Button>("NinePatchRect/Button_OnClick");
        _labelPrice = GetNode<Label>("Label_Price");
        _btnMenu = GetNode<MenuButton>("NinePatchRect/MenuButton");
    }

    /// <summary>
    /// 初始化节点属性
    /// </summary>
    private void InitProperty()
    {
        // 设置物品贴图
        if (_startTexture != null) _textureRect.Texture = _startTexture;

        // 设置物品名称
        if (_startLabel != null) _labelName.Text = _startLabel;

        // 设置按钮状态
        _btnMenu.Disabled = _singleBtnPress;
        _btnOnClick.Disabled = !_singleBtnPress;
        _btnOnClick.Visible = _singleBtnPress;
    }

    /// <summary>
    /// 初始化信号连接
    /// </summary>
    private void InitSignal()
    {
        PopupMenu popupMenu = _btnMenu.GetPopup();
        popupMenu.IdPressed += OnPopupMenuIdPressed;
    }

    /// <summary>
    /// 详情按钮点击事件
    /// </summary>
    /// <param name="id"></param>
    private void OnPopupMenuIdPressed(long id)
    {
        switch (id)
        {
            case 0:
                // 装备
                if (_type != InventoryItem.SlotType.NotEquipable)
                {
                    EmitSignal("EquipEventHandler", (Variant)_type);
                }
                break;
            case 1:
                // 丢弃
                YumihoshiDebug.Print<InventorySlot>("背包UI", "丢弃物品");
                break;
            default:
                YumihoshiDebug.Error<InventorySlot>("背包UI", "子菜单按钮ID错误");
                return;
        }
    }

    public void AddItem(InventoryItem item)
    {
        // 可装备物品右键菜单
        if (item.Type != InventoryItem.SlotType.NotEquipable)
        {
            PopupMenu popupMenu = _btnMenu.GetPopup();
            string equipMenuName = item.Type.ToString();
            equipMenuName =
                Regex.Replace(equipMenuName, @"([A-Z])", " $1").Trim();
            equipMenuName = $"装备到{equipMenuName}";
            popupMenu.SetItemText(0, equipMenuName);
        }

        // 设置物品信息
        IsEmpty = false;
        _btnMenu.Disabled = false;
        _textureRect.Texture = item.Texture;
        _labelName.Text = item.Name;
        // 物品数量大于1时显示
        if (item.Count > 1) LabelCount.Text = item.Count.ToString();
    }
}
