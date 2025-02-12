using Godot;
using LumiVerseFramework;

namespace Zelda2D.Scripts.Inventory;

public partial class InventorySlot : VBoxContainer
{
    private TextureRect _textureRect;
    private Label _labelName;
    private Label _labelCount;
    private Label _labelPrice;
    private Button _btnOnClick;
    private MenuButton _btnMenu;

    private bool _isEmpty = true;
    private bool _isSelected;
    private InventoryItem.SlotType _type = InventoryItem.SlotType.NotEquipable;

    [ExportGroup("背包物品UI槽")] [Export] private bool _singleBtnPress;
    [Export] private Texture2D _startTexture;
    [Export] private string _startLabel;

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
        _labelCount = GetNode<Label>("NinePatchRect/Label_Count");
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
        if (_startTexture != null)
        {
            _textureRect.Texture = _startTexture;
        }

        // 设置物品名称
        if (_startLabel != null)
        {
            _labelName.Text = _startLabel;
        }

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
        YumihoshiDebug.Print<InventorySlot>("UI", "详情按钮点击，id为" + id);
    }
}
