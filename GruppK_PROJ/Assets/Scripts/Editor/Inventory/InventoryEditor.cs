using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    private bool[] showItemSlots = new bool[Inventory.numItemSlots];
    private SerializedProperty itemImagesProperty;
    private SerializedProperty itemsProperty;
    private SerializedProperty itemSlotProperty;
    private SerializedProperty highlightImagesProperty;
    private SerializedProperty staffObjectProperty;



    private const string inventoryPropItemImagesName = "itemImages";
    private const string inventoryPropItemsName = "items";
    private const string inventoryPropItemSlotName = "itemSlots";
    private const string inventoryPropHighlightImagesName = "highlightImages";
    private const string inventoryPropStaffObjectName = "staffItem";

    private void OnEnable ()
    {
        itemImagesProperty = serializedObject.FindProperty (inventoryPropItemImagesName);
        itemsProperty = serializedObject.FindProperty (inventoryPropItemsName);
        itemSlotProperty = serializedObject.FindProperty(inventoryPropItemSlotName);
        highlightImagesProperty = serializedObject.FindProperty(inventoryPropHighlightImagesName);
        staffObjectProperty = serializedObject.FindProperty(inventoryPropStaffObjectName);
    }


    public override void OnInspectorGUI ()
    {
        serializedObject.Update ();
        EditorGUILayout.PropertyField(staffObjectProperty);
        for (int i = 0; i < Inventory.numItemSlots; i++)
        {
            ItemSlotGUI (i);
        }

        serializedObject.ApplyModifiedProperties ();
    }


    private void ItemSlotGUI (int index)
    {
        EditorGUILayout.BeginVertical (GUI.skin.box);
        EditorGUI.indentLevel++;
        
        showItemSlots[index] = EditorGUILayout.Foldout (showItemSlots[index], "Item slot " + index);

        if (showItemSlots[index])
        {
            EditorGUILayout.PropertyField (itemImagesProperty.GetArrayElementAtIndex (index));
            EditorGUILayout.PropertyField (itemsProperty.GetArrayElementAtIndex (index));
            EditorGUILayout.PropertyField (itemSlotProperty.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField (highlightImagesProperty.GetArrayElementAtIndex(index));
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical ();
    }
}
