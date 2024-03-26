using System;

public class AnswerChecker
{
    public Action<CellData> OnRightAnswer;
    public Action<CellData> OnWrongAnswer;
    public Action AnswerLoaded;

    public CellData RightAnswer { get; private set; }

    public void LoadAnswer(CellData rightAnswer)
    {
        RightAnswer = rightAnswer;
        AnswerLoaded?.Invoke();
    }

    public void CheckAnswer(CellData answer)
    {
        if (RightAnswer.Equals(answer))
        {
            OnRightAnswer?.Invoke(answer);
            return;
        }

        OnWrongAnswer?.Invoke(answer);
    }
}
