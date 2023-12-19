using System;

namespace ExcecaoDLL
{
    public class InvalidDataException : ApplicationException
    {
        public InvalidDataException() : base(string.Format("Dados inválidos"))
        {
            throw new InvalidDataException();
        }
        public InvalidDataException(string message) : base(string.Format("Dados inválidos; Mensagem: {0}", message)) 
        {
            throw new InvalidDataException(this.Message + " - " + message);
        }
        public InvalidDataException(string message, Exception inner) : base(string.Format("Dados inválidos; Mensagem: {0}", message), inner) 
        {
            throw new InvalidDataException(inner.Message+ " - " + message, inner);
        }
    }

    public class InvalidNameException : ApplicationException
    {
        public InvalidNameException() : base(string.Format("Nome inválido"))
        {
            throw new InvalidNameException();
        }
        public InvalidNameException(string name) : base(string.Format("Nome inválido: {0}", name))
        {
            throw new InvalidNameException(this.Message + " - " + name);
        }
        public InvalidNameException(string name, Exception inner) : base(string.Format("Nome inválido: {0}", name), inner)
        {
            throw new InvalidNameException(inner.Message + " - " + name, inner);
        }
    }
    public class InvalidDateException : ApplicationException
    {
        public InvalidDateException() : base(string.Format("Data inválida"))
        {
            throw new InvalidDateException();
        }
        public InvalidDateException(string date) : base(string.Format("Data inválida: {0}", date))
        {
            throw new InvalidDateException(this.Message + " - " + date);
        }
        public InvalidDateException(string date, Exception inner) : base(string.Format("Data inválida: {0}", date), inner)
        {
            throw new InvalidDateException(inner.Message + " - " + date, inner);
        }
    }
    public class InvalidNumberException : ApplicationException
    {
        public InvalidNumberException() : base(string.Format("Número inválido"))
        {
            throw new InvalidNumberException();
        }
        public InvalidNumberException(string number) : base(string.Format("Número inválido: {0}", number))
        {
            throw new InvalidNumberException(this.Message + " - " + number);
        }
        public InvalidNumberException(string number, Exception inner) : base(string.Format("Número inválido: {0}", number), inner)
        {
            throw new InvalidNumberException(inner.Message + " - " + number, inner);
        }
    }
    public class InvalidTypeException : ApplicationException
    {
        public InvalidTypeException() : base(string.Format("Tipo inválido"))
        {
            throw new InvalidTypeException();
        }
        public InvalidTypeException(string message) : base(string.Format("Tipo inválido; Mensagem: {0}", message))
        {
            throw new InvalidTypeException(this.Message + " - " + message);
        }
        public InvalidTypeException(string message, Exception inner) : base(string.Format("Tipo inválido; Mensagem: {0}", message), inner)
        {
            throw new InvalidTypeException(inner.Message + " - " + message, inner);
        }
    }
    public class InvalidGenderException : ApplicationException
    {
        public InvalidGenderException() : base(string.Format("Sexo inválido"))
        {
            throw new InvalidGenderException();
        }
        public InvalidGenderException(string gender) : base(string.Format("Sexo inválido: {0}", gender))
        {
            throw new InvalidGenderException(this.Message + " - " + gender);
        }
        public InvalidGenderException(string gender, Exception inner) : base(string.Format("Sexo inválido: {0}", gender), inner)
        {
            throw new InvalidGenderException(inner.Message + " - " + gender, inner);
        }
    }
    public class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException() : base(string.Format("Número não pode ser negativo"))
        {
            throw new NegativeNumberException();
        }
        public NegativeNumberException(string number) : base(string.Format("Número não pode ser negativo: {0}", number))
        {
            throw new NegativeNumberException(this.Message + " - " + number);
        }
        public NegativeNumberException(string number, Exception inner) : base(string.Format("Número não pode ser negativo: {0}", number), inner)
        {
            throw new NegativeNumberException(inner.Message + " - " + number, inner);
        }
    }
    public class GreaterThanPreviousDateException : ApplicationException
    {
        public GreaterThanPreviousDateException() : base(string.Format("Data não pode ser maior do que a anterior"))
        {
            throw new GreaterThanPreviousDateException();
        }
        public GreaterThanPreviousDateException(string date1, string date2) : base(string.Format("Data não pode ser maior do que a anterior: {0} > {1}", date1, date2))
        { 
            throw new GreaterThanPreviousDateException(date1, date2);
        }
        public GreaterThanPreviousDateException(string date1, string date2, Exception inner) : base(string.Format("Data não pode ser maior do que a anterior: {0} > {1}", date1, date2), inner)
        {
            throw new GreaterThanPreviousDateException(inner.Message + " - " + date1 , date2, inner);
        }
    }
    public class InvalidIDException : ApplicationException
    {
        public InvalidIDException() : base(string.Format("ID inválido"))
        {
            throw new InvalidIDException();
        }
        public InvalidIDException(string id) : base(string.Format("ID inválido: {0}", id))
        {
            throw new InvalidIDException(this.Message + " - " + id);
        }
        public InvalidIDException(string id, Exception inner) : base(string.Format("ID inválido: {0}", id), inner)
        {
            throw new InvalidIDException(inner.Message + " - " + id, inner);
        }
    }
    public class AlreadyExistsException : ApplicationException
    {
        public AlreadyExistsException() : base(string.Format("O objeto já existe"))
        {
            throw new AlreadyExistsException();
        }
        public AlreadyExistsException(string id) : base(string.Format("O objeto {0} já existe", id))
        {
            throw new AlreadyExistsException(this.Message + " - " + id);
        }
        public AlreadyExistsException(string id, Exception inner) : base(string.Format("O objeto {0} já existe", id), inner)
        {
            throw new AlreadyExistsException(inner.Message + " - " + id, inner);
        }
    }
    public class InvalidStateException : ApplicationException
    {
        public InvalidStateException() : base(string.Format("Estado inválido"))
        {
            throw new InvalidStateException();
        }
        public InvalidStateException(string state) : base(string.Format("Estado inválido: {0}", state))
        {
            throw new InvalidStateException(this.Message + " - " + state);
        }
        public InvalidStateException(string state, Exception inner) : base(string.Format("Estado inválido: {0}", state), inner)
        {
            throw new InvalidStateException(inner.Message + " - " + state, inner);
        }
    }
}
