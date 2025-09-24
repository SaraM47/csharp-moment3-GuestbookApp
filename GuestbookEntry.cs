// This file will contain class for a post (owner + text)
public class GuestbookEntry
{
    // Two propertys, one stores the name of the person who wrote the entry and the other on stores the message text.
    public string Owner { get; set; }
    public string Text { get; set; }

    // The ToString() method is automatically called when we print an object that will override it.
    public override string ToString()
    {
        return $"{Owner}: {Text}";
    }
}
