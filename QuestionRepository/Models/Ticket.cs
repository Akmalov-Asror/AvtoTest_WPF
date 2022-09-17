namespace Avtoauto.Models;

public class Ticket
{
    private List<QuestionEntity> questionEntities;

    public int Index { get; set; }
    public int QuestionsCount { get; set; }
    public int CorrectAnswersCount { get; set; }
    public List<QuestionEntity> Questions { get; set; }

    public bool IsCompleted
    {
        get
        {
            return QuestionsCount == CorrectAnswersCount;
        }
    }

    public int CurrentQuestion
    {
        get
        {
            return QuestionsCount - Questions.Count;
        }
    }

    public Ticket(List<QuestionEntity> questions)
    {
        QuestionsCount = questions.Count;
        CorrectAnswersCount = 0;
        Questions = questions;
    }

    public Ticket( int index, List<QuestionEntity> questions)
    {
        QuestionsCount = questions.Count;
        CorrectAnswersCount = 0;
        Questions = questions;
        Index = index;
    }
}