public class Words
{
    private string _word;
    private bool _isHidden = false;

    public string GetWord()
    {
        return _word;
    }
    public void SetWord(string word)
    {
        _word= word;
    }
    public bool GetisHidden()
    {
        return _isHidden;
    }
    public void SetisHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }
}