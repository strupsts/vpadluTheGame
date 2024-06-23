/*using static UnityEngine.GraphicsBuffer;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChoiceTrigger))]
public class ChoiceTriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ChoiceTrigger choiceTrigger = (ChoiceTrigger)target;

        // Отобразить обычные поля

        DrawDefaultInspector();

        serializedObject.Update();
        SerializedProperty listOfChoices = serializedObject.FindProperty("ChoiceInfo");
        EditorGUILayout.PropertyField(listOfChoices, true); // true для отображения дочерних элементов
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Добавить выбор"))
        {
            choiceTrigger.ChoiceInfo.listOfChoices.Add(new Choice());
        }

        if (choiceTrigger.ChoiceInfo != null && choiceTrigger.ChoiceInfo.listOfChoices != null)
        {
            for (int i = 0; i < choiceTrigger.ChoiceInfo.listOfChoices.Count; i++)
            {
                EditorGUILayout.LabelField("Choice " + i, EditorStyles.boldLabel);
                choiceTrigger.ChoiceInfo.listOfChoices[i].textOfChoice = EditorGUILayout.TextField("Text of Choice", choiceTrigger.ChoiceInfo.listOfChoices[i].textOfChoice);
                choiceTrigger.ChoiceInfo.listOfChoices[i].ChoiceInfluenceScript = (Choice.RoleOfChoiceScript)EditorGUILayout.EnumPopup("Role Of Choice Script", choiceTrigger.ChoiceInfo.listOfChoices[i].ChoiceInfluenceScript);

                // Проверяем, является ли ChoiceInfluenceScript равным Reputation
                if (choiceTrigger.ChoiceInfo.listOfChoices[i].ChoiceInfluenceScript == Choice.RoleOfChoiceScript.Reputation)
                {
                    choiceTrigger.ChoiceInfo.listOfChoices[i].selectedReason = (Choice.ReputationDecreaseReason)EditorGUILayout.EnumPopup("Reputation Decrease Reason", choiceTrigger.ChoiceInfo.listOfChoices[i].selectedReason);
                    choiceTrigger.ChoiceInfo.listOfChoices[i].countOfReputationPoints = EditorGUILayout.IntField("Count of Reputation Points", choiceTrigger.ChoiceInfo.listOfChoices[i].countOfReputationPoints);
                }
            }
        }
    }
}
*/