using System.Runtime.Serialization;

namespace DO;
[Serializable]

// למה צריך שדה 
// למה צריך מסג
//הסבר=<
//הסבר כללי
public class ExistIdException : Exception
{
	public int Id;
	public ExistIdException():base() { }
	public ExistIdException(string message) : base(message) { }
	public ExistIdException(string message, Exception inner) : base(message, inner) { }
	protected ExistIdException(SerializationInfo info,StreamingContext context) : base(info, context) { }
	public ExistIdException (string message,int id) : base(message) { Id = id; }
	public ExistIdException (int id):base()=>Id = id;
	public override string ToString() => Message + Id + "is already exist";

}

[Serializable]
public class UnfounfException:Exception
{
    //public int Id; למה פה לא שומרים
    public UnfounfException() : base() { }
    public UnfounfException(string message) : base(message) { }
    public UnfounfException(string message, Exception inner) : base(message, inner) { }
    protected UnfounfException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    
    public override string ToString() => Message +"/n";


}

