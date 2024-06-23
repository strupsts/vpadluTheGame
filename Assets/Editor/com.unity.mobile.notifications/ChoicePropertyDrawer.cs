    using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Choice))]
public class ChoicePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Получаем поле ChoiceInfluenceScript и textOfChoice
        SerializedProperty textOfChoice = property.FindPropertyRelative("textOfChoice");
        SerializedProperty choiceInfluenceScript = property.FindPropertyRelative("ChoiceInfluenceScript");

        GUIContent textOfChoiceLabel = new GUIContent("Текст выбора ----> ");
        GUIContent choiceInfluenceScriptLabel = new GUIContent("   Система: ");
        GUIContent nameOfCharactersLabel = new GUIContent("   На кого влияет: ");
        GUIContent countOfPointsLabel = new GUIContent("   Количество очков: ");
        GUIContent customScriptLabel = new GUIContent("   Особый скрипт: ");
        GUIContent quizScriptLabel = new GUIContent("   Название вик-ны: ");
       
        // Отобразим их
        Rect textOfChoiceRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(textOfChoiceRect, textOfChoice, textOfChoiceLabel);

        Rect choiceScriptRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 6, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(choiceScriptRect, choiceInfluenceScript, choiceInfluenceScriptLabel);

        // Если выбран ChoiceInfluenceScript равный Reputation
        if (choiceInfluenceScript.enumValueIndex == (int)Choice.RoleOfChoiceScript.Reputation) // Система репутации
        {
            // Получаем остальные поля
            SerializedProperty nameOfCharacter = property.FindPropertyRelative("nameOfCharacter");
            SerializedProperty countOfReputationPoints = property.FindPropertyRelative("countOfReputationPoints");

            // Отобразим их
            Rect nameOfCharacterRect = new Rect(position.x, (position.y + 2 * EditorGUIUtility.singleLineHeight) + 9, position.width, EditorGUIUtility.singleLineHeight );
            EditorGUI.PropertyField(nameOfCharacterRect, nameOfCharacter, nameOfCharactersLabel);

            Rect countOfPointsRect = new Rect(position.x, (position.y + 3 * EditorGUIUtility.singleLineHeight) + 12, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(countOfPointsRect, countOfReputationPoints, countOfPointsLabel);
        }
        else if (choiceInfluenceScript.enumValueIndex == (int)Choice.RoleOfChoiceScript.CustomScript) // Уникальный скрипт
        {
            SerializedProperty customScript = property.FindPropertyRelative("customScript");

            Rect customScriptRect = new Rect(position.x, (position.y + 2 * EditorGUIUtility.singleLineHeight) + 9, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(customScriptRect, customScript, customScriptLabel);
        }
        else if (choiceInfluenceScript.enumValueIndex == (int)Choice.RoleOfChoiceScript.Quiz)  // Викторина
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
        // Учитываем высоту дополнительных полей, если ChoiceInfluenceScript равен Reputation
        if (property.FindPropertyRelative("ChoiceInfluenceScript").enumValueIndex == (int)Choice.RoleOfChoiceScript.Reputation || property.FindPropertyRelative("ChoiceInfluenceScript").enumValueIndex == (int)Choice.RoleOfChoiceScript.Quiz)
        {
            return EditorGUIUtility.singleLineHeight * 4 + 17; // 4 - это количество полей, включая ChoiceInfluenceScript и textOfChoice
        }
        else if (property.FindPropertyRelative("ChoiceInfluenceScript").enumValueIndex == (int)Choice.RoleOfChoiceScript.CustomScript)
        {
            return EditorGUIUtility.singleLineHeight * 3 + 17; // 4 - это количество полей, включая ChoiceInfluenceScript и textOfChoice
        }


        return EditorGUIUtility.singleLineHeight * 2 + 8; // 2 - это количество полей, включая ChoiceInfluenceScript и textOfChoice
    }
}
