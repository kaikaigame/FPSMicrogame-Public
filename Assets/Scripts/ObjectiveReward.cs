using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

public class ObjectiveReward : MonoBehaviour
{
    public RewardType rewardType;
    [Range(0f, 3f)]
    public float increaseRatio;
    [Range(0f, 1f)]
    public float decreaseRatio;
    [Range(0f, 10f)]
    public int increaseAmmo;

    GameObject player;
    WeaponController weapon;

    public void ApplyReward()
    {
        player = GameObject.Find("Player");
        weapon = player.GetComponent<PlayerWeaponsManager>().WeaponParentSocket.
            GetComponentInChildren<WeaponController>();

        switch (rewardType)
        {
            case RewardType.maxHealth:
                {
                    player.GetComponent<Health>().MaxHealth *= (1 + increaseRatio);
                }
                break;
            case RewardType.maxAmmo:
                {
                    weapon.MaxAmmo *= (1 + increaseAmmo);
                }
                break;
            case RewardType.armor:
                {
                    player.GetComponent<Damageable>().DamageMultiplier *= (1 - decreaseRatio);
                }
                break;
            case RewardType.reloadDelay:
                {
                    weapon.AmmoReloadDelay *= (1 - decreaseRatio);
                }
                break;
            default:
                break;
        }
    }
}

public enum RewardType
{
    maxHealth, maxAmmo, armor, reloadDelay
};

