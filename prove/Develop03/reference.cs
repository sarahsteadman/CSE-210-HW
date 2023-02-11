public class Reference
{
    private string _book;
    private int _chapter;
    private string _firstVerse;
    private string _lastVerse;

    public string GetBook()
    {
        return _book;
    }
    public void SetBook(string book)
    {
        _book = book;
    }
    public int GetChapter()
    {
        return _chapter;
    }
    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }
    public string GetfirstVerse()
    {
        return _firstVerse;
    }
    public void SetfirstVerse(string firstVerse)
    {
        _firstVerse = firstVerse;
    }
    public string GetLastVerse()
    {
        return _lastVerse;
    }
    public void SetLastVerse(string lastVerse)
    {
        _lastVerse = lastVerse;
    }
    public string FormatReference()
    {
        string formattedReference = $"{_book} {_chapter}: {_firstVerse}-{_lastVerse} ";

        return formattedReference;
    }

}