using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    PlayerController player;
    Inv_Inventory inventory;
    bool isActiveCheckRunning = false;

    private void OnEnable()
    {
        if (player == null)
            player = FindObjectOfType<PlayerController>();

        if (inventory == null)
            inventory = FindObjectOfType<Inv_Inventory>();

        // Перезапускаем проверку каждый раз, когда яблоко активируется
        if (!isActiveCheckRunning)
        {
            InvokeRepeating(nameof(CheckAppleInHand), 0f, 0.1f);
            isActiveCheckRunning = true;
        }
    }

    private void OnDisable()
    {
        // Останавливаем цикл при деактивации
        CancelInvoke(nameof(CheckAppleInHand));
        isActiveCheckRunning = false;
    }

    void CheckAppleInHand()
    {
        if (player == null || inventory == null) return;

        // Достаём текущее активное оружие/предмет из рук
        var itemInArmField = inventory.GetType().GetField("itemInArm",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        GameObject itemInArm = (GameObject)itemInArmField.GetValue(inventory);

        // Проверяем, действительно ли это яблоко в руках
        if (itemInArm == gameObject)
        {
            player.RestoreStamina(5f);
        }
    }
}