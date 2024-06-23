using static AdditionalChoiceScript;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

[CustomEditor(typeof(AdditionalChoiceScript))]
public class AdditionalChoiceScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AdditionalChoiceScript choiceScript = (AdditionalChoiceScript)target;

        // Отобразить обычные поля
        DrawDefaultInspector();

        // Отобразить selectedReason только если выбрана Reputation
        if (choiceScript.ChoiceInfluenceScript == AdditionalChoiceScript.RoleOfChoiceScript.Reputation)
        {
            choiceScript.selectedReason = (ReputationDecreaseReason)EditorGUILayout.EnumPopup("Фракция", choiceScript.selectedReason);
            choiceScript.countOfReputationPoints = EditorGUILayout.IntField("Кол-во очков", choiceScript.countOfReputationPoints);
        }
    }
}