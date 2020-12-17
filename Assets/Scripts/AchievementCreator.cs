using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCreator : MonoBehaviour
{
    [SerializeField]
    GameObject inputName, inputDescription, inputRepetitions, inputReward, inputNumerOf;

    [SerializeField]
    GameObject labelAdjective, labelSingular, labelPlural;

    [SerializeField]
    Transform asterisks;

    public TypeDatabase _typeDBInstance;

    int    achievementIcon;
    string achievementName;
    string achievementDescription;
    int    achievementRepetitions;
    int    achievementNumberOf;
    int    achievementType;
    string achievementAward;
    bool   canConfirm;

    Text textAdjective, textSingular, textPlural;

    private void Start()
    {
        canConfirm = true;
        achievementType = 1; //Semanal por defecto
        textAdjective = labelAdjective.GetComponent<Text>();
        textSingular = labelSingular.GetComponent<Text>();
        textPlural = labelPlural.GetComponent<Text>();
    }
    public void StoreValues()
    {
        DisableAsterisks();
        canConfirm = true; 

        achievementName        = CheckNullString(inputName.GetComponent<InputField>().text);
        achievementDescription = CheckNullString(inputDescription.GetComponent<InputField>().text);

        achievementRepetitions = CheckNullInt(inputRepetitions.GetComponent<InputField>().text);
        achievementNumberOf    = CheckNullInt(inputNumerOf.GetComponent<InputField>().text);

        achievementAward       = CheckNullUndefined(inputReward.GetComponent<InputField>().text);
        achievementIcon        = IconManager._instance.GetIconID();

        if (canConfirm)
        {
            CanvasManager._instance.ShowMainHideCreation();
            AchievementManager._instance.NewAchievement(achievementName, achievementDescription, achievementIcon);
            AchievementManager._instance.SaveAchievements();
        }
        else
        {
            CheckAsterisk();
        }
    }

    private int CheckNullInt(string text)
    {
        int res = -1;

        if(text != "" && int.Parse(text) > 0)
        {
            res = int.Parse(text);
        }
        else
        {
            canConfirm = false;
        }

        return res;
    }

    private string CheckNullString(string text)
    {
        if (text != "")
        {
            return text;
        }
        else
        {
            canConfirm = false;
            return null;
        }
    }

    private string CheckNullUndefined(string text)
    {
        if (text != "")
        {
            return text;
        }
        else
        {
           return "Sin definir";
        }
    }

    private void CheckAsterisk()
    {
        if(achievementName == null)
        {
            asterisks.GetChild(0).gameObject.SetActive(true);
        }

        if(achievementDescription == null)
        {
            asterisks.GetChild(1).gameObject.SetActive(true);
        }

        if(achievementRepetitions < 1)
        {
            asterisks.GetChild(2).gameObject.SetActive(true);
        }

        if (achievementNumberOf < 1)
        {
            asterisks.GetChild(3).gameObject.SetActive(true);
        }
    }

    private void DisableAsterisks()
    {
        for(int i = 0; i < asterisks.childCount; i++)
        {
            asterisks.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SetType(int i)
    {
        achievementType = i;

        inputNumerOf.GetComponent<InputField>().text = null;
        inputRepetitions.GetComponent<InputField>().text = null;

        textAdjective.text = _typeDBInstance.types[i].adjetivo;
        textSingular.text  = "Repeticiones por " + _typeDBInstance.types[i].singular;
        textPlural.text    = "Número de " + _typeDBInstance.types[i].plural;

        inputRepetitions.transform.GetChild(1).gameObject.GetComponent<Text>().text = _typeDBInstance.types[i].defaultRepetitions.ToString();
        inputNumerOf.transform.GetChild(1).gameObject.GetComponent<Text>().text = _typeDBInstance.types[i].defaultNumberOf.ToString();

        inputRepetitions.GetComponent<InputField>().characterLimit = _typeDBInstance.types[i].maxRepetitionsCaracter;
        inputNumerOf.GetComponent<InputField>().characterLimit = _typeDBInstance.types[i].maxNumberOfCaracter;
    }

    public void CheckTypeValues()
    {
        if (inputRepetitions.GetComponent<InputField>().text != "" && int.Parse(inputRepetitions.GetComponent<InputField>().text) > _typeDBInstance.types[achievementType].maxRepetitions)
        {
            inputRepetitions.GetComponent<InputField>().text = _typeDBInstance.types[achievementType].maxRepetitions.ToString();
        }

        if (inputNumerOf.GetComponent<InputField>().text != "" && int.Parse(inputNumerOf.GetComponent<InputField>().text) > _typeDBInstance.types[achievementType].maxNumberOf)
        {
            inputNumerOf.GetComponent<InputField>().text = _typeDBInstance.types[achievementType].maxNumberOf.ToString();
        }
    }

    private void OnEnable()
    {
        canConfirm = true;
        inputName.GetComponent<InputField>().text = null;
        inputDescription.GetComponent<InputField>().text = null;
        inputNumerOf.GetComponent<InputField>().text = null;
        inputRepetitions.GetComponent<InputField>().text = null;
        inputReward.GetComponent<InputField>().text = null;
    }




}
