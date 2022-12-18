using System.Runtime.Serialization;

namespace BO;
[Serializable]

// למה צריך שדה 
// למה צריך מסג
//הסבר=<
//הסבר כללי
public class NotFoundException : Exception
{
    public int Id;
    public NotFoundException() : base() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception inner) : base(message, inner) { }
    public NotFoundException(string message, DO.UnfounfException inner) : base(message, inner) { }
    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public NotFoundException(string message, int id) : base(message) { Id = id; }
    public NotFoundException(int id) : base() => Id = id;
    public override string ToString() => Message + Id + "is already exist";

}

public class InValidIdException : Exception
{
    public int Id;
    public InValidIdException() : base() { }
    public InValidIdException(string message) : base(message) { }
    public InValidIdException(string message, Exception inner) : base(message, inner) { }
    protected InValidIdException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public InValidIdException(string message, int id) : base(message) { Id = id; }
    public InValidIdException(int id) : base() => Id = id;
    public override string ToString() => Message + Id + "is already exist";

}


public class IdExistException : Exception
{
    public int Id;
    public IdExistException() : base() { }
    public IdExistException(string message) : base(message) { }
    public IdExistException(string message, Exception inner) : base(message, inner) { }
    public IdExistException(string message, DO.ExistIdException inner) : base(message, inner) { }
    protected IdExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public IdExistException(string message, int id) : base(message) { Id = id; }
    public IdExistException(int id) : base() => Id = id;
    public override string ToString() => Message + Id + "is already exist";

}