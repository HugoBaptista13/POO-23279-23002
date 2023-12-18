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

}
