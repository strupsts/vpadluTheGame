using static AdditionalChoiceScript;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

[CustomEditor(typeof(AdditionalChoiceScript))]
public class AdditionalChoiceScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AdditionalChoiceScript choiceScript = (AdditionalChoiceScript)target;

        // ���������� ������� ����
        DrawDefaultInspector();

        // ���������� selectedReason ������ ���� ������� Reputation
        if (choiceScript.ChoiceInfluenceScript == AdditionalChoiceScript.RoleOfChoiceScript.Reputation)
        {
            choiceScript.selectedReason = (ReputationDecreaseReason)EditorGUILayout.EnumPopup("�������", choiceScript.selectedReason);
            choiceScript.countOfReputationPoints = EditorGUILayout.IntField("���-�� �����", choiceScript.countOfReputationPoints);
        }
    }
}