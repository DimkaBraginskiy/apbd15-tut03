namespace apbd15_tut03;

public class OverfillException : Exception
{
    public OverfillException(){ }
    public OverfillException(string messsage) : base(messsage){ }
    
    public OverfillException(string messsage, Exception inner) : base(messsage, inner) { }
}