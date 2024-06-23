    using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Choice))]
public class ChoicePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // �������� ���� ChoiceInfluenceScript � textOfChoice
        SerializedProperty textOfChoice = property.FindPropertyRelative("textOfChoice");
        SerializedProperty choiceInfluenceScript = property.FindPropertyRelative("ChoiceInfluenceScript");

        GUIContent textOfChoiceLabel = new GUIContent("����� ������ ----> ");
        GUIContent choiceInfluenceScriptLabel = new GUIContent("   �������: ");
        GUIContent nameOfCharactersLabel = new GUIContent("   �� ���� ������: ");
        GUIContent countOfPointsLabel = new GUIContent("   ���������� �����: ");
        GUIContent customScriptLabel = new GUIContent("   ������ ������: ");
        GUIContent quizScriptLabel = new GUIContent("   �������� ���-��: ");
       
        // ��������� ��
        Rect textOfChoiceRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(textOfChoiceRect, textOfChoice, textOfChoiceLabel);

        Rect choiceScriptRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 6, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(choiceScriptRect, choiceInfluenceScript, choiceInfluenceScriptLabel);

        // ���� ������ ChoiceInfluenceScript ������ Reputation
        if (choiceInfluenceScript.enumValueIndex == (int)Choice.RoleOfChoiceScript.Reputation) // ������� ���������
        {
            // �������� ��������� ����
            SerializedProperty nameOfCharacter = property.FindPropertyRelative("nameOfCharacter");
            SerializedProperty countOfReputationPoints = property.FindPropertyRelative("countOfReputationPoints");

            // ��������� ��
            Rect nameOfCharacterRect = new Rect(position.x, (position.y + 2 * EditorGUIUtility.singleLineHeight) + 9, position.width, EditorGUIUtility.singleLineHeight );
            EditorGUI.PropertyField(nameOfCharacterRect, nameOfCharacter, nameOfCharactersLabel);

            Rect countOfPointsRect = new Rect(position.x, (position.y + 3 * EditorGUIUtility.singleLineHeight) + 12, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(countOfPointsRect, countOfReputationPoints, countOfPointsLabel);
        }
        else if (choiceInfluenceScript.enumValueIndex == (int)Choice.RoleOfChoiceScript.CustomScript) // ���������� ������
        {
            SerializedProperty customScript = property.FindPropertyRelative("customScript");

            Rect customScriptRect = new Rect(position.x, (position.y + 2 * EditorGUIUtility.singleLineHeight) + 9, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(customScriptRect, customScript, customScriptLabel);
        }
        else if (choiceInfluenceScript.enumValueIndex == (int)Choice.RoleOfChoiceScript.Quiz)  // ���������
        {
            SerializedProperty quizNames = property.FindPropertyRelative("quizNames");
            SerializedProperty countOfQuizPoints = property.FindPropertyRelative("countOfQuizPoints");

           
            Rect quizNamesRect = new Rect(position.x, (position.y + 2 * EditorGUIUtility.singleLineHeight) + 9, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(quizNamesRect, quizNames, quizScriptLabel);

            Rect countOfPointsRect = new Rect(position.x, (position.y + 3 * EditorGUIUtility.singleLineHeight) + 12, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(countOfPointsRect, countOfQuizPoints, countOfPointsLabel);
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // ��������� ������ �������������� �����, ���� ChoiceInfluenceScript ����� Reputation
        if (property.FindPropertyRelative("ChoiceInfluenceScript").enumValueIndex == (int)Choice.RoleOfChoiceScript.Reputation || property.FindPropertyRelative("ChoiceInfluenceScript").enumValueIndex == (int)Choice.RoleOfChoiceScript.Quiz)
        {
            return EditorGUIUtility.singleLineHeight * 4 + 17; // 4 - ��� ���������� �����, ������� ChoiceInfluenceScript � textOfChoice
        }
        else if (property.FindPropertyRelative("ChoiceInfluenceScript").enumValueIndex == (int)Choice.RoleOfChoiceScript.CustomScript)
        {
            return EditorGUIUtility.singleLineHeight * 3 + 17; // 4 - ��� ���������� �����, ������� ChoiceInfluenceScript � textOfChoice
        }


        return EditorGUIUtility.singleLineHeight * 2 + 8; // 2 - ��� ���������� �����, ������� ChoiceInfluenceScript � textOfChoice
    }
}
