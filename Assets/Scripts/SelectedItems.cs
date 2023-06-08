using UnityEngine;

public static class SelectedItems
{
    public static ItemData selectedItem;

    public static void SetSelectedItem(ItemData item)
    {
        selectedItem = item;
    }
}
