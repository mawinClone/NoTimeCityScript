using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance;

    List<Question> mainQuestion;
    public List<Question> gameQuestion;
    public List<Question> artQuestion;
    public List<Question> bankQuestion;
    public List<Question> camQuestion;

    public GameObject questPanel;
    public GameObject cerPanel;
    Animator questAnim;
    public TextMeshProUGUI topic;
    int topicOrder = 0;
    int totalCorrect = 0;
    public List<TextMeshProUGUI> choiceList;

    public Image isCorrectImg;
    public Sprite correct;
    public Sprite incorrect;

    bool isSelected = false;

    public Sprite bankSP;
    public Sprite artSP;
    public Sprite camSP;
    public Sprite gameSP;
    public Image quizIMG;


    QuestSelected questSelected;
    public enum QuestSelected
    {
        GameQuest,
        ArtQuest,
        BankQuest,
        CamQuest
    }
    
    [Serializable]
    public struct Question
    {
        public string topic;
        public int correctChoice;
        public List<string> choice;
    }

    private void Awake() {
        Instance = this;
    }



    void Start()
    {
        isCorrectImg.enabled = false;
        mainQuestion = gameQuestion;
        questAnim = questPanel.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void SetQuesttion(QuestSelected set)
    {
        topicOrder = 0;
        totalCorrect = 0;
        // mainQuestion = gameQuestion;
        switch(set)
        {
            case QuestSelected.GameQuest : mainQuestion = gameQuestion;
                questSelected = QuestSelected.GameQuest;
                quizIMG.sprite = gameSP;
                break;
            case QuestSelected.ArtQuest : mainQuestion = artQuestion;
                questSelected = QuestSelected.ArtQuest;
                quizIMG.sprite = artSP;
                break;
            case QuestSelected.BankQuest : mainQuestion = bankQuestion;
                questSelected = QuestSelected.BankQuest;
                quizIMG.sprite = bankSP;
                break;
            case QuestSelected.CamQuest : mainQuestion = camQuestion;
                questSelected = QuestSelected.CamQuest;
                quizIMG.sprite = camSP;
                break;
            default : break;
        }

        topic.text = mainQuestion[topicOrder].topic;
        
        for(int i=0; i<3 ; i++)
        {
            choiceList[i].text = mainQuestion[topicOrder].choice[i];
        }


        questPanel.SetActive(true);
    }

    public void NextQuestion()
    {
        isCorrectImg.enabled = false;
        isSelected = false;
        topic.text = mainQuestion[topicOrder].topic;
        
        for(int i=0; i<3 ; i++)
        {
            choiceList[i].text = mainQuestion[topicOrder].choice[i];
        }
    }

    public void SelectChoice(int set)
    {
        
        if(!isSelected)
        {
            isSelected = true;
            if(set == mainQuestion[topicOrder].correctChoice)
            {
                totalCorrect++;
                isCorrectImg.enabled = true;
                isCorrectImg.sprite = correct;
                AudioController.Instance.CorrectSound();
            }else{
                isCorrectImg.enabled = true;
                isCorrectImg.sprite = incorrect;
                AudioController.Instance.WrongSound();
            }

            topicOrder++;
        
            if(totalCorrect >= 3 && topicOrder >= 5)
            {
                Debug.Log("Pass");
                // QuestSuccess();
                StartCoroutine(QuestSuccessIE());
            }else if(totalCorrect < 3 && topicOrder >= 5){
                Debug.Log("Fail");
                // QuestFail();
                StartCoroutine(QuestFailIE());
            }

            if(topicOrder<5)
            {
                // NextQuestion();
                StartCoroutine(NextQuestionIE());
            }else{
                topicOrder = 0;
                // StartCoroutine(EndQuestionIE());
            }
        }
        
    }
    IEnumerator EndQuestionIE()
    {
        yield return new WaitForSeconds(1);
        isCorrectImg.enabled = false;
        isSelected = false;
        questPanel.SetActive(false);
    }

    IEnumerator NextQuestionIE()
    {
        yield return new WaitForSeconds(1);
        isCorrectImg.enabled = false;
        isSelected = false;
        NextQuestion();
    }

    IEnumerator QuestSuccessIE()
    {
        yield return new WaitForSeconds(1);
        questPanel.SetActive(false);
        isCorrectImg.enabled = false;
        isSelected = false;
        QuestSuccess();
    }
    IEnumerator QuestFailIE()
    {
        yield return new WaitForSeconds(1);
        questPanel.SetActive(false);
        isCorrectImg.enabled = false;
        isSelected = false;
        QuestFail();
    }



    public void QuestSuccess()
    {
        isCorrectImg.enabled = false;
        isSelected = false;
        switch(questSelected)
        {
            case QuestSelected.GameQuest : GameController.Instance.playerNow.cerGameCenter = true;
                break;
            case QuestSelected.ArtQuest : GameController.Instance.playerNow.cerArt = true;
                break;
            case QuestSelected.BankQuest : GameController.Instance.playerNow.cerBank = true;
                break;
            case QuestSelected.CamQuest : GameController.Instance.playerNow.cerCamera = true;
                break;
            default : break;
        }
        
        StartCoroutine(Pass());
    }

    public IEnumerator Pass()
    {
        cerPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        cerPanel.SetActive(false);
        GameController.Instance.EndTurn();
    }

    public void QuestFail()
    {
        isCorrectImg.enabled = false;
        isSelected = false;
        GameController.Instance.EndTurn();
    }


}