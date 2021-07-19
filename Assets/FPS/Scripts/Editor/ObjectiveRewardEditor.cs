using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectiveReward))]
public class ObjectiveRewardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObjectiveReward t = target as ObjectiveReward;

        //隐藏多余部分
        if (t.rewardType == RewardType.maxHealth)
        {
            t.increaseRatio = EditorGUILayout.FloatField("IncreaseRatio", t.increaseRatio);
        }

        if (t.rewardType == RewardType.maxAmmo)
        {
            t.increaseAmmo = EditorGUILayout.IntField("IncreaseAmmo", t.increaseAmmo);
        }

        if (t.rewardType == RewardType.armor || t.rewardType == RewardType.reloadDelay)
        {
            t.increaseRatio = EditorGUILayout.FloatField("DecreaseRatio", t.decreaseRatio);
        }

        if (t.rewardType == RewardType.destroyObject)
        {
            t.destroyObject = (GameObject)EditorGUILayout.ObjectField
                ("DestroyObject", t.destroyObject, typeof(GameObject), true);
        }
    }
}
