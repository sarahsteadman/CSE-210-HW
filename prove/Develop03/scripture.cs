public class Scripture
{
    private Reference _reference;
    private List<Words> _words;
    private String _text;

    private Reference GetReference()
    {
        return _reference;
    }
    public void SetReference(Reference reference)
    {
        _reference = reference;
    }

    private string GetText()
    {
        return _text;
    }
    public void SetText(string text)
    {
        _text = text;
        SetWords();
    }

    private List<Words> GetWords()
    {
        return _words;
    }
    private void SetWords()
    {
        _words = new List<Words>();
        string[] splitText = _text.Split(" ");
        foreach (string piece in splitText)
        {
            Words word = new Words();
            word.SetWord(piece);

            _words.Add(word);
        }

    }

    public void DisplayScripture()
    {
        Console.WriteLine(_reference.FormatReference());
        Console.WriteLine(_text);
    }

    public void HideWord()
    {
        int randomIndex = 0;
        string end = "";
        do
        {
            var random = new Random();
            randomIndex = random.Next(_words.Count);
            end = StillGoing();
            if (end == "quit")
            {
                break;
            }
        } while (_words[randomIndex].GetisHidden());

        if (end != "quit")
        {
            Words disappearingWord = _words[randomIndex];
            disappearingWord.SetisHidden(true);
            string hiddenword = "";

            foreach (char letter in disappearingWord.GetWord())
            {
                hiddenword += "_";
            }

            _words[randomIndex].SetWord(hiddenword);
            _text = "";

            foreach (Words word in _words)
            {
                _text += word.GetWord() + " ";
            }
        }
    }

    public string StillGoing()
    {
        string end = "quit";
        foreach (Words word in _words)
        {
            if (word.GetisHidden() == false)
            {
                end = "";
            }
        }
        return end;
    }
}
